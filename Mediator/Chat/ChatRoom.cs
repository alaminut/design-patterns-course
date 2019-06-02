using System.Collections.Generic;
using System.Linq;

namespace Mediator.Chat
{
    /*
     * In this example ChatRoom is the Mediator class for participants to
     * communicate with each other. Because we are using the Mediator, it does
     * not matter if a target participant exists in the room or not. Mediator
     * takes care of all the communication and error handling.
     */
    public class ChatRoom
    {
        private List<Person> _participants = new List<Person>();

        public void Join(Person p)
        {
            p.Room = this;
            _participants.Add(p);
            Broadcast("room", $"{p.Name} joined the chat.");
        }

        public void Broadcast(string sender, string message)
        {
            foreach (var participant in _participants)
            {
                if (!participant.Name.Equals(sender))
                    participant.Receive(sender, message);
            }
        }

        public void Send(string sender, string target, string message)
        {
            _participants.FirstOrDefault(f => f.Name == target)?.Receive(sender, message);
        }
    }
}
