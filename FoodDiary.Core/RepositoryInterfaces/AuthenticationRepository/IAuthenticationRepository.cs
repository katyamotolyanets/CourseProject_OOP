using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.RepositoryIntarfaces.AuthenticationRepository
{
    public interface IAuthenticationRepository
    {
        User Login(string username, string password);
    }
}
