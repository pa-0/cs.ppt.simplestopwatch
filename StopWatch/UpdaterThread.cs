using System;
using System.Threading;
using System.Windows.Threading;

namespace StopWatch
{
	internal class UpdaterThread
	{
		private readonly Action _action;
		private readonly int _delay;
		private readonly Dispatcher _dispatcher;
		private Thread _thread;

		public UpdaterThread(Dispatcher dispatcher, Action action, int delay)
		{
			_dispatcher = dispatcher;
			_action = action;
			_delay = delay;
		}

		public void Start()
		{
			if (_thread == null)
			{
				_thread = new Thread(() =>
				                     	{
				                     		while (true)
				                     		{
				                     			_dispatcher.Invoke(new Action(_action));
				                     			Thread.Sleep(_delay);
				                     		}
				                     	// ReSharper disable FunctionNeverReturns
				                     	}) {IsBackground = true};
										// ReSharper restore FunctionNeverReturns
				_thread.Start();
			}
		}

		public void Stop()
		{
			if (_thread != null)
			{
				_thread.Abort();
				_thread = null;
			}
		}
	}
}