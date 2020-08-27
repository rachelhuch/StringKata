using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorBlank
{
    public class Calculator
    {
        private ILogger _logger;
        private IWebService _webService;

        public Calculator(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int Add(string numbers)
        {
            int answer = 0;
            if (numbers.Contains(','))
            {
                answer = numbers.Split(',').Select(int.Parse).Sum();
            }
            else
            {
                answer = numbers == "" ? 0 : int.Parse(numbers);
            }
            try
            {
                _logger.Write(answer.ToString());
            }
            catch (LoggerException ex)
            {

                _webService.LoggingFailed(ex.Message);
            }
            
            return answer;
        }
    }
}
