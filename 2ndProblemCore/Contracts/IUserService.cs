using _2ndProblemApp.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2ndProblemApp.Contracts
{
    public interface IUserService
    {
        public Task<List<UserWithValidIdDTO>> GetUsersWithValidIdAsync();
        public Task<List<UserWithValidIdDTO>> GetUserByIdWithGroupAsync(int id);
        public Task<UserWithValidIdDTO> GetUserAsync(int id);
    }
}
