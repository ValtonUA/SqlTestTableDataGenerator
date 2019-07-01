using SqlTestTableDataGenerator.DataLibrary;
using System;
using Autofac;
using SqlTestTableDataGenerator.BusinessLogicLibrary;

namespace SqlTestTableDataGenerator.MainProject
{

    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<UserTextFileRepository>().As<IUserRepository>();
            builder.RegisterType<UserValueLineGenerator>().As<IValueLineGenerator<User>>();
            builder.RegisterType<ScriptGenerator<User>>().As<IScriptGenerator<User>>();
            builder.RegisterType<BusinessCardTextFileRepository>().As<IBusinessCardRepository>();
            builder.RegisterType<BusinessCardValueLineGenerator>().As<IValueLineGenerator<BusinessCard>>();
            builder.RegisterType<ScriptGenerator<BusinessCard>>().As<IScriptGenerator<BusinessCard>>();

            IContainer container = builder.Build();

            IScriptGenerator<User> userScriptGen = container.Resolve<IScriptGenerator<User>>();
            IScriptGenerator<BusinessCard> cardScriptGen = container.Resolve<IScriptGenerator<BusinessCard>>();

            Console.WriteLine("Generated entity model and value line for User class: ");
            var user = userScriptGen.GetEntityModel();
            Console.WriteLine(userScriptGen.GetValueLine(user));

            Console.WriteLine("Generated script for User class: ");
            Console.WriteLine(userScriptGen.GenerateScript(20));

            Console.WriteLine("//////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////");

            Console.WriteLine("Generated entity model and value line for BusinessCard class: ");
            var card = cardScriptGen.GetEntityModel();
            Console.WriteLine(cardScriptGen.GetValueLine(card));

            Console.WriteLine("Generated script for User class: ");
            Console.WriteLine(cardScriptGen.GenerateScript(20));

            Console.ReadKey();
        }
    }
}
