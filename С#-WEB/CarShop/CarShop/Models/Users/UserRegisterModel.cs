namespace CarShop.Models.Users
{
    //username: Gosho12
    //email: petar741012 @gmail.com
    //password: 1234567
    //confirmPassword: 1234567
    //userType: Client
    public class UserRegisterModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string UserType { get; set; }
    }
}
