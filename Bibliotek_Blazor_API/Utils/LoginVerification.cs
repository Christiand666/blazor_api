using Bibliotek_Blazor_API.Data;
using Bibliotek_Blazor_API.Models;
using System.Linq;

namespace Bibliotek_Blazor_API.Utils
{
    public class LoginVerification
    {
        private readonly BibliotekContext _db;

        public LoginVerification(BibliotekContext db)
        {
            _db = db;
        }

        public bool VerifyUserToken(UserToken userToken)
        {
            bool userTokenExists = _db.UserToken.Any<UserToken>(ut => ut.UserId == userToken.UserId && ut.LoginGuid == userToken.LoginGuid);

            return userTokenExists;
        }
    }
}
