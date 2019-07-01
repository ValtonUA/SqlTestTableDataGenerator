using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.BusinessLogicLibrary
{
    /// <summary>
    /// The <c>IValueLineGenerator</c> interface is a part of the <c>ScriptGenerator</c>
    /// class. Although, It can be used separately.
    /// </summary>
    /// <typeparam name="T">One of the model class types.</typeparam>
    public interface IValueLineGenerator<T>
    {
        /// <summary>
        /// The method is used when creating a new script is started.
        /// Refresh indexes of unique props, etc.
        /// </summary>
        void Init();

        /// <summary>
        /// The method creates an entity model and fills it with random generated values
        /// (depends on property requirments like unique, min and max length, ranges, etc).
        /// </summary>
        /// <returns>One of the model class objects filled with random generated values.</returns>
        T GenerateEntityModel();

        /// <summary>
        /// The method generates a value line for insert script based on passed entity model.
        /// </summary>
        /// <param name="entity">One of the model class objects.</param>
        /// <returns>Generated value line based on entity model.</returns>
        string GenerateValueLine(T entity);

        /// <returns>Header line of insert script.</returns>
        string GetInsertLine();
    }
}
