using System;

namespace StopWatch
{
	internal class StopWatchObject
	{
		private bool _started;
		private DateTime _start;
		private DateTime _stop;

		public void Start()
		{
			if (!_started)
			{
				_start = DateTime.Now;
				_started = true;
			}
		}

		public void Stop()
		{
			if (_started)
			{
				_stop = DateTime.Now;
				_started = false;
			}
		}

		public void Continue()
		{
			if (!_started)
			{
				_start = DateTime.Now.Subtract(_stop - _start);
				_started = true;
			}
		}

		public void Reset()
		{
			if (!_started)
			{
				_start = DateTime.MinValue;
				_stop = DateTime.MinValue;
			}
		}

		private TimeSpan CalculateDelta()
		{
			TimeSpan delta;
			if (_started)
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