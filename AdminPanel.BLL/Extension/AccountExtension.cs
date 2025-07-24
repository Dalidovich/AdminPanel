using AdminPanel.BLL.DTO;
using AdminPanel.Domain.Entities;

namespace AdminPanel.BLL.Extension
{
    public static class AccountExtension
    {
        public static Account Create(this Account account, AccountDTO accountDTO, string salt, string hash)
        {
            account.Name = accountDTO.Name;
            account.Email = accountDTO.Email;
            account.Password = hash;
            account.Salt = salt;
            account.Status = 0;

            return account;
        }
    }
}
