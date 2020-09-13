using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Apress.Recipes.WebApi
{
    [ODataRoutePrefix("Players")]
    public class PlayersController : ODataController
    {
        private static List<Player> _players = new List<Player>
        {
            new Player
            {
                Id = 1,
                Name = "Kobe",
                Team = "Lakers",
            },
            new Player
            {
                Id = 2,
                Name = "LeBron",
                Team = "Lakers",
            },
            new Player
            {
                Id = 3,
                Name = "Larry",
                Team = "Celtics",
            },
            new Player
            {
                Id = 4,
                Name = "Bill",
                Team = "Celtics",
            }
        };

        [EnableQuery]
        [ODataRoute]
        public IQueryable<Player> GetAllPlayers()
        {
            return _players.AsQueryable();
        }

        [EnableQuery]
        [ODataRoute("({key})")]
        public SingleResult<Player> GetSinglePlayers(int key)
        {
            return SingleResult.Create(_players.Where(x => x.Id == key).AsQueryable());
        }
    }
}