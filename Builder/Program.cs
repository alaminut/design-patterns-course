#region Namespace Imports

using Builder.Exercise;
using Builder.Facade;
using Builder.FluentBuilder;
using Builder.FluentBuilder.Simple;
using Builder.SimpleBuilder;
using static System.Console;

#endregion

namespace Builder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var htmlBuilder = new HtmlBuilder("ul");
            htmlBuilder.AppendChild("li", "Item 1");
            htmlBuilder.AppendChild("li", "Item 2");

            WriteLine("Simple Builder");
            WriteLine(htmlBuilder);
            WriteLine();

            WriteLine("Simple Fluent Builder");
            var simplePersonBuilder = new SimplePersonBuilder()
                                      .WithName("John Doe")
                                      .WithPosition("Director");
            WriteLine(simplePersonBuilder.Build());
            
            WriteLine("Generic Recursive Inheritance");
            var person = Person.New.WithName("Jane Doe").WithPosition("Manager").Build();
            WriteLine(person);

            WriteLine("Facade");
            var employee = new EmployeeBuilder()
                           .Known
                           .As("William")
                           .ForYears(30)
                           .Lives
                           .In("Alabama")
                           .At("Some Street 13th")
                           .WithPostalCode(1324)
                           .Works
                           .As("Engineer")
                           .WithSalary(100000M)
                           .Get;
            WriteLine(employee);
            
            WriteLine("Exercise");
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            WriteLine(cb);

        }
    }
}