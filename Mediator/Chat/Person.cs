using System;
using System.Collections.Generic;

namespace Mediator.Chat
{
    public class Person
    {
        public string Name;
        public Chat.ChatRoom Room;
        private List<string> _chatLog = new List<string>();

        public Person(string name)
        {
            Name = name;
        }

        public void Say(string message)
        {
            Room.Broadcast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            Room.Send(Name, who, message);
        }

        public void Receive(string sender, string message)
        {
            _chatLog.Add($"{sender}: {message}");
            Console.WriteLine($"[{Name}'s session] {sender}: {message}");
        }
    }
}
