using APICinemaProject2.DAL.Database;
using APICinemaProject2.DAL.Database.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APICinemaProjectV2.DAL.Repositories
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetAllActors();
        Task<Actor> GetActorByID(int id);
        Task<List<Actor>> GetAllActorsAndMovies();
        Task<Actor> CreateActor(Actor actor);
        Task<Actor> DeleteActorByID(int id);
        Task<Actor> UpdateActor(Actor actor);
    }
    public class ActorRepository : IActorRepository
    {
        private readonly AbContext context;
        public ActorRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<Actor>> GetAllActors()
        {
            return await context.Actors.ToListAsync();
        }
        public async Task<Actor> GetActorByID(int id)
        {
            return await context.Actors.FirstOrDefaultAsync((actorObj) => actorObj.ActorID == id);
        }
        public async Task<List<Actor>> GetAllActorsAndMovies()
        {
            List<Actor> actors = new List<Actor>();
            actors = await context.Actors.Include(actors => actors.Movies).ToListAsync();
            return actors;
        }
        public async Task<Actor> CreateActor(Actor actor)
        {
            context.Actors.Add(actor);
            await context.SaveChangesAsync();

            return actor;
        }
        public async Task<Actor> DeleteActorByID(int id)
        {
            try
            {
                Actor item = context.Actors.Where(item => item.ActorID == id).Single();
                if (item != null)
                {
                    context.Actors.Remove(item);
                    await context.SaveChangesAsync();
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch
            {

                return null;
            }
        }
        public async Task<Actor> UpdateActor(Actor actor)
        {
            Actor update = await context.Actors.FirstOrDefaultAsync(item => item.ActorID == actor.ActorID);
            if (update != null)
            {
                update.ActorName = actor.ActorName;

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
