using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();

        Student Get(int id);

        bool Add(Student student);

        bool Edit(Student student);

        bool Delete(int id);

    }
}
