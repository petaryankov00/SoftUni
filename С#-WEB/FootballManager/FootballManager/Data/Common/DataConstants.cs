namespace FootballManager.Data.Common
{
    public class DataConstants
    {
        public const string ConnectionString = @"Server=MPC-1\SQLEXPRESS;Database=FootballManager;User Id=sa;Password=1916;";

        public class User
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 20;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;

        }

        public class Player
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 80;

            public const int PositionMinLength = 5;
            public const int PositionMaxLength = 20;

            public const int DescriptionMaxLength = 200;

        }
    }
}
