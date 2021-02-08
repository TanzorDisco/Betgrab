using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betgrab.Web.Adapters.Livescore.Results
{
   // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
   public class Shrt
   {
      public string Bs { get; set; }
      public string Sl { get; set; }
      public string Nmb { get; set; }
      public bool Sq { get; set; }
      public bool St { get; set; }
      public bool Hst { get; set; }
      public bool Spl { get; set; }
      public string Sld { get; set; }
      public string StC { get; set; }
   }

   public class T1
   {
      public string Nm { get; set; }
      public string ID { get; set; }
      public int tbd { get; set; }
      public string Img { get; set; }
      public List<object> EL { get; set; }
      public int Gd { get; set; }
      public Dictionary<string, object> Pids { get; set; }
      public string CoNm { get; set; }
      public string CoId { get; set; }
      public Shrt Shrt { get; set; }
   }

   public class Stg
   {
      public string Sid { get; set; }
      public string Snm { get; set; }
      public string Sds { get; set; }
      public string Scd { get; set; }
      public string Cid { get; set; }
      public string Cnm { get; set; }
      public string Csnm { get; set; }
      public string Ccd { get; set; }
      public int Scu { get; set; }
      public int Chi { get; set; }
      public int Shi { get; set; }
      public string Sdn { get; set; }
   }

   public class Sids
   {
      public string _1 { get; set; }
      public string _6 { get; set; }
      public string _8 { get; set; }
      public string _12 { get; set; }
   }

   public class Event
   {
      public string Eid { get; set; }
      public Dictionary<string, object> Pids { get; set; }
      public string Eps { get; set; }
      public int Esid { get; set; }
      public int Epr { get; set; }
      public int Ecov { get; set; }
      public int ErnO { get; set; }
      public int Ern { get; set; }
      public string ErnInf { get; set; }
      public int Ewt { get; set; }
      public int Et { get; set; }
      public string Tr1 { get; set; }
      public string Tr2 { get; set; }
      public string Trh1 { get; set; }
      public string Trh2 { get; set; }
      public string Tr1OR { get; set; }
      public string Tr2OR { get; set; }
      public List<T1> T1 { get; set; }
      public List<T1> T2 { get; set; }
      public int IncsX { get; set; }
      public int ComX { get; set; }
      public int LuX { get; set; }
      public int StatX { get; set; }
      public int SubsX { get; set; }
      public int SDFowX { get; set; }
      public int SDInnX { get; set; }
      public object Esd { get; set; }
      public object LuUT { get; set; }
      public object Eds { get; set; }
      public object Edf { get; set; }
      public int EO { get; set; }
      public int Eact { get; set; }
      public Stg Stg { get; set; }
      public Sids Sids { get; set; }
      public int Pid { get; set; }
      public int Spid { get; set; }
   }

   public class Team
   {
      public int rnk { get; set; }
      public int win { get; set; }
      public int wreg { get; set; }
      public int wot { get; set; }
      public int wap { get; set; }
      public int drw { get; set; }
      public int lst { get; set; }
      public int lreg { get; set; }
      public int lot { get; set; }
      public int lap { get; set; }
      public int gf { get; set; }
      public int ga { get; set; }
      public int gd { get; set; }
      public int pts { get; set; }
      public int pld { get; set; }
      public string Tid { get; set; }
      public string Tnm { get; set; }
      public List<int> phr { get; set; }
      public int Ipr { get; set; }
      public List<object> com { get; set; }
      public int pa { get; set; }
      public int pf { get; set; }
   }

   public class Table
   {
      public int LTT { get; set; }
      public List<Team> team { get; set; }
      public List<object> phrX { get; set; }
   }

   public class L
   {
      public List<Table> Tables { get; set; }
   }

   public class LeagueTable
   {
      public List<L> L { get; set; }
   }

   public class Stage
   {
      public string Snm { get; set; }
      public string Sdn { get; set; }
      public string Sds { get; set; }
      public string Scd { get; set; }
      public string Cnm { get; set; }
      public string Csnm { get; set; }
      public string Ccd { get; set; }
      public List<Event> Events { get; set; }
      public LeagueTable LeagueTable { get; set; }
      public string Sid { get; set; }
      public string Cid { get; set; }
   }

   public class LiveScoreResponseDto
   {
      public List<Stage> Stages { get; set; }
   }

}

