using AliceHook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliceHook.Engine.Modifiers
{
    public class ModifierEnter : ModifierBase
    {
        protected override bool Check(AliceRequest request, State state)
        {
            return request.Request.Command == "";

        }

        protected override SimpleResponse Respond(AliceRequest request, State state)
        {
            return new SimpleResponse
            {
                Text="Привет! В этом навыке ты можешь добавлять WebHookи и вызывать их ключевыми словами. Скажи, \"Добавить WebHook\""
            };
        }
    }
}
