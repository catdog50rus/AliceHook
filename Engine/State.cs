using AliceHook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliceHook.Engine
{
    public class State
    {
        public User User { get; set; }
        public Step Step { get; set; } = Step.None;
    }

    public enum Step
    {
        None,
        AwaitForUrl,
        AwaitForKeyword
    }
}
