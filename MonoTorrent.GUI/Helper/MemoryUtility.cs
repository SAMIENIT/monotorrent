using System;
using System.Collections.Generic;
using System.Text;

namespace MonoTorrent.GUI.Helper
{
	public static class MemoryUtility
	{
		private static volatile bool _enabled = true;

		public static void OptimizeMemoryUsage()
		{
			if (!_enabled)
				return;

			try
			{
				System.Diagnostics.Process curProc = System.Diagnostics.Process.GetCurrentProcess();
				curProc.MaxWorkingSet = curProc.MaxWorkingSet;
			}
			catch
			{
				//Some users won't have permission to adjust their working set.
				_enabled = false;
			}
		}
	} 
}
