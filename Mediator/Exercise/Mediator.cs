using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator.Exercise
{
    public class Mediator
    {
        private readonly Dictionary<string, Participant> _participants = new Dictionary<string, Participant>();

        public string Register(Participant p)
        {
            var id = Guid.NewGuid().ToString("N");
            if (_participants.ContainsKey(id))
            {
                _participants[id] = p;
            }
            else
            {
                _participants.Add(id, p);
            }

            return id;
        }

        public void AnnounceValue(string clientId, int value)
        {
            foreach (var p in _participants.Where(kvp => kvp.Key != clientId).Select(kvp => kvp.Value))
            {
                p.ReceiveValue(value);
            }
        }
    }
}
