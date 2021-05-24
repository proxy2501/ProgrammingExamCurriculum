using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTServer.Models
{
    public class User
    {
        private static int nextId = 0;

        public int Id { get; private set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Username { get; set; } = "";

        public User()
        {
            Id = nextId;
            nextId++;
        }
    }
}