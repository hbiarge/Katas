using System;

namespace InstrumentProcessor
{
    public interface ITaskDispatcher
    {
        string GetTask();
        void FinishedTask(string task);
    }

    public interface IInstrument
    {
        void Execute(string task);

        event EventHandler Finished;
        event EventHandler Error;
    }

    public interface IInstrumentProcessor
    {
        void Process();
    }
}
