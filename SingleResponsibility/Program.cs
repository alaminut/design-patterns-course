using System;
using static System.Console;

namespace SingleResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            // In order for Journal class to change, there needs to be a requirement that actually changes the way we add entries
            // or the entry structure itself changed (say we decided to add an Entry class instead of strings.)
            
            var j = new Journal();
            j.AddEntry("I woke up at 6 am");
            j.AddEntry("Damn!, I forgot to drink my coffee this morning!");
            j.AddEntry("I'm so tired of work, can't wait to go home.");
            j.AddEntry("Gonna sleep like a baby tonight.");
            
            // Let's say we want to save this journal to a storage (file in this example)
            // in order to keep Single Responsibility principle up, we shall not add methods like
            // save, load to the class Journal. Instead we should separate those concerns to another class.

            var fileName = @"C:\temp\my-journal.txt";
            JournalStorage.Save(j, fileName);
            var storedJournal = JournalStorage.Load(fileName);

            WriteLine("Journal in memory");
            WriteLine(j);
            WriteLine("Journal loaded from file");
            WriteLine(storedJournal);
        }
    }
}