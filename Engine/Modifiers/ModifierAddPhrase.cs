using AliceHook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AliceHook.Engine.Modifiers
{
    public class ModifierAddPhrase : ModifierBase
    {
        protected override bool Check(AliceRequest request, State state)
        {
            if (state.Step != Step.AwaitForUrl) return false;
            
            var urlRegex = new Regex("^")
        }

        protected override SimpleResponse Respond(AliceRequest request, State state)
        {
            throw new NotImplementedException();
        }
    }
}
