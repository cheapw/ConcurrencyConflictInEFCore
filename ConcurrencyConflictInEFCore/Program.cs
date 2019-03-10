using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyConflictInEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //DbContextOptionsBuilder<PersonContext> builder = new DbContextOptionsBuilder<PersonContext>();
            //builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            using (PersonContext context = new PersonContext())
            {
                //context.Database.EnsureCreated();


                // Fetch a person from database and change phone number
                var person = context.Persons.Single(p => p.PersonId == 1);
                person.PhoneNumber = "555-555-5555";

                // Change the person's name in the database to simulate a concurrency conflict
                context.Database.ExecuteSqlCommand(
                    "Update dbo.Person set FirstName='Erye', LastName= 'Jane', Gender = 'Female' Where PersonId=1");

                var saved = false;
                while (!saved)
                {
                    try
                    {
                        // Attempt to save changes to the database
                        context.SaveChanges();
                        saved = true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {

                        foreach (var entry in ex.Entries)
                        {
                            if(entry.Entity is Person)
                            {
                                var proposedValues = entry.CurrentValues;
                                var databaseValues = entry.GetDatabaseValues();

                                foreach (var property in proposedValues.Properties)
                                {
                                    var proposedValue = proposedValues[property];
                                    var databaseValue = databaseValues[property];

                                    // TODO: decide which value should be written to database
                                    // proposedValues[property] = <value to be saved>;
                                    if (!(property.Name == nameof(person.PhoneNumber)))
                                    {
                                        if (proposedValue.ToString() != databaseValue.ToString())
                                        {
                                            Console.WriteLine($"{property.Name}字段的值已通过其他途径更改,当前数据库中的值为: {databaseValue},欲提交的值为: {proposedValue}\n是否使用新值,或者仍按表单中的数据提交(Y/N)");
                                            var choose = Console.ReadKey().Key.ToString();

                                            Console.WriteLine();

                                            if (choose.ToUpper() == "Y")
                                            {
                                                proposedValues[property] = databaseValue;
                                            }
                                        }
                                    }
                                }
                                // Refresh original values to bypass next concurrency check
                                entry.OriginalValues.SetValues(databaseValues);
                            }
                            else
                            {
                                throw new NotSupportedException(
                                    "Don't know how to handle concurrency conflicts for " 
                                    + entry.Metadata.Name);
                            }
                        }
                    }
                }
            }
        }
    }
}
