using System.Windows;

namespace StopWatch
{
	internal partial class MainWindow : Window
	{
		private readonly StopWatchObject _watch = new StopWatchObject();
		private readonly UpdaterThread _updater;

		public MainWindow()
		{
			InitializeComponent();
			_updater = new UpdaterThread(Dispatcher, UpdateTime, 9);
			UpdateTime();
		}

		private void StartButtonClick(object sender, RoutedEventArgs e)
		{
			_watch.Start();
			ButtonGroupA.Visibility = Visibility.Collapsed;
			ButtonGroupB.Visibility = Visibility.Visible;
			_updater.Start();
		}

		private void ContinueButtonClick(object sender, RoutedEventArgs e)
		{
			_watch.Continue();
			ButtonGroupA.Visibility = Visibility.Collapsed;
			ButtonGroupB.Visibility = Visibility.Visible;
			_updater.Start();
		}

		private void ResetButtonClick(object sender, RoutedEventArgs e)
		{
			_watch.Reset();
			ContinueButton.IsEnabled = false;
			ResetButton.IsEnabled = false;
			UpdateTime();
		}

		private void StopButtonClick(object sender, RoutedEventArgs e)
		{
			_watch.Stop();
			ButtonGroupA.Visibility = Visibility.Visible;
			ButtonGroupB.Visibility = Visibility.Collapsed;
			ContinueButton.IsEnabled = true;
			ResetButton.IsEnabled = true;
			_updater.Stop();
			UpdateTime();
		}

		private void UpdateTime()
		{
			TimeBox.Text = _watch.ToString();
		}
	}
}