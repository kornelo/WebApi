using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiOrw6
{
    public class GamesController : ApiController
    {
        private static IList<Game> list = new List<Game>()
        {
        new Game(){Id = 1111,Name="PacMan"},
        new Game(){Id = 2222,Name="Minewrapper"},
        new Game(){Id = 3333,Name="Arkanoid"},
        new Game(){Id = 4444,Name="Pinball"},
        new Game(){Id = 5555,Name="Majong"}
         };

        // GET api/Games
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return list;
        }
        // GET api/Games/12345
        [HttpGet]
        public Game Get(int id)
        {
            return list.First(e => e.Id == id);
        }

        // POST api/Games
        [HttpPost]
        public void Post(Game Game)
        {
            int maxId = list.Max(e => e.Id);
            Game.Id = maxId + 1111;
            list.Add(Game);
        }
        // PUT api/Games/12345
        [HttpPut]
        public void Put(int id, Game Game)
        {
            int index = list.ToList().FindIndex(e => e.Id == id);
            list[index] = Game;
        }
        // DELETE api/Games/12345
        [HttpDelete]
        public void Delete(int id)
        {
            Game Game = Get(id);
            list.Remove(Game);
        }
    }
}