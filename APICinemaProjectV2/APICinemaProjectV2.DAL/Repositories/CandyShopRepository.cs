using APICinemaProject2.DAL.Database;
using APICinemaProject2.DAL.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICinemaProject2.DAL.Repositories
{
    public interface ICandyShopRepository
    {
        Task<List<CandyShop>> GetAllCandyShops();
        Task<CandyShop> GetCandyShopByID(int id);
        Task<CandyShop> DeleteCandyShopByID(int id);
        Task<CandyShop> CreateCandyShop(CandyShop candyShop);
        Task<CandyShop> UpdateCandyShop(CandyShop candyShop);

    }
    public class CandyShopRepository : ICandyShopRepository
    {
        private readonly AbContext context;

        public CandyShopRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<CandyShop>> GetAllCandyShops()
        {
            return await context.CandyShops.ToListAsync();
        }

        public async Task<CandyShop> GetCandyShopByID(int id)
        {
            return await context.CandyShops.FirstOrDefaultAsync((candyShopObj) => candyShopObj.CandyShopID == id);
        }
        public async Task<CandyShop> CreateCandyShop(CandyShop candyShop)
        {
            context.CandyShops.Add(candyShop);
            await context.SaveChangesAsync();

            return candyShop;
        }
        public async Task<CandyShop> DeleteCandyShopByID(int id)
        {
            try
            {
                CandyShop item = context.CandyShops.Where(item => item.CandyShopID == id).Single();
                if (item != null)
                {
                    context.CandyShops.Remove(item);
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
        public async Task<CandyShop> UpdateCandyShop(CandyShop candyShop)
        {
            CandyShop update = await context.CandyShops.FirstOrDefaultAsync(item => item.CandyShopID == candyShop.CandyShopID);
            if (update != null)
            {
                update.CandyShopName = candyShop.CandyShopName;
                update.CandyShopPrice = candyShop.CandyShopPrice;
                update.CandyShopType = candyShop.CandyShopType;

                await context.SaveChangesAsync();
            }
            return update;
        }
    }
}