namespace MillionAndUp.BL.V1.Services.Security
{
    public interface IUserService
    {
        public bool CredentialsValidation(string email, string pass);
    }
}
