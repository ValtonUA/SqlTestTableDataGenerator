using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.DataLibrary
{
    /// <summary>
    /// The <c>User</c> class is a POCO. It simulates some table in database (dbo.User).
    /// </summary>
    public class User
    {
        /// <value>Required, unique, min length is 6, max length is 20, contains only Eng letters and digits.</value>
        public string Login { get; set; }
        /// <value>Required, min length is 6, max length is 20, contains only Eng letters and digits.</value>
        public string Password { get; set; }
        /// <value>
        /// Required, min length is 10, max length is 30, contains only Eng letters and digits.
        /// Has a structure: {login}@{domain}.
        /// </value>
        /// <example>userlogin@test.com</example>
        public string Email { get; set; }
        /// <value>Required, min length is 2, max length is 20, contains only Eng letters.</value>
        public string Name { get; set; }
        /// <value>Required, min length is 2, max length is 20, contains only Eng letters.</value>
        public string Surname { get; set; }
        /// <value>Min length is 2, max length is 20, contains only Eng letters.</value>
        public string Patronymic { get; set; }
        /// <value>Required, min value is 18, max value is 99.</value>
        public int Age { get; set; }
        /// <value>Required, has a structure: yyyyMMdd</value>
        /// <example>20160211</example>
        public string RegistrationDate { get; set; }
    }
}
