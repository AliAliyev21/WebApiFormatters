using System.Linq.Expressions;
using WebApiDemo3_22_10.Entities;
using WebApiDemo3_22_10.Repositories.Abstract;
using WebApiDemo3_22_10.Services.Abstract;

namespace WebApiDemo3_22_10.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task Add(Student entity)
        {
            await _studentRepository.Add(entity);
        }

        public async Task Delete(Student entity)
        {
            await _studentRepository.Delete(entity);
        }

        public async Task<Student> Get(Expression<Func<Student, bool>> predicate)
        {
            var item = await _studentRepository.Get(predicate);
            return item;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _studentRepository.GetAll();
        }

        public async Task Update(Student entity)
        {
            await _studentRepository.Update(entity);
        }
    }
}
