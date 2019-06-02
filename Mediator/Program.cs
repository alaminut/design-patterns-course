using System;
using Mediator.Chat;
using Mediator.Exercise;
using static System.Console;
namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatRoomDemo();
            ExerciseDemo();
        }

        static void ExerciseDemo()
        {
            var m = new Exercise.Mediator();
            var p1 = new Participant(m);
            var p2 = new Participant(m);
            
            WriteLine(p1);
            WriteLine(p2);
            
            p1.Say(3);
            
            WriteLine(p1);
            WriteLine(p2);
            
            p2.Say(2);
            
            WriteLine(p1);
            WriteLine(p2);
        }

        static void ChatRoomDemo()
        {
            var room = new ChatRoom();
            var john = new Person("John");
            var jane = new Person("Jane");
            room.Join(john);
            room.Join(jane);
            john.Say("Hi there!");
            jane.Say("Hey how are you?");
            var rick = new Person("Rick");
            room.Join(rick);
            rick.Say("Sup people?");
            jane.PrivateMessage("Rick", "Hey Rick, it's nice to see you");
        }
    }
}
