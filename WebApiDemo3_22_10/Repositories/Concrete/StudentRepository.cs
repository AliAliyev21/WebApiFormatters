using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiDemo3_22_10.Data;
using WebApiDemo3_22_10.Entities;
using WebApiDemo3_22_10.Repositories.Abstract;

namespace WebApiDemo3_22_10.Repositories.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task Add(Student entity)
        {
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Student entity)
        {
            await Task.Run(() =>
            {
                _context.Students.Remove(entity);
            });
            await _context.SaveChangesAsync();
        }

        public async Task<Student> Get(Expression<Func<Student, bool>> predicate)
        {
            var student = await _context.Students.FirstOrDefaultAsync(predicate);
            return student;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await Task.Run(() =>
            {
                return _context.Students;
            });
        }

        public async Task Update(Student entity)
        {
            await Task.Run(() =>
            {
                _context.Students.Update(entity);
            });
            await _context.SaveChangesAsync();
        }
    }
}
