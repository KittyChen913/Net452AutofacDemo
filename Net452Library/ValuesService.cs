using System.Collections.Generic;
using Utility.Logging;

namespace Net452Library
{
    public class ValuesService : IValuesService
    {
        private readonly ILogger logger;

        public ValuesService(ILogger logger)
        {
            this.logger = logger;
        }

        public List<string> GetValueList()
        {
            logger.Info("Start GetValueList()");
            return new List<string> { "value1", "value2" };
        }
    }
}
