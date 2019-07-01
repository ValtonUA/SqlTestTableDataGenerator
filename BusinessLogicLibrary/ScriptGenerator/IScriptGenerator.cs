namespace SqlTestTableDataGenerator.BusinessLogicLibrary
{
    /// <summary>
    /// The <c>IScriptGenerator</c> interface provides method for creating
    /// insert scripts for database tables.
    /// </summary>
    /// <typeparam name="T">One of the model class types.</typeparam>
    public interface IScriptGenerator<T>
    {
        /// <summary>
        /// Generates insert script with specified number of value lines by appending 
        /// insert line and all the value lines to one string.
        /// </summary>
        /// <param name="entityCount">Number of value lines in script.</param>
        /// <returns>Insert script for specified table.</returns>
        string GenerateScript(int entityCount);

        /// <summary>
        /// The method creates an entity model and fills it with random generated values
        /// (depends on property requirments like unique, min and max length, ranges, etc).
        /// </summary>
        /// <returns>One of the model class objects filled with random generated values.</returns>
        T GetEntityModel();

        /// <summary>
        /// Generates header line for insert script.
        /// </summary>
        /// <returns>Header line for insert script.</returns>
        /// <example>INSERT INTO dbo.SomeTable VALUES </example>
        string GetInsertLine();

        /// <summary>
        /// Generates value line for insert script based on passed parameter.
        /// </summary>
        /// <param name="entity">One of the model class objects.</param>
        /// <returns>Value line based on entity object.</returns>
        string GetValueLine(T entity);
    }
}