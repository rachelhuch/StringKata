

using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StringCalculatorBlank
{

    public class CalculatorInteractionsShould
    {

        
        [Theory]
        [InlineData("1,2", "3")]
        [InlineData("1,2,3,4,5,6,7,8,9", "45")]
        public void AnswersAreLogged(string numbers, string expected)
        {
            var loggerMock = new Mock<ILogger>();
            var calculator = new Calculator(loggerMock.Object, new Mock<IWebService>().Object) ;
            calculator.Add(numbers);

            loggerMock.Verify(b => b.Write(expected));
        }

        [Theory]
        [InlineData("blammo")]
        [InlineData("that gum you like is going to come back into style")]
        public void CallTheWebServiceIfTheLoggerThrows(string message)
        {
            var stubbedLogger = new Mock<ILogger>();
            stubbedLogger.Setup(a => a.Write(It.IsAny<string>())).Throws(new LoggerException(message));
            var mockedWebService = new Mock<IWebService>();
            var calculator = new Calculator(stubbedLogger.Object, mockedWebService.Object);

            calculator.Add("99");

            mockedWebService.Verify(m => m.LoggingFailed(message));

        }

        [Fact]
        public void ShouldNotCallWebServiceIfNoException()
        {
            var mockedWebService = new Mock<IWebService>();
            var calculator = new Calculator(new Mock<ILogger>().Object, mockedWebService.Object);

            calculator.Add("12");

            mockedWebService.Verify(m => m.LoggingFailed(It.IsAny<string>()), Times.Never);
        }

    }
}
