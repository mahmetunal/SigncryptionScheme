using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSigncryptionImplementation.Models
{
    public static class Participants
    {
        public static Dictionary<string, User> ParticipantsList { get; } = new Dictionary<string, User>();
    }
}
