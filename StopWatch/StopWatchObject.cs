using System;

namespace StopWatch
{
	internal class StopWatchObject
	{
		public bool Started { get; private set; }
		private DateTime _start;
		private DateTime _stop;

		public void Start()
		{
			if (!Started)
			{
				_start = DateTime.Now;
				Started = true;
			}
		}

		public void Stop()
		{
			if (Started)
			{
				_stop = DateTime.Now;
				Started = false;
			}
		}

		public void Continue()
		{
			if (!Started)
			{
				_start = DateTime.Now.Subtract(_stop - _start);
				Started = true;
			}
		}

		public void Reset()
		{
			if (!Started)
			{
				_start = DateTime.MinValue;
				_stop = DateTime.MinValue;
			}
		}

		private TimeSpan CalculateDelta()
		{
			TimeSpan delta;
			if (Started)
				delta = DateTime.Now - _start;
			else
				delta = _stop - _start;
			return delta;
		}

		public override string ToString()
		{
			string ret;
			TimeSpan delta = CalculateDelta();

			if (delta.Hours > 0)
				ret = delta.ToString(@"hh\:mm\:ss\.fff");
			else if (delta.Minutes > 0)
				ret = delta.ToString(@"mm\:ss\.fff");
			else
				ret = delta.ToString(@"ss\.fff");

			return ret;
		}
	}
}