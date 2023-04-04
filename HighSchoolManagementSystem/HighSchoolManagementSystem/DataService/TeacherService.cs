using HighSchoolManagementSystem.Models;
using HighSchoolManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolManagementSystem.DataService
{
    public class TeacherService
    {
        private List<Teacher> teachers;

        public TeacherService()
        {
            teachers = new List<Teacher>();
        }

        public void AddTeacher(int id, string name, string surname)
        {
            teachers.Add(new() { Id = id, Name = name, Surname = surname });
        }

        public int IndexFinder(Teacher choosenTeacher)
        {
            int choosenTeacherId = choosenTeacher.Id;
            int choosenTeacherIndex = teachers.FindIndex(p => p.Id == choosenTeacherId);
            return choosenTeacherIndex;
        }

        public Teacher SearchTeacherById(List<Teacher> teachers, int teacherId)
        {
            return teachers.FirstOrDefault(p => p.Id == teacherId);

        }

        public Teacher SearchTeacherByName(List<Teacher> teachers, string teacherName)
        {
            return teachers.FirstOrDefault(p => p.Name == teacherName);
        }

        public List<Teacher> GetTeachers()
        {
            return teachers;
        }

        public void ShowTeacher(Teacher teacher)
        {
            if (ResultChecker.IdValidateChecker(teacher))
            {
                if (teacher.Classroom == null)
                {
                    Console.WriteLine($"{teacher.Id}\t{teacher.Name}\t{teacher.Surname}");
                }
                else
                {
                    Console.WriteLine($"{teacher.Id}\t{teacher.Name}\t{teacher.Surname} and the classroom is {teacher.Classroom.Name}");
                }
            }
            else
            {
                Console.WriteLine(Messages.Messages.TeacherNotExist);
            }

        }

        public void ShowTeachers()
        {
            if (ResultChecker.ListValidateChecker(teachers))
            {
                foreach (Teacher teacher in teachers)
                {
                    ShowTeacher(teacher);
                }
            }
            else
            {
                Console.WriteLine(Messages.Messages.TeacherIsEmpty);
            }

        }
    } 
}
