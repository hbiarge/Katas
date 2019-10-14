using System;

namespace InstrumentProcessor
{
    public sealed class InstrumentProcessor : IInstrumentProcessor, IDisposable
    {
        private readonly ITaskDispatcher _taskDispatcher;
        private readonly IInstrument _instrument;

        private string _currentTask;

        public InstrumentProcessor(ITaskDispatcher taskDispatcher, IInstrument instrument)
        {
            _taskDispatcher = taskDispatcher;
            _instrument = instrument;

            _instrument.Finished += InstrumentOnFinished;
            _instrument.Error += InstrumentOnError;
        }

        public void Process()
        {
            if (_currentTask is null == false)
            {
                throw new InvalidOperationException("The instrument is already executing a task");
            }

            _currentTask = _taskDispatcher.GetTask();
            _instrument.Execute(_currentTask);
        }

        public void Dispose()
        {
            _instrument.Finished -= InstrumentOnFinished;
            _instrument.Error -= InstrumentOnError;
        }

        private void InstrumentOnFinished(object sender, EventArgs e)
        {
            _taskDispatcher.FinishedTask(_currentTask);
            _currentTask = null;
        }

        private void InstrumentOnError(object sender, EventArgs e)
        {
            // Log an error
            _currentTask = null;
        }
    }
}