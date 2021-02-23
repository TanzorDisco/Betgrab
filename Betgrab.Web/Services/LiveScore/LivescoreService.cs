using Betgrab.Domain;
using Betgrab.Domain.Entities;
using Betgrab.Web.Adapters;
using Betgrab.Web.Adapters.Livescore.Event;
using Betgrab.Web.Extensions;
using Betgrab.Web.Services.Adapters.LiveScore;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betgrab.Web.Services.LiveScore
{
	public delegate void OnLivescoreOutputEventHandler(object sender, string id, string message);
	public delegate void OnLivescoreProgressEventHandler(object sender, string id, int progress);

	public class LivescoreService : BaseService, ILivescoreService
	{
		private readonly string LIVESCORE = "livescore.com";
		private readonly ILivescoreAdapter _adapter;
		private readonly IAnalogResolvingService _analogs;
		private readonly ILogger<LivescoreService> _logger;
		public event OnLivescoreOutputEventHandler OnOutput;
		public event OnLivescoreProgressEventHandler OnProgress;
		public int EventProcessed { get; set; }
        public int TotalEvents { get; set; }
		public int Progress => Convert.ToInt32((decimal)EventProcessed / (decimal)TotalEvents * 100);
		public ParsingInfo Info { get; set; }
		public bool EventOutputOnly { get; set; }
		public string TaskId { get; set; }

		public LivescoreService(
			BetgrabContext context, 
			ILivescoreAdapter adapter,
			IAnalogResolvingService analogResolvingService,
			Livescore livescore,
			ILogger<LivescoreService> logger) : base(context)
		{
			_adapter = adapter;
			_analogs = analogResolvingService;
			_logger = logger;
		}

		public int ParseDate(DateTime date)
		{
			TaskId = date.ToString("yyyy-MM-dd");

			try
			{
				OutputMessage($"Start parsing day: {date:d MMM yyyy}");

				_logger.LogInformation($"{TaskId} {DateTime.Now}: Starting ParseDateInternal");

				ParseDateInternal(date, out List<Analog> analogs);

				_logger.LogInformation($"{TaskId} {DateTime.Now}: End ParseDateInternal");

				var dist = analogs.Distinct();

				var newEntities = new List<IEntity>();

				dist.OrderBy(a =>
					a.Type == nameof(Nation) ? 1
					: a.Type == nameof(League) ? 2
					: a.Type == nameof(Stage) ? 3
					: a.Type == nameof(Club) ? 4
					: a.Type == nameof(Player) ? 5
					: a.Type == nameof(Event) ? 6
					: a.Type == nameof(Fact) ? 7 
					: 0)
					.ToList()
					.ForEach(a =>
					{
						var now = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff");

						switch (a.Type)
						{
							case nameof(League):
								_logger.LogInformation($"{TaskId} {now}: UpdateLeague");
								var league = _analogs.ResolveLivescoreAnalog<League>(a);
								UpdateLeague(a, league);
								break;

							case nameof(Nation):
								_logger.LogInformation($"{TaskId} {now}: UpdateNation");
								var nation = _analogs.ResolveLivescoreAnalog<Nation>(a);
								UpdateNation(a, nation);
								break;

							case nameof(Stage):
								_logger.LogInformation($"{TaskId} {now}: UpdateStage");
								var stage = _analogs.ResolveLivescoreAnalog<Stage>(a);
								UpdateStage(a, stage);
								break;

							case nameof(Event):
								_logger.LogInformation($"{TaskId} {now}: UpdateEvent");
								var ev = _analogs.ResolveLivescoreAnalog<Event>(a);
								UpdateEvent(a, ev);
								break;

							case nameof(Club):
								_logger.LogInformation($"{TaskId} {now}: UpdateClub");
								var club = _analogs.ResolveLivescoreAnalog<Club>(a);
								UpdateClub(a, club);
								break;

							case nameof(Player):
								_logger.LogInformation($"{TaskId} {now}: UpdatePlayer");
								UpdatePlayer(a, _analogs.ResolveLivescoreAnalog<Player>(a));
								break;

							case nameof(Fact):
								_logger.LogInformation($"{TaskId} {now}: UpdateFact");
								UpdateFact(a, _analogs.ResolveLivescoreAnalog<Fact>(a));
								break;
						}
					});

				_logger.LogInformation($"{TaskId} {DateTime.Now}: Done. Saving changes");

				OutputMessage("Done");
				OutputMessage("Saving changes");

				Ctx.SaveChanges();

				_logger.LogInformation($"{TaskId} {DateTime.Now}: Changes successfully saved!");

				OutputMessage("Done");

				return 0;
			}
			catch (Exception exc)
			{
				OutputMessage($"Exception occured while parsing livescore day:\n{exc}");

				return 1;
			}
		}

		public async Task<int> ParseDateAsync(DateTime date) 
		{
			return await Task.Run<int>(() => this.ParseDate(date));
		}

		/// <summary>
		/// Получение и разбор данных от livescore.com для конкретной даты
		/// Пример страницы: https://www.livescore.com/en/football/2021-01-06/
		/// </summary>
		/// <param name="date"></param>
		/// <param name="analogs"></param>
		/// <returns></returns>
		public int ParseDateInternal(DateTime date, out List<Analog> analogs)
		{
			OutputMessage($"Getting data from livescore.com and parsing json");

			var data = _adapter.GetResults(date);

			// Общее количество событий за день
			TotalEvents = CountEvents(data);

			OutputMessage($"Done");

			analogs = new List<Analog>();

			OutputMessage($"Generating analogs");

			foreach (var stage in data.Stages)
			{
				analogs.Add(
					CreateAnalog<Stage>(stage.Sid, new { stage.Cid, stage.Sdn })
				);

				// ссылка на аналог лиги пригодится нам чуть ниже, когда мы доберемся до страны 
				var leagueAnalog = CreateAnalog<League>(stage.Cid, new { stage.Cnm, CoId = string.Empty });

				analogs.Add(
					leagueAnalog
				);

				foreach (var dtoEvent in stage.Events)
				{
					OutputEvent($"{dtoEvent.T1.First().Nm} - {dtoEvent.T2.First().Nm}");

					var livescoreEventData = _adapter.GetEventData(dtoEvent.Eid);

					analogs.Add(CreateAnalog<Event>(dtoEvent.Eid, new 
						{ 
							dtoEvent.Tr1, dtoEvent.Tr2, 
							dtoEvent.Eps, dtoEvent.Edf, dtoEvent.Eds,
							dtoEvent.T1, dtoEvent.T2, 
							stage.Sid, livescoreEventData.Stat
						})
					);

					#region T1, T2 - команда 1, команда 2

					foreach (var dtoTeam in new[] { dtoEvent.T1.First(), dtoEvent.T2.First() })
					{
						analogs.Add(
							CreateAnalog<Club>(dtoTeam.ID, new { dtoTeam.Nm, dtoTeam.CoId })
						);

						// dtoTeam может содержать страну в полях CoId, CoNm
						if (!string.IsNullOrWhiteSpace(dtoTeam.CoId))
						{
							leagueAnalog.Json = new { leagueAnalog.Json.Cnm, dtoTeam.CoId };

							analogs.Add(
								CreateAnalog<Nation>(dtoTeam.CoId, new { dtoTeam.CoNm })
							);
						}
					}

					#endregion

					OutputMessage($"Done");
					OutputMessage($"Generating analogs");

					ParseEventInternal(livescoreEventData, date, out List<Analog> eventDataAnalogs);

					OutputMessage($"Done");

					analogs = analogs.Concat(eventDataAnalogs).ToList();

					EventProcessed += 1;

					OutputProgress();
				}
			}

			OutputEvent($"All matches successfully processed!");

			return 0;
		}
		public int ParseEventInternal(LivescoreEventDto dto, DateTime date, out List<Analog> analogs)
		{
			analogs = new List<Analog>();

			var dtoTeams = new[] { dto.T1.First(), dto.T2.First() };

			#region Lu - составы команд

			OutputMessage($"Line ups");

			if (dto.Lu != null)
			{
				for (int i = 0; i < dto.Lu.Length; i++)
				{
					foreach (var dtoPlayer in dto.Lu[i].Ps)
					{
						analogs.Add(
							CreateAnalog<Player>(dtoPlayer.Pid.ToString(), new
							{
								dtoPlayer.Fn,
								dtoPlayer.Ln,
								dtoPlayer.Pon,
								dtoPlayer.Snu,
								Tid = dtoTeams[i].Id,
								dtoTeams[i].CoId
							})
						);
					}
				}
			}

			#endregion

			#region Incs - что произошло во время матча

			OutputMessage($"Incs");

			if (dto.Incs != null)
			{
				if (dto.Incs.Any())
				{
					foreach(var inc in dto.Incs)
					{
						foreach(var v in inc.Value)
						{
							// тут вероятнее всего забивший гол и его ассистент 
							if (v.Incs != null && v.Incs.Any())
							{
								foreach (var v_ in v.Incs)
								{
									analogs.Add(
										CreateAnalog<Fact>(v_.Id.ToString(), new { v_.Id, v_.Pn, v_.Min, v_.MinEx, v_.Sc, v_.It, dto.Eid })
									);
								}
							}
							else
							{
								analogs.Add(
									CreateAnalog<Fact>(v.Id.ToString(), new { v.Id, v.Pn, v.Min, v.MinEx, v.Sc, v.It, dto.Eid })
								);
							}
						}
					}
				}
			}

			#endregion

			#region Refs - судьи

			#endregion

			return 0;
		}
		public int CountEvents(Web.Adapters.Livescore.Results.LiveScoreResponseDto dto)
        {
			return dto.Stages.SelectMany(s => s.Events).Count();
        }
		private Analog CreateAnalog<T>(string id, object data = null)
		{
			return new Analog
			{
				Type = typeof(T).Name,
				Service = LIVESCORE,
				ServiceId = id,
				Json = data
			};
		}

		#region Entity Updaters

		private void UpdateNation(Analog a, Nation n)
		{
			n.Name = a.Json.CoNm;

			Ctx.SaveChanges();
		}
		private void UpdateLeague(Analog a, League l)
		{
			l.Name = a.Json.Cnm;

			Ctx.SaveChanges();
		}
		private void UpdateStage(Analog a, Stage s)
		{
			s.Name = a.Json.Sdn;

			string cid = a.Json.Cid;
			if (!string.IsNullOrEmpty(cid))
			{
				s.LeagueId = Ctx.Leagues.TryFindLivescore(cid, out League l)
					? (int?)l.Id
					: null;
			}

			Ctx.SaveChanges();
		}
		private void UpdateEvent(Analog a, Event e)
		{
			if (a.Json.Eps == "Postp.")
				e.IsCancelled = true;

			e.StartDate = ((long?)a.Json.Eds).ToDateTime();
			e.FinishDate = ((long?)a.Json.Edf).ToDateTime();

			e.Tr1 = byte.TryParse(a.Json.Tr1, out byte tr1)
				? (byte?)tr1
				: null;

			e.Tr2 = byte.TryParse(a.Json.Tr2, out byte tr2)
				? (byte?)tr2
				: null;

			// допускаем, что свойства нет
			try
			{
				e.Trh1 = byte.TryParse(a.Json.Trh1, out byte trh1)
				? (byte?)trh1
				: null;
			}
			catch (RuntimeBinderException) { }

			try
			{
				e.Trh2 = byte.TryParse(a.Json.Trh2, out byte trh2)
				? (byte?)trh2
				: null;
			}
			catch (RuntimeBinderException) { }

			var t1 = (List<Web.Adapters.Livescore.Results.T1>)a.Json.T1;
			if (t1.Any())
			{
				var teamId = t1.First().ID;

				e.Club1Id = Ctx.Clubs.TryFindLivescore(teamId, out Club club)
					? (int?)club.Id
					: null;
			}

			var t2 = (List<Web.Adapters.Livescore.Results.T1>)a.Json.T2;
			if (t2.Any())
			{
				var teamId = t2.First().ID;

				e.Club2Id = Ctx.Clubs.TryFindLivescore(teamId, out Club club)
					? (int?)club.Id
					: null;
			}

			string stageId = a.Json.Sid;
			if (!string.IsNullOrEmpty(stageId))
			{
				e.StageId = Ctx.Stages.TryFindLivescore(stageId, out Stage stage)
					? (int?)stage.Id
					: null;
			}

			try
			{
				Stat[] dtoStats = a.Json.Stat;
				if (dtoStats != null)
				{
					var dtoTeams = new List<Web.Adapters.Livescore.Results.T1>() { t1.First(), t2.First() };

					for (int i = 0; i < 2; i++)
					{
						var stats = new EventStats();

						UpdateEventStats(
							CreateAnalog<EventStats>(null, 
								new {
									Tid = dtoTeams[i].ID, Eid = e.LivescoreId,
									dtoStats[i].Att, dtoStats[i].Cos, dtoStats[i].Crs,
									dtoStats[i].Fls, dtoStats[i].Gks, dtoStats[i].Goa,
									dtoStats[i].Ofs, dtoStats[i].Pss,dtoStats[i].Rcs,
									dtoStats[i].Shbl, dtoStats[i].Shof, dtoStats[i].Shon,
									dtoStats[i].Shwd, dtoStats[i].Ths, dtoStats[i].Tnb,
									dtoStats[i].Trt, dtoStats[i].YRcs, dtoStats[i].Ycs,
								}),
							
							stats
						);

						Ctx.EventStats.Add(stats);

						
					}
				}
			}
			catch (RuntimeBinderException) { }
			finally { Ctx.SaveChanges(); }
		}
		private void UpdateClub(Analog a, Club c)
		{
			c.Name = a.Json.Nm;

			string coId = a.Json.CoId;
			if (!string.IsNullOrEmpty(coId))
			{
				c.NationId = Ctx.Nations.TryFindLivescore(coId, out Nation nation)
					? (int?)nation.Id
					: null;
			}
			
			Ctx.SaveChanges();
		}
		private void UpdatePlayer(Analog a, Player p)
		{
			p.FirstName = a.Json.Fn;
			p.LastName = a.Json.Ln;

			p.PositionName = a.Json.Pon;
			p.PlayerNumber = (int?)a.Json.Snu;

			// var coId = (string)a.Json.CoId;

			string clubId = a.Json.Tid;
			if (!string.IsNullOrEmpty(clubId))
			{
				if (Ctx.Clubs.TryFindLivescore(clubId, out Club club))
				{
					if (!Ctx.ClubMember.Any(cm => cm.PlayerId == p.Id && cm.ClubId == club.Id))
						Ctx.ClubMember.Add(new ClubMember { PlayerId = p.Id, ClubId = club.Id });
				}
			}

			Ctx.SaveChanges();
		}
		private void UpdateFact(Analog a, Fact f)
		{
			f.Min = (byte)a.Json.Min;
			f.MinEx = (byte?)a.Json.MinEx;
			f.Type = (MatchFacts)a.Json.It;

			string playerId = a.Json.Id?.ToString();
			if (!string.IsNullOrEmpty(playerId))
			{
				f.PlayerId = Ctx.Players.TryFindLivescore(playerId, out Player player)
					? (int?)player.Id
					: null;
			}

			string eventId = a.Json.Eid?.ToString();
			if (!string.IsNullOrEmpty(eventId))
			{
				f.EventId = Ctx.Events.TryFindLivescore(eventId, out Event ev)
					? (int?)ev.Id
					: null;
			}

			Ctx.SaveChanges();
		}
		private void UpdateEventStats(Analog a, EventStats s)
		{
			string tid = (string)a.Json.Tid;
			if (!string.IsNullOrEmpty(tid))
				s.ClubId = Ctx.Clubs.TryFindLivescore(tid, out Club c)
					? (int?)c.Id
					: null;

			string eid = (string)a.Json.Eid;
			if (!string.IsNullOrEmpty(eid))
				s.EventId = Ctx.Events.TryFindLivescore(eid, out Event e)
					? (int?)e.Id
					: null;

			try { s.CornerKicks = a.Json.Cos; } catch (RuntimeBinderException) { }
			try { s.CounterAttacks = a.Json.Att; } catch (RuntimeBinderException) { }
			try { s.Crosses = a.Json.Crs; } catch (RuntimeBinderException) { }
			try { s.Fouls = a.Json.Fls; } catch (RuntimeBinderException) { }
			try { s.GoalkeeperSaves = a.Json.Gks; } catch (RuntimeBinderException) { }
			try { s.GoalKicks = a.Json.Goa; } catch (RuntimeBinderException) { }
			try { s.Offsides = a.Json.Ofs; } catch (RuntimeBinderException) { }
			try { s.Possession = a.Json.Pss; } catch (RuntimeBinderException) { }
			try { s.RedCards = a.Json.Rcs; } catch (RuntimeBinderException) { }
			try { s.ShotsBlocked = a.Json.Shbl; } catch (RuntimeBinderException) { }
			try { s.ShotsOffTarget = a.Json.Shof; } catch (RuntimeBinderException) { }
			try { s.ShotsOnTarget = a.Json.Shon; } catch (RuntimeBinderException) { }
			try { s.ThrowIns = a.Json.Ths; } catch (RuntimeBinderException) { }
			try { s.Treatments = a.Json.Trt; } catch (RuntimeBinderException) { }
			try { s.YellowCards = a.Json.Ycs; } catch (RuntimeBinderException) { }
			try { s.YellowRedCards = a.Json.YRcs; } catch (RuntimeBinderException) { }

			// try { s.?? = a.Json.Shwd; } catch (RuntimeBinderException) { }
			// try { s.?? = a.Json.Tnb; } catch (RuntimeBinderException) { }

			Ctx.SaveChanges();
		}

		#endregion
		
        private void OutputMessage(string message) 
		{
			if (!EventOutputOnly)
				OnOutput?.Invoke(this, TaskId, message);
		}
		private void OutputEvent(string message) 
		{
			OnOutput?.Invoke(this, TaskId, message);
		}

		private void OutputProgress() 
		{
			OnProgress?.Invoke(this, TaskId, Progress);
		}
    }
}
