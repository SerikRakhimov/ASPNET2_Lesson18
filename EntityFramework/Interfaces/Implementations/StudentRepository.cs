using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Interfaces.Implementations
{
    public class StudentRepository: IStudentRepository
    {
        public readonly StudentDbContext _db;
        
        public StudentRepository(StudentDbContext db)
        {
            _db = db;

        }

        public bool Add(Student student)
        {
            try
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Student student)
        {
            try
            {
                _db.Entry<Student>(student).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var student = Get(id);
                if (student != null)
                {
                    _db.Students.Remove(student);
                    _db.SaveChanges();
                }
                else return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Student Get(int id)
        {
            return _db.Students.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _db.Students;
        }

    }
}
