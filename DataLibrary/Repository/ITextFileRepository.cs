using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.DataLibrary
{
    /// <summary>
    /// The <c>ITextFileRepository</c> interface has been created to follow DRY attitude.
    /// It includes a method, that opens a file, handles it and forms a list with props.
    /// </summary>
    public interface ITextFileRepository
    {
        /// <summary>
        /// The <c>GenerateList</c> function handles all the symbols from the file (skips waste symbols),
        /// repeatedly forming one of the model class property, and adds to a list by special condition.
        /// </summary>
        /// <param name="filename">Name of the file contains required data.</param>
        /// <param name="handleCondition">Specifies the condition to add a symbol to a property string.</param>
        /// <param name="addCondition">Specifies the condition to add a formed property to a list.</param>
        /// <param name="isUnique">Specifies whether a result list should contains unique props.</param>
        /// <example>For <c>User</c> class this method can form a list of logins or a list of names.</example>
        /// <returns>A list of strings, where string - one of the model class property.</returns>
        /// <remarks>Result list shouldn`t contains different properties, only one of them.</remarks>
        List<string> GenerateList(string filename,
            Func<char, bool> handleCondition,
            Func<string, bool> addCondition,
            bool isUnique = false);
    }
}
