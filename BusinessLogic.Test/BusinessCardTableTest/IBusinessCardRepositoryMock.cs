using SqlTestTableDataGenerator.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.Test
{
    public class IBusinessCardRepositoryMock : IBusinessCardRepository
    {
        public List<string> GetTitles()
        {
            return new List<string> { "TestTitle", "NextTitle", "NewTitle" };
        }
    }
}
