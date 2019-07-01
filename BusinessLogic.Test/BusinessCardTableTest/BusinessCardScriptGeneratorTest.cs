using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlTestTableDataGenerator.BusinessLogicLibrary;
using SqlTestTableDataGenerator.DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.Test
{
    [TestClass]
    public class BusinessCardScriptGeneratorTest
    {
        IScriptGenerator<BusinessCard> generator;
        const int TEST_REPEAT_TIMES = 5;

        [TestInitialize]
        public void Setup()
        {
            generator = new ScriptGenerator<BusinessCard>(new BusinessCardValueLineGeneratorMock());
        }

        [TestMethod]
        public void GenerateScript_ReturnsCorrectResult()
        {
            string EXPECTED_RESULT = "INSERT INTO dbo.BusinessCard VALUES " + Environment.NewLine +
                "('Value1', 'Value2')," + Environment.NewLine +
                "('Value1', 'Value2')," + Environment.NewLine +
                "('Value1', 'Value2')" + Environment.NewLine;

            var result = generator.GenerateScript(3);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }
    }
}
