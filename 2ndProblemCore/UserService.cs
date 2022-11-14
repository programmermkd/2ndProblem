using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2ndProblemApp.Contracts;
using _2ndProblemApp.Object;

namespace _2ndProblemApp
{
    public class UserService : IUserService
    {
        private readonly IMockyService _cacheService;

        public UserService(IMockyService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<UserWithValidIdDTO?> GetUserAsync(int id)
        {
            var mockyResponse = await GetMockyResponseAsync();

            var user = mockyResponse.Data.Users.FirstOrDefault(x => x.Id != null && x.Id.Value == id);

            if (user == null)
            {
                return null;
            }

            return MapToUserWithValidIdDTO(user);
        }

        public async Task<List<UserWithValidIdDTO>> GetUserByIdWithGroupAsync(int id)
        {
            var mockyResponse = await GetMockyResponseAsync();

            if (mockyResponse.Numbers == null)
            {
                throw new Exception("Numbers not present in data.");
            }

            var numArrOfUser = mockyResponse.Numbers.FirstOrDefault(x => x.Contains(id));

            if (numArrOfUser == null)
            {
                numArrOfUser = new() { id };
            }

            return mockyResponse.Data.Users.Where(x => x.Id != null && numArrOfUser.Contains(x.Id))
                .Select(x => MapToUserWithValidIdDTO(x)).ToList();
        }

        private static UserWithValidIdDTO MapToUserWithValidIdDTO(UserModel x)
        {
            return new UserWithValidIdDTO { Id = x.Id.Value, FullName = $"{x.FirstName} {x.LastName}" };
        }

        public async Task<List<UserWithValidIdDTO>> GetUsersWithValidIdAsync()
        {
            MockyResponse mockyResponse = await GetMockyResponseAsync();

            return mockyResponse.Data.Users.Where(x => x.Id != null).Select(x => MapToUserWithValidIdDTO(x)).ToList();
        }

        private async Task<MockyResponse> GetMockyResponseAsync()
        {
            var mockyResponse = await _cacheService.GetMockyResponseAsync();

            if (mockyResponse.Data == null || mockyResponse.Data.Users == null)
            {
                throw new Exception("Invalid data.");
            }

            return mockyResponse;
        }
    }
}
