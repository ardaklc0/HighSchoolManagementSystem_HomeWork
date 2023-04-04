using HighSchoolManagementSystem.Messages;
using HighSchoolManagementSystem.Models;
using HighSchoolManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolManagementSystem.DataService
{
    public class StudentService
    {
        private List<Student> students;

        public StudentService()
        {
            students = new List<Student>();
        }

        public void AddStudent(int id, string name, string surname)
        {
            students.Add(new() { Id = id, Name = name, Surname = surname });
        }

        public int IndexFinder(Student choosenStudent)
        {
            int choosenStudentId = choosenStudent.Id;
            int choosenStudentIndex = students.FindIndex(p => p.Id == choosenStudentId);
            return choosenStudentIndex; 
        }

        public Student SearchStudentById(List<Student> students, int studentId)
        {
            return students.FirstOrDefault(p => p.Id == studentId);
        }

        public Student SearchStudentByName(List<Student> students, string studentName)
        {
            return students.FirstOrDefault(p => p.Name == studentName);
        }

        public void AddHomework()
        {
            Console.WriteLine("You have added your homework");
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public void ShowStudent(Student student)
        {
            if (ResultChecker.IdValidateChecker(student))
            {
                if (student.Teacher == null && student.Classroom == null)
                {
                    Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Surname}");
                }
                else if (student.Teacher != null && student.Classroom == null)
                {
                    Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Surname} and teacher's name is {student.Teacher.Name} {student.Teacher.Surname}");
                }
                else if (student.Teacher == null && student.Classroom != null)
                {
                    Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Surname} and class is {student.Classroom.Name}");
                }
                else
                {
                    Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Surname} and teacher's name is {student.Teacher.Name} {student.Teacher.Surname} and the class is {student.Classroom.Name}");
                }
            }
            else
            {
                Console.WriteLine(Messages.Messages.StudentNotExist);
            }
            
        }

        public void ShowStudents()
        {
            if (ResultChecker.ListValidateChecker(students))
            {
                foreach (Student student in students)
                {
                    ShowStudent(student);
                }
            }
            else
            {
                Console.WriteLine(Messages.Messages.StudentIsEmpty);
            }

        }
    }
}
