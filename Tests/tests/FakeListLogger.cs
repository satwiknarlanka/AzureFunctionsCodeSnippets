using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace tests
{
    public class FakeListLogger : ILogger
    {
        public IList<string> Logs;
        public FakeListLogger()
        {
            this.Logs = new List<string>();
        }
        public IDisposable BeginScope<TState>(TState state)=> new NoopDisposable();

        public bool IsEnabled(LogLevel logLevel)=> false;

        public void Log<TState>(LogLevel logLevel,
                            EventId eventId,
                            TState state,
                            Exception exception,
                            Func<TState, Exception, string> formatter)
        {
            string message = formatter(state, exception);
            this.Logs.Add(message);
        }
        private class NoopDisposable : IDisposable
        {
            public void Dispose(){}
        }
    }
}