namespace Betgrab.Web.Adapters.Livescore.Event
{
   using System;
   using System.Collections.Generic;

   using System.Globalization;
   using Newtonsoft.Json;
   using Newtonsoft.Json.Converters;
   public partial class LivescoreEventDto
   {
      [JsonProperty("Eid")]
      public long Eid { get; set; }

      [JsonProperty("Pids")]
      public Dictionary<string, object> Pids { get; set; }

      [JsonProperty("Eps")]
      public string Eps { get; set; }

      [JsonProperty("Esid")]
      public long Esid { get; set; }

      [JsonProperty("Epr")]
      public long Epr { get; set; }

      [JsonProperty("Ecov")]
      public long Ecov { get; set; }

      [JsonProperty("ErnO")]
      public long ErnO { get; set; }

      [JsonProperty("Ern")]
      public long Ern { get; set; }

      [JsonProperty("ErnInf")]
      public string ErnInf { get; set; }

      [JsonProperty("Ewt")]
      public long Ewt { get; set; }

      [JsonProperty("Et")]
      public long Et { get; set; }

      [JsonProperty("Tr1")]
      public long Tr1 { get; set; }

      [JsonProperty("Tr2")]
      public long Tr2 { get; set; }

      [JsonProperty("Trh1")]
      public long Trh1 { get; set; }

      [JsonProperty("Trh2")]
      public long Trh2 { get; set; }

      [JsonProperty("Tr1OR")]
      public long Tr1Or { get; set; }

      [JsonProperty("Tr2OR")]
      public long Tr2Or { get; set; }

      [JsonProperty("T1")]
      public LivescoreEventDtoT1[] T1 { get; set; }

      [JsonProperty("T2")]
      public LivescoreEventDtoT1[] T2 { get; set; }

      [JsonProperty("IncsX")]
      public long IncsX { get; set; }

      [JsonProperty("ComX")]
      public long ComX { get; set; }

      [JsonProperty("LuX")]
      public long LuX { get; set; }

      [JsonProperty("Refs")]
		public List<Referee> Refs { get; set; }

		[JsonProperty("StatX")]
      public long StatX { get; set; }

      [JsonProperty("SubsX")]
      public long SubsX { get; set; }

      [JsonProperty("SDFowX")]
      public long SdFowX { get; set; }

      [JsonProperty("SDInnX")]
      public long SdInnX { get; set; }

      [JsonProperty("Esd")]
      public long Esd { get; set; }

      [JsonProperty("LuUT")]
      public long LuUt { get; set; }

      [JsonProperty("Eds")]
      public long Eds { get; set; }

      [JsonProperty("Edf")]
      public long Edf { get; set; }

      [JsonProperty("EO")]
      public long Eo { get; set; }

      [JsonProperty("Eact")]
      public long Eact { get; set; }

      [JsonProperty("Stg")]
      public Stg Stg { get; set; }

      [JsonProperty("Sids")]
      public Dictionary<string, string> Sids { get; set; }

      [JsonProperty("Pid")]
      public long Pid { get; set; }

      [JsonProperty("Spid")]
      public long Spid { get; set; }

      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("Vnm")]
      public string Vnm { get; set; }

      [JsonProperty("VCnm")]
      public string VCnm { get; set; }

      [JsonProperty("Vneut")]
      public long Vneut { get; set; }

      [JsonProperty("VCity")]
      public string VCity { get; set; }

      [JsonProperty("Vcy")]
      public string Vcy { get; set; }

      [JsonProperty("Incs")]
      public Dictionary<string, Inc[]> Incs { get; set; }

      [JsonProperty("Subs")]
      public Subs Subs { get; set; }

      [JsonProperty("Stat")]
      public Stat[] Stat { get; set; }

      [JsonProperty("Lu")]
      public Lu[] Lu { get; set; }

      [JsonProperty("Com")]
      public Com[] Com { get; set; }

      [JsonProperty("Eloff")]
      public long Eloff { get; set; }

      [JsonProperty("Prns")]
      public Prn[] Prns { get; set; }

