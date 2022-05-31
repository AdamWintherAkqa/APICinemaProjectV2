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
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenres();
        Task<Genre> GetGenreByID(int id);
        Task<Genre> CreateGenre(Genre genre);
        Task<Genre> DeleteGenreByID(int id);
        Task<Genre> UpdateGenre(Genre genre);
    }
    public class GenreRepository : IGenreRepository
    {
        private readonly AbContext context;
        public GenreRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            return await context.Genres.ToListAsync();
        }
        public async Task<Genre> GetGenreByID(int id)
        {
            return await context.Genres.FirstOrDefaultAsync((genreObj) => genreObj.GenreID == id);
        }
        public async Task<Genre> CreateGenre(Genre genre)
        {
            context.Genres.Add(genre);
            await context.SaveChangesAsync();

            return genre;
        }
        public async Task<Genre> DeleteGenreByID(int id)
        {
            try
            {
                Genre item = context.Genres.Where(item => item.GenreID == id).Single();
                if (item != null)
                {
                    context.Genres.Remove(item);
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
        public async Task<Genre> UpdateGenre(Genre genre)
        {
            //context.Entry(genre).State = EntityState.Modified;

            //try
            //{
            //    await context.SaveChangesAsync();

            //    return genre;
            //}
            //catch
            //{
            //    return null;
            //}

            Genre update = await context.Genres.FirstOrDefaultAsync(item => item.GenreID == genre.GenreID);
            if (update != null)
            {
                update.GenreName = genre.GenreName;

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
