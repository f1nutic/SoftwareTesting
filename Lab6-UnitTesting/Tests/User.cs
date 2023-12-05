namespace Tests
{
    public class User
    {
        private static int _id;

        public int id;
        public string login;
        public string password;
        public bool isBlocked;

        public User(string login, string password, bool isBlocked)
        {
            this.login = login;
            this.password = password;
            this.isBlocked = isBlocked;
            id = _id;
            _id++;
        }
    }
}
