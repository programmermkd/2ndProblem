using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndProblemApp.Object
{
    public class MockyResponse
    {
        public class DataValue
        {
            public List<UserModel> Users { get; set; }
        }
        public DataValue Data { get; set; }
        public List<List<int?>> Numbers { get; set; }
    }
}
