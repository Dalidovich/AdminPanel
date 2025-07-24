namespace AdminPanel.BLL.DTO
{
    public record AuthDTO
    {
        public string JWTToken { get; set; }
        public Guid AccountId { get; set; }

        public AuthDTO(string jWTToken, Guid accountId)
        {
            JWTToken = jWTToken;
            AccountId = accountId;
        }
    }
}
