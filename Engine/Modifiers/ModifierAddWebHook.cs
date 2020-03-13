using AliceHook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliceHook.Engine.Modifiers
{
    public class ModifierAddWebHook : ModifierBase
    {
        
        protected override bool Check(AliceRequest request, State state)
        {
            if (state.Step != Step.None) return false;
            var keywords = new List<string> 
            { 
                "Добв вебхук",
                "Новый вэбхук"
            };
            var requestString = request.Request.Nlu.Tokens;
            return keywords.Any(kw =>
            {
                var tokens = kw.Split(" ");
                return tokens.All(requestString.ContainsStartWith);
            });
        }

        protected override SimpleResponse Respond(AliceRequest request, State state)
        {
            state.Step = Step.AwaitForUrl;
            return new SimpleResponse
            {
                Text = "Введи Url Вебхука"
            };
        }
    }
}
