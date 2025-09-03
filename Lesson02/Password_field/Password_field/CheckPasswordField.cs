using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_field
{
    
    public class CheckPasswordField(string password)
    {
        private readonly string _password = password;

        public void ValidatePassword()
        {
            if(string.IsNullOrEmpty(_password) || string.IsNullOrWhiteSpace(_password))
            {
                throw new ArgumentException("Password cannot be null or empty or whitespace");
            }
            if(_password.Length is <= 5 or > 10)
            {
                throw new ArgumentException("Password must be greater than 5 characters and less than or equal to 10 characters");
            }
        }

    }
}
