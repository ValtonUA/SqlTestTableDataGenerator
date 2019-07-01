using SqlTestTableDataGenerator.BusinessLogicLibrary;
using SqlTestTableDataGenerator.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.BusinessLogicLibrary
{
    /// <summary>
    /// The <c>UserScriptGenerator</c> class generates an insert script with
    /// specified number of value lines for dbo.User table. The table is
    /// presented by <c>User</c> class.
    /// </summary>
    public class UserScriptGenerator : ScriptGenerator<User>
    {
        public UserScriptGenerator (IValueLineGenerator<User> gen) :base(gen) { }

        public override string GenerateScript(int entityCount)
        {
            StringBuilder script = new StringBuilder(GetInsertLine() + Environment.NewLine);
            User user;
            string valueLine;

            Init();

            if (entityCount < 1)
            {
                return null;
            }

            for (int i = 0; i < entityCount - 1; i++)
            {
                user = GetEntityModel();
                valueLine = GetValueLine(user);

                script.Append($"{valueLine},{Environment.NewLine}");
            }
            user = GetEntityModel();
            valueLine = GetValueLine(user);
            script.Append($"{valueLine}{Environment.NewLine}"); // last lane without comma

            return script.ToString();
        }
    }
}
