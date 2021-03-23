namespace P01.Chronometer
{
    using System.Diagnostics;
    using System.Collections.Generic;

    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;
        private readonly List<string> laps;

        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
            this.laps = new List<string>();
        }

        public string GetTime => $"{this.stopwatch.Elapsed.Minutes:D2}:{this.stopwatch.Elapsed.Seconds:D2}:{this.stopwatch.Elapsed.Milliseconds:D4}";

        public List<string> Laps => this.laps;

        public string Lap()
        {
            var lap = this.GetTime;

            this.laps.Add(lap);

            return lap;
        }

        public void Reset()
        {
            this.stopwatch = new Stopwatch();
            this.laps.Clear();
        }

        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }
    }
}
