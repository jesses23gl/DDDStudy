using Domain;
using Domain.Interfaces;
using Infrastruct.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruct.Data.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudyContext context) : base(context)
        {
        }

        public Student GetByEmail(string email)
        {
            var model = _db.Set<Student>().FirstOrDefault(x => x.Email.Equals(email));
            return model;
        }
    }
}
