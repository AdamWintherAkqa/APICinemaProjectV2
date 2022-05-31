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
    public interface IInstructorRepository
    {
        Task<List<Instructor>> GetAllInstructors();
        Task<Instructor> GetInstructorByID(int id);
        Task<Instructor> CreateInstructor(Instructor instructor);
        Task<Instructor> DeleteInstructorByID(int id);
        Task<Instructor> UpdateInstructor(Instructor instructor);
    }
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AbContext context;
        public InstructorRepository(AbContext _context)
        {
            context = _context;
        }

        public async Task<List<Instructor>> GetAllInstructors()
        {
            return await context.Instructors.ToListAsync();
        }
        public async Task<Instructor> GetInstructorByID(int id)
        {
            return await context.Instructors.FirstOrDefaultAsync((instructorObj) => instructorObj.InstructorID == id);
        }
        public async Task<Instructor> CreateInstructor(Instructor instructor)
        {
            context.Instructors.Add(instructor);
            await context.SaveChangesAsync();

            return instructor;
        }
        public async Task<Instructor> DeleteInstructorByID(int id)
        {
            try
            {
                Instructor item = context.Instructors.Where(item => item.InstructorID == id).Single();
                if (item != null)
                {
                    context.Instructors.Remove(item);
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
        public async Task<Instructor> UpdateInstructor(Instructor instructor)
        {
            //context.Entry(instructor).State = EntityState.Modified;

            //try
            //{
            //    await context.SaveChangesAsync();

            //    return instructor;
            //}
            //catch
            //{
            //    return null;
            //}

            Instructor update = await context.Instructors.FirstOrDefaultAsync(item => item.InstructorID == instructor.InstructorID);
            if (update != null)
            {
                update.InstructorName = instructor.InstructorName;

                await context.SaveChangesAsync();
            }
            return update;

        }

    }
}
