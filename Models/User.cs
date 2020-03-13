using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AliceHook.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public List<WebHook> WebHooks { get; set; }
    }
}
