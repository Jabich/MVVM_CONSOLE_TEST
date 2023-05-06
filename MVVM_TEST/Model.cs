using System.Timers;

namespace MVVM_TEST
{
    public class Model
    {
        private System.Timers.Timer _timer;
        public event Action<DateTime> TimeChanged;
        public Model()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }

        private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
        {
            TimeChanged.Invoke(e.SignalTime);
        }
    }
}