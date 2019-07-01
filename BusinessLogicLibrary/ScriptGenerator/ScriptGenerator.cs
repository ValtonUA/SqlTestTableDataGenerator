using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.BusinessLogicLibrary
{
    /// <summary>
    /// The <c>ScriptGenerator</c> class generates an insert script with
    /// specified number of value lines for concrete table. The table is
    /// presented by a model class.
    /// </summary>
    /// <remarks>
    /// The class requires one of the implementations of the auxiliary
    /// <c>IValueLineGenerator</c> interface.
    /// </remarks>
    /// <typeparam name="T">One of the model class types.</typeparam>
    public class ScriptGenerator<T> : IScriptGenerator<T>
    {
        IValueLineGenerator<T> valueLineGenerator;

        public ScriptGenerator(IValueLineGenerator<T> generator)
        {
            valueLineGenerator = generator;
        }

        /// <returns>Entity model filled with random generated values.</returns>
        public T GetEntityModel()
        {
            return valueLineGenerator.GenerateEntityModel();
        }


        /// <returns>Value line for insert script.</returns>
        /// <example>('Login', 'Password', 'Name')</example>
        public string GetValueLine(T entity)
        {
            return valueLineGenerator.GenerateValueLine(entity);
        }
        /// <returns>Header line for insert script.</returns>
        public string GetInsertLine()
        {
            return valueLineGenerator.GetInsertLine();
        }

        /// <summary>
        /// The method says <IValueLineGenerator> about generating a new script.
        /// </summary>
        protected void Init()
        {
            valueLineGenerator.Init();
        }

        /// <returns>Insert script with specified number of value lines.</returns>
        public string GenerateScript(int entityCount)
        {
            StringBuilder script = new StringBuilder(GetInsertLine() + Environment.NewLine);
            T entity;
            string valueLine;

            Init();

            if (entityCount < 1)
            {
                return null;
            }

            for (int i = 0; i < entityCount - 1; i++)
            {
                entity = GetEntityModel();
                valueLine = GetValueLine(entity);

                script.Append($"{valueLine},{Environment.NewLine}");
            }
            entity = GetEntityModel();
            valueLine = GetValueLine(entity);
            script.Append($"{valueLine}{Environment.NewLine}"); // last lane without comma

            return script.ToString();
        }
    }
}
