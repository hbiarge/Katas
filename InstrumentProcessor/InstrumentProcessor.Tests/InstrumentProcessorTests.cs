using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace InstrumentProcessor.Tests
{
    public class InstrumentProcessorTests: IDisposable
    {
        private readonly InstrumentProcessor _sut;

        private readonly Mock<ITaskDispatcher> _taskDispatcherMock;
        private readonly Mock<IInstrument> _instrumentMock;

        public InstrumentProcessorTests()
        {
            _taskDispatcherMock = new Mock<ITaskDispatcher>();
            _instrumentMock = new Mock<IInstrument>();
            _sut = new InstrumentProcessor(
                _taskDispatcherMock.Object,
                _instrumentMock.Object);
        }

        [Fact]
        public void Process_will_throw_if_an_null_task_is_passed()
        {
            _taskDispatcherMock
                .Setup(x => x.GetTask())
                .Returns((string)null);
            _instrumentMock
                .Setup(x => x.Execute(null))
                .Throws<ArgumentNullException>();

            Action action = () => _sut.Process();

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Process_a_task_without_error()
        {
            const string taskName = "Task";
            _taskDispatcherMock
                .Setup(x => x.GetTask())
                .Returns(taskName);

            _sut.Process();

            _instrumentMock.Raise(x => x.Finished += null, new EventArgs());

            _instrumentMock.Verify(x => x.Execute(taskName), Times.Once);
            _taskDispatcherMock.Verify(x => x.FinishedTask(taskName), Times.Once);
        }

        [Fact]
        public void Process_a_task_with_error()
        {
            const string taskName = "Task";
            _taskDispatcherMock
                .Setup(x => x.GetTask())
                .Returns(taskName);

            _sut.Process();

            _instrumentMock.Raise(x => x.Error += null, new EventArgs());

            _instrumentMock.Verify(x => x.Execute(taskName), Times.Once);
            _taskDispatcherMock.Verify(x => x.FinishedTask(taskName), Times.Never);
        }

        public void Dispose()
        {
            _sut.Dispose();
        }
    }
}
