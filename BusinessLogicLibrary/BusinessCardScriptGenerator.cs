using SqlTestTableDataGenerator.BusinessLogicLibrary;
using SqlTestTableDataGenerator.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.BusinessLogicLibrary
{
    public class BusinessCardScriptGenerator : ScriptGenerator<BusinessCard>
    {
        public BusinessCardScriptGenerator(IValueLineGenerator<BusinessCard> gen) : base(gen) { }

        public override string GenerateScript(int entityCount)
        {
            throw new NotImplementedException();
        }
    }
}
