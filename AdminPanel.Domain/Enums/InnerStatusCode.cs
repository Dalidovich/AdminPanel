namespace AdminPanel.Domain.Enums
{
    public enum InnerStatusCode
    {
        EntityNotFound = 0,

        AccountCreate = 10,
        AccountUpdate = 20,
        AccountDelete = 30,
        AccountRead = 40,
        AccountExist = 50,

        OK = 200,
        OKNoContent = 204,
        InternalServerError = 500,
    }
}
