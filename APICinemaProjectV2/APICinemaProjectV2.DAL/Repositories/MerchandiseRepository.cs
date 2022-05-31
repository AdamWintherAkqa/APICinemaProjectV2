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
    public interface IMerchandiseRepository
    {
        Task<List<Merchandise>> GetAllMerchandises();
        Task<Merchandise> GetMerchandiseByID(int id);
        Task<Merchandise> CreateMerchandise(Merchandise merchandise);
        Task<Merchandise> DeleteMerchandiseByID(int id);
        Task<Merchandise> UpdateMerchandise(Merchandise merchandise);
    }
    public class MerchandiseRepository : IMerchandiseRepository
    {
        private readonly AbContext context;
        public MerchandiseRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<Merchandise>> GetAllMerchandises()
        {
            return await context.Merchandises.ToListAsync();
        }
        public async Task<Merchandise> GetMerchandiseByID(int id)
        {
            return await context.Merchandises.FirstOrDefaultAsync((merchandiseObj) => merchandiseObj.MerchandiseID == id);
        }
        public async Task<Merchandise> CreateMerchandise(Merchandise merchandise)
        {
            context.Merchandises.Add(merchandise);
            await context.SaveChangesAsync();

            return merchandise;
        }
        public async Task<Merchandise> DeleteMerchandiseByID(int id)
        {
            try
            {
                Merchandise item = context.Merchandises.Where(item => item.MerchandiseID == id).Single();
                if (item != null)
                {
                    context.Merchandises.Remove(item);
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
        public async Task<Merchandise> UpdateMerchandise(Merchandise merchandise)
        {
            //context.Entry(merchandise).State = EntityState.Modified;

            //try
            //{
            //    await context.SaveChangesAsync();

            //    return merchandise;
            //}
            //catch
            //{
            //    return null;
            //}

            Merchandise update = await context.Merchandises.FirstOrDefaultAsync(item => item.MerchandiseID == merchandise.MerchandiseID);
            if (update != null)
            {
                update.MerchandiseName = merchandise.MerchandiseName;
                update.MerchandiseColor = merchandise.MerchandiseColor;
                update.MerchandiseType = merchandise.MerchandiseType;
                update.MerchandisePrice = merchandise.MerchandisePrice;
                update.MerchandiseSize = merchandise.MerchandiseSize;

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
