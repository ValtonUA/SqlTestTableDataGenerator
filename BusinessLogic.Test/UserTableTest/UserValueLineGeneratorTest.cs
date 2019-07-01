using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using SqlTestTableDataGenerator.DataLibrary;
using SqlTestTableDataGenerator.BusinessLogicLibrary;
using BusinessLogicLibrary.Test;

namespace BusinessLogicLibrary.Test
{
    [TestClass]
    public class UserValueLineGeneratorTest
    {
        IValueLineGenerator<User> generator;
        const int TEST_REPEAT_TIMES = 500;
        bool isTestPassed;

        [TestInitialize]
        public void Setup()
        {
            generator = new UserValueLineGenerator(new IUserRepositoryMock());
            isTestPassed = true;
        }
        #region LoginValidation
        [TestMethod]
        public void GenerateEntityModel_LoginRequired()
        {
            string login;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                login = generator.GenerateEntityModel().Login;
                if (String.IsNullOrEmpty(login))
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_LoginUnique()
        {
            SortedSet<string> list = new SortedSet<string>();

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                // Returns false if it`s a duplicate
                isTestPassed = list.Add(generator.GenerateEntityModel().Login);
                if (isTestPassed == false)
                {
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_LoginMinAndMaxRanges_MinIs6MaxIs20()
        {
            string login;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                login = generator.GenerateEntityModel().Login;
                if (login.Length < 6 || login.Length > 20)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_LoginSymbols_OnlyLettersAndDigits()
        {
            string login;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                login = generator.GenerateEntityModel().Login;
                
                if (AuxiliaryMethods.IsDigitsOrLettersOnly(login) == false)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }
        #endregion
        #region PasswordValidation
        [TestMethod]
        public void GenerateEntityModel_PasswordRequired()
        {
            string password;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                password = generator.GenerateEntityModel().Password;
                if (String.IsNullOrEmpty(password))
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_PasswordMinAndMaxRanges_MinIs6MaxIs20()
        {
            string password;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                password = generator.GenerateEntityModel().Password;
                if (password.Length < 6 || password.Length > 20)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_PasswordSymbols_OnlyLettersAndDigits()
        {
            string password;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                password = generator.GenerateEntityModel().Password;
                
                if (AuxiliaryMethods.IsDigitsOrLettersOnly(password) == false)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }
        #endregion
        #region EmailValidation
        [TestMethod]
        public void GenerateEntityModel_EmailRequired()
        {
            string email;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                email = generator.GenerateEntityModel().Email;
                if (String.IsNullOrEmpty(email))
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_EmailUnique()
        {
            SortedSet<string> list = new SortedSet<string>();

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                // Returns false if it`s a duplicate
                isTestPassed = list.Add(generator.GenerateEntityModel().Email);
                if (isTestPassed == false)
                {
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_EmailMinAndMaxRanges_MinIs10MaxIs50()
        {
            string email;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                email = generator.GenerateEntityModel().Email;
                if (email.Length < 10 || email.Length > 50)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_EmailHasRightStructure()
        {
            User user;
            string[] emailParts;
            string[] domainParts;
            // Email structure: {Login}@{domainName}.{domainRemainder}
            // Example test@gmail.com
            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                user = generator.GenerateEntityModel();
                emailParts = user.Email.Split('@');
                if (emailParts.Length != 2)
                {
                    isTestPassed = false;
                    break;
                }
                else if (emailParts[0].Equals(user.Login) == false)
                {
                    isTestPassed = false;
                    break;
                }
                // Split domain
                domainParts = emailParts[1].Split('.');

                if (domainParts.Length != 2)
                {
                    isTestPassed = false;
                    break;
                }
                else if (domainParts[0].Length < 2 || domainParts[1].Length < 2)
                {
                    isTestPassed = false;
                    break;
                }
                else if (AuxiliaryMethods.IsLettersOnly(domainParts[0]) == false)
                {
                    isTestPassed = false;
                    break;
                }
                else if (AuxiliaryMethods.IsLettersOnly(domainParts[1]) == false)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }
        #endregion
        #region NameValidation
        [TestMethod]
        public void GenerateEntityModel_NameRequired()
        {
            string name;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                name = generator.GenerateEntityModel().Name;
                if (String.IsNullOrEmpty(name))
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_NameMinAndMaxRanges_MinIs2MaxIs20()
        {
            string name;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                name = generator.GenerateEntityModel().Name;
                if (name.Length < 2 || name.Length > 20)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_NameSymbols_OnlyLetters()
        {
            string name;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                name = generator.GenerateEntityModel().Name;
                
                if (AuxiliaryMethods.IsLettersOnly(name) == false)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }
        #endregion
        #region SurnameValidation
        [TestMethod]
        public void GenerateEntityModel_SurnameRequired()
        {
            string surname;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                surname = generator.GenerateEntityModel().Surname;
                if (String.IsNullOrEmpty(surname))
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_SurnameMinAndMaxRanges_MinIs2MaxIs20()
        {
            string surname;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                surname = generator.GenerateEntityModel().Surname;
                if (surname.Length < 2 || surname.Length > 20)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_SurnameSymbols_OnlyLetters()
        {
            string surname;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                surname = generator.GenerateEntityModel().Surname;
                
                if (AuxiliaryMethods.IsLettersOnly(surname) == false)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }
        #endregion
        #region PatronymicValidation
        [TestMethod]
        public void GenerateEntityModel_PatronymicMinAndMaxRanges_MinIs2MaxIs20()
        {
            string patronymic;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                patronymic = generator.GenerateEntityModel().Patronymic;
                if (string.IsNullOrEmpty(patronymic)) // can be empty
                {
                    break;
                }
                if (patronymic.Length < 2 || patronymic.Length > 20)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_PatronymicSymbols_OnlyLetters()
        {
            string patronymic;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                patronymic = generator.GenerateEntityModel().Patronymic;
                
                if (AuxiliaryMethods.IsLettersOnly(patronymic) == false)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }
        #endregion
        #region AgeValidation
        public void GenerateEntityModel_AgeMinAndMaxRanges_MinIs18MaxIs99()
        {
            int age;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                age = generator.GenerateEntityModel().Age;
                if (age < 18 || age > 99)
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }
        #endregion
        #region RegistrationDateValidation
        [TestMethod]
        public void GenerateEntityModel_RegistrationDateRequired()
        {
            string registrationDate;

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            {
                registrationDate = generator.GenerateEntityModel().RegistrationDate;
                if (String.IsNullOrEmpty(registrationDate))
                {
                    isTestPassed = false;
                    break;
                }
            }

            Assert.IsTrue(isTestPassed);
        }

        [TestMethod]
        public void GenerateEntityModel_RegistrationDateMinAndMaxRanges_MinIs20150101MaxIs20190601()
        {
            DateTime registrationDate;
            DateTime startDate = new DateTime(2015, 01, 01);
            DateTime endTime = new DateTime(2019, 06, 01);

            for (int i = 0; i < TEST_REPEAT_TIMES; i++)
            { 
                registrationDate = DateTime.ParseExact(
                    generator.GenerateEntityModel().RegistrationDate,
                    "yyyyMMdd",
                    null);
                if (registrationDate < startDate || registrationDate > endTime)
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
            User user = new User
            {
                Login = "TestLogin",
                Password = "TestPassword",
                Email = "TestLogin@gmail.com",
                Name = "TestName",
                Surname = "TestSurname",
                Patronymic = "",
                Age = 18,
                RegistrationDate = "20150101"
            };
            const string EXPECTED_RESULT = "('TestLogin', 'TestPassword', 'TestLogin@gmail.com', " +
                "'TestName', 'TestSurname', '', 18, '20150101')";

            string result = generator.GenerateValueLine(user);

            Assert.AreEqual(EXPECTED_RESULT, result);
        }

        
    }
}
