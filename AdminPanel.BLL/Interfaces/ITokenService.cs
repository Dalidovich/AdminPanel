using AdminPanel.Domain.Entities;

namespace AdminPanel.BLL.Interfaces
{
    public interface ITokenService
    {
        public string GetToken(Account client);
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPasswordHash(string Password, byte[] passwordHash, byte[] passwordSalt);
    }
}
