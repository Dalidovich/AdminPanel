using AdminPanel.Domain.Enums;

namespace AdminPanel.BLL.DTO
{
    public class UpdateAccountStatusDTO
    {
        public Guid Id { get; set; }
        public AccountStatus NewStatus { get; set; }
    }
}
