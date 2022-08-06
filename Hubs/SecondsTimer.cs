using System.Timers;



namespace chat.Hubs
{
    public class SecondsTimer
    {
        public delegate void Callback();

        public int Seconds { get; set; }
        private System.Timers.Timer aTimer;
        private Callback onFinish;
        private Callback? onTick = null;

        public SecondsTimer(int seconds, Callback onFinish)
        {
            Seconds = seconds;
            this.onFinish = onFinish;
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public SecondsTimer(int seconds, Callback onFinish, Callback onTick)
        {
            Seconds = seconds;
            this.onFinish = onFinish;
            this.onTick = onTick;
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            this.Seconds--;
            if (this.Seconds <= 0) {
                aTimer.Stop();
                aTimer.Dispose();
                onFinish();
                return; 
            }
            
            if (onTick != null)
            {
                onTick();
            }

        }

    }
}
