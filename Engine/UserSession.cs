using AliceHook.Engine.Modifiers;
using AliceHook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliceHook.Engine
{
    public class UserSession
    {

        private static readonly List<ModifierBase> Modiffiers = new List<ModifierBase>();
        
        private readonly State State = new State();

        public UserSession(int uid)
        {
            using var db = new ApplicationDbContext();
            var user = db.Users.FirstOrDefault(u => u.Id == uid);
            if (user == null)
            {
                user = new User() { Id = uid };
                db.Users.Add(user);
                db.SaveChangesAsync();
            }
            State.User = user;

        }

        internal AliceResponse HandleRequest(AliceRequest aliceRequest)
        {
            AliceResponse response = null;
            if (!Modiffiers.Any(modifier => modifier.Run(aliceRequest, State, out response)))
            {
                throw new NotSupportedException("No default modifier");
            }
            return response;
        }
    }
}
