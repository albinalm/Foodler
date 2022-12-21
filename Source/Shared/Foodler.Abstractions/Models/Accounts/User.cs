using Foodler.Abstractions.Models.Bases;

namespace Foodler.Abstractions.Models.Accounts
{
    public class User : ModelBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
