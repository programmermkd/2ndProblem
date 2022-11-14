using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndProblemApp.Contracts
{
    public interface INumbersService
    {
        public Task<bool> AreDiagonalsEqualAsync();
    }
}
