using NLog;
using System.Collections.Generic;

namespace Net452Library
{
    public class ValuesService : IValuesService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ValuesService()
        {
        }

        public List<string> GetValueList()
        {
            logger.Info("Start GetValueList()");
            return new List<string> { "value1", "value2" };
        }
    }
}
