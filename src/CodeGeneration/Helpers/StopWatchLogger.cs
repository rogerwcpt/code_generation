using System;
using System.Diagnostics;

namespace CodeGeneration.Helpers
{
    public class StopWatchLogger: IDisposable
    {
        private readonly string _message;
        private readonly Stopwatch _stopWatch;

        public StopWatchLogger(string message = null)
        {
            _message = message ?? "Time Taken (ms): ";
            _stopWatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _stopWatch.Stop();
            var timeTaken = _stopWatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(_message + $"{timeTaken}");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}