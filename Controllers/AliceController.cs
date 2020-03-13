using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AliceHook.Models;
using System.Collections.Concurrent;
using AliceHook.Engine;


namespace AliceHook.Controllers
{
    [Route("/")]
    [ApiController]
    public class AliceController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "It Worked!";
        }

        private static readonly ConcurrentDictionary<string, UserSession> Session = new ConcurrentDictionary<string, UserSession>();
        private static readonly JsonSerializerOptions serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        [HttpPost]
        public Task Post()
        {
            using var reader = new StreamReader(Request.Body);
            var body = reader.ReadToEnd();

            var aliceRequest = JsonSerializer.Deserialize<AliceRequest>(body,serializeOptions);
            var userId = aliceRequest.Session.UserId;
            var session = Session.GetOrAdd(userId, uid => new UserSession(uid));

            var aliceResponse = session.HandleRequest(aliceRequest);
            
            var stringResponse = JsonSerializer.Serialize(aliceResponse, serializeOptions);
            return Response.WriteAsync(stringResponse);
        }
    }
}