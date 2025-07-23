namespace AdminPanel.Domain.Enums
{
    public enum InnerStatusCode
    {
        EntityNotFound = 0,

        ClientCreate = 10,
        ClientUpdate = 20,
        ClientDelete = 30,
        ClientRead = 40,
        ClientExist = 50,

        ClientAuthenticate = 60,
        RefreshTokenUpdate = 1,

        PaymentCreate = 11,
        PaymentUpdate = 21,
        PaymentDelete = 31,
        PaymentRead = 41,
        PaymentExist = 51,

        RateCreate = 12,
        RateUpdate = 22,
        RateDelete = 32,
        RateRead = 42,
        RateExist = 52,


        OK = 200,
        OKNoContent = 204,
        InternalServerError = 500,
    }
}
