using System.Collections.Generic;

namespace Net452Library
{
    public class ValuesService : IValuesService
    {
        public ValuesService()
        {
        }

        public List<string> GetValueList()
        {
            return new List<string> { "value1", "value2" };
        }
    }
}