      [JsonProperty("LgT")]
      public LgT[] LgT { get; set; }

      [JsonProperty("H2H")]
      public H2H[] H2H { get; set; }
   }

   public partial class Stat
	{
      public int Att { get; set; }
      public int Cos { get; set; }
      public int Crs { get; set; }
      public int Fls { get; set; }
      public int Gks { get; set; }
      public int Goa { get; set; }
      public int Ofs { get; set; }
      public int Pss { get; set; }
      public int Rcs { get; set; }
      public int Shbl { get; set; }
      public int Shof { get; set; }
      public int Shon { get; set; }
      public int Shwd { get; set; }
      public int Ths { get; set; }
      public int Tnb { get; set; }
      public int Trt { get; set; }
      public int YRcs { get; set; }
      public int Ycs { get; set; }
   }

   public partial class Com
   {
      [JsonProperty("Min")]
      public long? Min { get; set; }

      [JsonProperty("MinEx")]
      public long? MinEx { get; set; }

      [JsonProperty("Txt")]
      public string Txt { get; set; }

      [JsonProperty("IT")]
      public long? It { get; set; }
   }

   public partial class H2H
   {
      [JsonProperty("T1")]
      public H2HT1[] T1 { get; set; }

      [JsonProperty("T2")]
      public H2HT1[] T2 { get; set; }

      [JsonProperty("Tr1")]
      public string Tr1 { get; set; }

      [JsonProperty("Tr2")]
      public string Tr2 { get; set; }

      [JsonProperty("Stg")]
      public Stg Stg { get; set; }

      [JsonProperty("Esid")]
      public long Esid { get; set; }

      [JsonProperty("Eps")]
      public string Eps { get; set; }

      [JsonProperty("Epr")]
      public long Epr { get; set; }

      [JsonProperty("Ewt")]
      public long Ewt { get; set; }

      [JsonProperty("Esd")]
      public long Esd { get; set; }
   }

   public partial class Stg
   {
      [JsonProperty("Sid")]
      public long Sid { get; set; }

      [JsonProperty("Snm")]
      public string Snm { get; set; }

      [JsonProperty("Sds")]
      public string Sds { get; set; }

      [JsonProperty("Scd")]
      public string Scd { get; set; }

      [JsonProperty("Cid")]
      public long Cid { get; set; }

      [JsonProperty("Cnm")]
      public string Cnm { get; set; }

      [JsonProperty("Csnm")]
      public string Csnm { get; set; }

      [JsonProperty("Ccd")]
      public string Ccd { get; set; }

      [JsonProperty("Scu")]
      public long Scu { get; set; }

      [JsonProperty("Chi")]
      public long Chi { get; set; }

      [JsonProperty("Shi")]
      public long Shi { get; set; }

      [JsonProperty("Sdn")]
      public string Sdn { get; set; }
   }

   public partial class H2HT1
   {
      [JsonProperty("Nm")]
      public string Nm { get; set; }

      [JsonProperty("ID")]
      public string Id { get; set; }

      [JsonProperty("tbd")]
      public long Tbd { get; set; }

      [JsonProperty("Img")]
      public string Img { get; set; }

      [JsonProperty("EL")]
      public object[] El { get; set; }

      [JsonProperty("Gd")]
      public long Gd { get; set; }

      [JsonProperty("Pids")]
      public Dictionary<string, object> Pids { get; set; }

      [JsonProperty("CoNm")]
      public string CoNm { get; set; }

      [JsonProperty("CoId")]
      public string CoId { get; set; }
   }

   public partial class Inc
   {
      [JsonProperty("Min")]
      public long Min { get; set; }

      [JsonProperty("Nm")]
      public long Nm { get; set; }

      [JsonProperty("Sc")]
      public long[] Sc { get; set; }

      [JsonProperty("Sor")]
      public long Sor { get; set; }

      [JsonProperty("Incs")]
      public The2[] Incs { get; set; }

      [JsonProperty("ID")]
      public long? Id { get; set; }

      [JsonProperty("Pnum")]
      public long? Pnum { get; set; }

      [JsonProperty("Pn")]
      public string Pn { get; set; }

      [JsonProperty("Ps")]
      public string Ps { get; set; }

      [JsonProperty("PnumO")]
      public long? PnumO { get; set; }

      [JsonProperty("PnO")]
      public string PnO { get; set; }

      [JsonProperty("PsO")]
      public string PsO { get; set; }

      [JsonProperty("IT")]
      public long? It { get; set; }

      [JsonProperty("IR")]
      public string Ir { get; set; }

      [JsonProperty("IDo")]
      public long? IDo { get; set; }

      [JsonProperty("MinEx")]
      public long? MinEx { get; set; }
   }

   public partial class The2
   {
      [JsonProperty("Min")]
      public long Min { get; set; }

      [JsonProperty("Nm")]
      public long Nm { get; set; }

      [JsonProperty("ID")]
      public long? Id { get; set; }

      [JsonProperty("Pnum")]
      public long? Pnum { get; set; }

      [JsonProperty("Pn")]
      public string Pn { get; set; }

      [JsonProperty("Ps")]
      public string Ps { get; set; }

      [JsonProperty("PnumO")]
      public long? PnumO { get; set; }

      [JsonProperty("PnO")]
      public string PnO { get; set; }

      [JsonProperty("PsO")]
      public string PsO { get; set; }

      [JsonProperty("IT")]
      public long? It { get; set; }

      [JsonProperty("IR")]
      public string Ir { get; set; }

      [JsonProperty("Sc")]
      public long[] Sc { get; set; }

      [JsonProperty("Sor")]
      public long Sor { get; set; }

      [JsonProperty("Incs")]
      public The2[] Incs { get; set; }

      [JsonProperty("IDo")]
      public long? IDo { get; set; }

      [JsonProperty("MinEx")]
      public long? MinEx { get; set; }
   }

   public partial class LgT
   {
      [JsonProperty("Tables")]
      public Table[] Tables { get; set; }
   }

   public partial class Table
   {
      [JsonProperty("LTT")]
      public long Ltt { get; set; }

      [JsonProperty("team")]
      public Team[] Team { get; set; }

      [JsonProperty("phrX")]
      public PhrX[] PhrX { get; set; }
   }

   public partial class PhrX
   {
      [JsonProperty("V")]
      public long V { get; set; }

      [JsonProperty("D")]
      public long D { get; set; }
   }

   public partial class Team
   {
      [JsonProperty("rnk")]
      public long Rnk { get; set; }

      [JsonProperty("win")]
      public long Win { get; set; }

      [JsonProperty("wreg")]
      public long Wreg { get; set; }

      [JsonProperty("wot")]
      public long Wot { get; set; }

      [JsonProperty("wap")]
      public long Wap { get; set; }

      [JsonProperty("drw")]
      public long Drw { get; set; }

      [JsonProperty("lst")]
      public long Lst { get; set; }

      [JsonProperty("lreg")]
      public long Lreg { get; set; }

      [JsonProperty("lot")]
      public long Lot { get; set; }

      [JsonProperty("lap")]
      public long Lap { get; set; }

      [JsonProperty("gf")]
      public long Gf { get; set; }

      [JsonProperty("ga")]
      public long Ga { get; set; }

      [JsonProperty("gd")]
      public long Gd { get; set; }

      [JsonProperty("pts")]
      public long Pts { get; set; }

      [JsonProperty("pld")]
      public long Pld { get; set; }

      [JsonProperty("Tid")]
      public long Tid { get; set; }

      [JsonProperty("Tnm")]
      public string Tnm { get; set; }

      [JsonProperty("phr")]
      public long[] Phr { get; set; }

      [JsonProperty("Ipr")]
      public long Ipr { get; set; }

      [JsonProperty("pa")]
      public long Pa { get; set; }

      [JsonProperty("pf")]
      public long Pf { get; set; }
   }

   public partial class Lu
   {
      [JsonProperty("Tnb")]
      public long Tnb { get; set; }

      [JsonProperty("Ps")]
      public P[] Ps { get; set; }

      [JsonProperty("Fo")]
      public long[] Fo { get; set; }
   }

   public partial class P
   {
      [JsonProperty("Pid")]
      public long Pid { get; set; }

      [JsonProperty("Fn")]
      public string Fn { get; set; }

      [JsonProperty("Ln")]
      public string Ln { get; set; }

      [JsonProperty("Snm")]
      public string Snm { get; set; }

      [JsonProperty("Pos")]
      public long Pos { get; set; }

      [JsonProperty("Pon")]
      public string Pon { get; set; }

      [JsonProperty("Snu")]
      public long? Snu { get; set; }

      [JsonProperty("Shnm")]
      public string Shnm { get; set; }

      [JsonProperty("PosA")]
      public long PosA { get; set; }

      [JsonProperty("Fp")]
      public string Fp { get; set; }

      [JsonProperty("Mo")]
      public long? Mo { get; set; }
   }

   public partial class Prn
   {
      [JsonProperty("Pid")]
      public long Pid { get; set; }

      [JsonProperty("Fn")]
      public string Fn { get; set; }

      [JsonProperty("Ln")]
      public string Ln { get; set; }
   }

   public partial class Subs
   {
      [JsonProperty("1")]
      public The2[] _1 { get; set; }

      [JsonProperty("2")]
      public The2[] _2 { get; set; }
   }

   public partial class LivescoreEventDtoT1
   {
      [JsonProperty("Nm")]
      public string Nm { get; set; }

      [JsonProperty("ID")]
      public string Id { get; set; }

      [JsonProperty("Img")]
      public string Img { get; set; }

      [JsonProperty("EL")]
      public El[] El { get; set; }

      [JsonProperty("Gd")]
      public long Gd { get; set; }

      [JsonProperty("Pids")]
      public Dictionary<string, object> Pids { get; set; }

      [JsonProperty("CoNm")]
      public string CoNm { get; set; }

      [JsonProperty("CoId")]
      public string CoId { get; set; }

      [JsonProperty("Shrt")]
      public Shrt Shrt { get; set; }
   }

   public partial class El
   {
      [JsonProperty("T1")]
      public ElT1[] T1 { get; set; }

      [JsonProperty("T2")]
      public ElT1[] T2 { get; set; }

      [JsonProperty("Tr1")]
      public string Tr1 { get; set; }

      [JsonProperty("Tr2")]
      public string Tr2 { get; set; }

      [JsonProperty("Stg")]
      public Stg Stg { get; set; }

      [JsonProperty("Esid")]
      public long Esid { get; set; }

      [JsonProperty("Eps")]
      public string Eps { get; set; }

      [JsonProperty("Epr")]
      public long Epr { get; set; }

      [JsonProperty("Ewt")]
      public long Ewt { get; set; }

      [JsonProperty("Esd")]
      public long Esd { get; set; }
   }

   public partial class ElT1
   {
      [JsonProperty("Nm")]
      public string Nm { get; set; }

      [JsonProperty("ID")]
      public string Id { get; set; }

      [JsonProperty("tbd")]
      public long Tbd { get; set; }

      [JsonProperty("Img")]
      public string Img { get; set; }

      [JsonProperty("EL")]
      public object[] El { get; set; }

      [JsonProperty("Gd")]
      public long Gd { get; set; }

      [JsonProperty("Pids")]
      public Dictionary<string, object> Pids { get; set; }

      [JsonProperty("CoNm")]
      public string CoNm { get; set; }

      [JsonProperty("CoId")]
      public string CoId { get; set; }

      [JsonProperty("Shrt")]
      public Shrt Shrt { get; set; }
   }

   public partial class Shrt
   {
      [JsonProperty("Bs")]
      public string Bs { get; set; }

      [JsonProperty("Sl")]
      public string Sl { get; set; }

      [JsonProperty("Nmb")]
      public string Nmb { get; set; }

      [JsonProperty("Sq")]
      public bool Sq { get; set; }

      [JsonProperty("St")]
      public bool St { get; set; }

      [JsonProperty("Hst")]
      public bool Hst { get; set; }

      [JsonProperty("Spl")]
      public bool Spl { get; set; }

      [JsonProperty("Sld")]
      public string Sld { get; set; }

      [JsonProperty("StC")]
      public string StC { get; set; }
   }

	public partial class Referee
	{
      [JsonProperty("Cn")]
      public string Cn { get; set; }

      [JsonProperty("Kn")]
      public int Kn { get; set; }

      [JsonProperty("Nm")]
		public string Nm { get; set; }
	}
}