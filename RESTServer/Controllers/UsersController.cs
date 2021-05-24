using RESTServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTServer.Controllers
{
    public class UsersController : ApiController
    {
        private static Dictionary<int, User> users = new Dictionary<int, User>(); // Poor man's "database" of users.

        // GET: api/Users
        public IEnumerable<User> Get()
        {
            return users.Values;
        }

        // GET: api/Users/5
        public User Get(int id)
        {
            return users.ContainsKey(id) ? users[id] : null;
        }

        // POST: api/Users
        public void Post([FromBody]User value)
        {
            users.Add(value.Id,value);
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]User value)
        {
            if (users.ContainsKey(id))
            {
                users[id].FirstName = value.FirstName;
                users[id].LastName = value.LastName;
                users[id].Username = value.Username;
            }
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            if (users.ContainsKey(id))
            {
                users.Remove(id);
            }
        }
    }
}
