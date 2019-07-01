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
    public class BusinessCardValueLineGeneratorTest
    {
        IValueLineGenerator<BusinessCard> generator;
        const int TEST_REPEAT_TIMES = 500;
        bool isTestPassed;

        [TestInitialize]
        public void Setup()
        {
            generator = new BusinessCardValueLineGenerator(new IBusinessCardRepositoryMock());
            isTestPassed = true;
        }

        #region CardIdValidation
        [TestMethod]
        public void GenerateEntityModel_CardIdUnique()
        {
            SortedSet<int> list = new SortedSet<int>();

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                isTestPassed = list.Add(generator.GenerateEntityModel().CardId);
                if (isTestPassed == false)
                {
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }
        #endregion
        #region TitleValidation
        [TestMethod]
        public void GenerateEntityModel_TitleRequired()
        {
            string title;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                title = generator.GenerateEntityModel().Title;
                if (String.IsNullOrEmpty(title))
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_TitleMinAndMaxRanges_MinIs6MaxIs30()
        {
            string title;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                title = generator.GenerateEntityModel().Title;
                if (title.Length < 6 || title.Length > 30)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_TitleSymbols_OnlyLettersAndDigits()
        {
            string title;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                title = generator.GenerateEntityModel().Title;

                if (AuxiliaryMethods.IsDigitsOrLettersOnly(title) == false)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }
        #endregion
        #region PhoneNumberValidation
        [TestMethod]
        public void GenerateEntityModel_PhoneNumberRequired()
        {
            string phoneNumber;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                phoneNumber = generator.GenerateEntityModel().PhoneNumber;
                if (String.IsNullOrEmpty(phoneNumber))
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_PhoneNumberMinAndMaxRanges_MinIs10MaxIs12()
        {
            string phoneNumber;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                phoneNumber = generator.GenerateEntityModel().PhoneNumber;
                if (phoneNumber.Length < 10 || phoneNumber.Length > 12)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_PhoneNumber_HasOnlyDigits()
        {
            string phoneNumber;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                phoneNumber = generator.GenerateEntityModel().PhoneNumber;
                if (AuxiliaryMethods.IsDigitsOnly(phoneNumber) == false)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }
        #endregion

        [TestMethod]
        public void GenerateValueLine_ReturnsCorrectValueLine()
        {
            BusinessCard card = new BusinessCard
            {
                CardId = 0,
                Title = "TestTitle",
                PhoneNumber = "0123456789"
            };
            const string EXPECTED_RESULT = "(0, 'TestTitle', '0123456789')";

            string result = generator.GenerateValueLine(card);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }
    }
}
