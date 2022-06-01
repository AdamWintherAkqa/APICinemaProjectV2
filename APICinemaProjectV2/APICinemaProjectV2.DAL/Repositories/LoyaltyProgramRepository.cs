using APICinemaProject2.DAL.Database;
using APICinemaProject2.DAL.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APICinemaProject2.DAL.Repositories
{
    public interface ILoyaltyProgramRepository
    {
        Task<List<LoyaltyProgram>> GetAllLoyaltyPrograms();
        Task<LoyaltyProgram> GetLoyaltyProgramByID(int id);
        Task<LoyaltyProgram> CreateLoyaltyProgram(LoyaltyProgram loyaltyprogram);
        Task<LoyaltyProgram> DeleteLoyaltyProgramByID(int id);
        Task<LoyaltyProgram> UpdateLoyaltyProgram(LoyaltyProgram loyaltyprogram);
        Task<LoyaltyProgram> GetEntireLoyaltyProgramByID(int id);
    }
    public class LoyaltyProgramRepository : ILoyaltyProgramRepository
    {
        private readonly AbContext context;
        public LoyaltyProgramRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<LoyaltyProgram>> GetAllLoyaltyPrograms()
        {
            return await context.LoyaltyPrograms.ToListAsync();
        }
        public async Task<LoyaltyProgram> GetLoyaltyProgramByID(int id)
        {
            return await context.LoyaltyPrograms.FirstOrDefaultAsync((loyalprogramObj) => loyalprogramObj.LoyaltyProgramID == id);
        }
        public async Task<LoyaltyProgram> CreateLoyaltyProgram(LoyaltyProgram loyalprogram)
        {
            context.LoyaltyPrograms.Add(loyalprogram);
            await context.SaveChangesAsync();

            return loyalprogram;
        }
        public async Task<LoyaltyProgram> GetEntireLoyaltyProgramByID(int id)
        {
            return await context.LoyaltyPrograms.Include(loyalprogram => loyalprogram.Customer).Include(loyalprogram => loyalprogram.Order).FirstOrDefaultAsync((loyalprogramObj) => loyalprogramObj.LoyaltyProgramID == id);
        }
        public async Task<LoyaltyProgram> DeleteLoyaltyProgramByID(int id)
        {
            try
            {
                LoyaltyProgram item = context.LoyaltyPrograms.Where(item => item.LoyaltyProgramID == id).Single();
                if (item != null)
                {
                    context.LoyaltyPrograms.Remove(item);
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
        public async Task<LoyaltyProgram> UpdateLoyaltyProgram(LoyaltyProgram loyalprogram)
        {
            //context.Entry(loyalprogram).State = EntityState.Modified;

            //try
            //{
            //    await context.SaveChangesAsync();

            //    return loyalprogram;
            //}
            //catch
            //{
            //    return null;
            //}

            LoyaltyProgram update = await context.LoyaltyPrograms.FirstOrDefaultAsync(item => item.LoyaltyProgramID == loyalprogram.LoyaltyProgramID);
            if (update != null)
            {
                update.LoyaltyProgramID = loyalprogram.LoyaltyProgramID;

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
