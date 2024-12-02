using SocialNetworkApp.Domain.SeedWork;
using System.Security.Cryptography;
using System.Text;
using System;


namespace SocialNetworkApp.Domain.Models
{
    public class User : Entity
    {
        public string Username { get; set; }
        public bool IsAdmin { get; set; } = false;

        private string password;
        public string Password
        { 
            get => password; 
            set
            {
                var data = Encoding.UTF8.GetBytes(value);
                var HashData = new SHA1Managed().ComputeHash(data);
                password = BitConverter
                    .ToString(HashData)
                    .Replace("-", "".ToUpper());
            }
        }

        // Navigation Properties
        public virtual Profile Profile { get; set; }


        public User() { }
        public User(string username, string password, bool isAdmin)
        {
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
