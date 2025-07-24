using AdminPanel.Domain.Enums;

namespace AdminPanel.Domain.Entities
{
    public class Account
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public AccountStatus Status { get; set; }

        public Account()
        {
        }
    }
}
