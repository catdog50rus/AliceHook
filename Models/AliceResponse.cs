using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliceHook.Models
{
    public class AliceResponse
    {
        public Response Response { get; set; } = new Response();
        public Session Session { get; set; }
        public string Version { get; set; }

        public AliceResponse(AliceRequest request)
        {
            Session = request.Session;
            Version = request.Version;
        }
    }


    public class Button
    {
        public string Title { get; set; }
        public Payload Payload { get; set; }
        public string Url { get; set; }
        public bool Hide { get; set; } = true;
    }

    public class Response
    {
        public string Text { get; set; }
        public string Tts { get; set; }
        public List<Button> Buttons { get; set; }
        public bool EndSession { get; set; }
    }

}
