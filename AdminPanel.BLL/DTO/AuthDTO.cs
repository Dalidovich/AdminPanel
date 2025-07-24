namespace AdminPanel.BLL.DTO
{
    public record AuthDTO
    {
        public string JWTToken { get; set; }
        public Guid ClientId { get; set; }

        public AuthDTO(string jWTToken, Guid clientId)
        {
            JWTToken = jWTToken;
            ClientId = clientId;
        }
    }
}
