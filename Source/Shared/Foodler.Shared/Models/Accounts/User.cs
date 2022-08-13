using Foodler.Shared.Models.Bases;

namespace Foodler.Shared.Models.Accounts
{
    public class User : ModelBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
