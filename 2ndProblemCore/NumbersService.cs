using _2ndProblemApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndProblemApp
{
    public class NumbersService : INumbersService
    {
        private readonly IMockyService _mockyService;

        public NumbersService(IMockyService mockyService)
        {
            _mockyService = mockyService;
        }

        public async Task<bool> AreDiagonalsEqualAsync()
        {
            var mockyResponse = await _mockyService.GetMockyResponseAsync();

            if (mockyResponse.Numbers == null)
            {
                throw new Exception("Number data not exist inside the mocky response");
            }

            if (!mockyResponse.Numbers.Any())
            {
                throw new Exception("Numbers matrix is empty inside the mocky response");
            }

            var nums = mockyResponse.Numbers;

            int sumDiagonal1 = 0;
            int sumDiagonal2 = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                sumDiagonal1 += nums[i][i] ?? 0;
                sumDiagonal2 += nums[nums.Count - i - 1][i] ?? 0;
            }

            return sumDiagonal1 == sumDiagonal2;
        }
    }
}
