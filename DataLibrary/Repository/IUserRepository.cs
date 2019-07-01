using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.DataLibrary
{
    /// <summary>
    /// The <c>IUserRepository</c> interface contains all required methods
    /// for generating value lines by <c>IValueLineGenerator<User></c> interface.
    /// Some props cannot be generated randomly (they require some extra logic).
    /// </summary>
    /// <remarks>
    /// All the methods obtain data fron external source (textfile, 
    /// database, server), handle it and put into a list.
    /// </remarks>
    public interface IUserRepository
    {
        List<string> GetUniqueLogins();
        List<string> GetNames();
        List<string> GetSurnames();
        List<string> GetPatronymics();
    }
}
