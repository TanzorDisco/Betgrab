using System.Collections.Generic;
using System.Threading.Tasks;

namespace Betgrab.Web.Services.LiveScore
{
	public class Livescore
	{
		public static object sync = new object();

		public Livescore()
		{
			RunningTasks = new Dictionary<string, Task>();
		}

		public Dictionary<string, Task> RunningTasks { get; set; }

		public bool IsRunning(string taskId)
		{
			return RunningTasks.ContainsKey(taskId);
		}

		public void AddTask(string taskId, Task task)
		{
			lock(sync) {
				RunningTasks.Add(taskId, task);
			}
		}

		public void RemoveTask(string taskId)
		{
			lock(sync) {
				RunningTasks.Remove(taskId);
			}
		}
	}
}
