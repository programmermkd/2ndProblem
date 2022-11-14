using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2ndProblemApp.Object;

namespace _2ndProblemApp.Contracts
{
    public interface IMockyService
    {
        Task<MockyResponse> GetMockyResponseAsync();
    }
}
