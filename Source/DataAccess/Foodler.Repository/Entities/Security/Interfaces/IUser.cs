using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Security.Interfaces
{
    public interface IUser
    {
        IUser SetEmail(string email);
        IUser SetName(string name);
        IUser SetPassword(string password);
    }
}
