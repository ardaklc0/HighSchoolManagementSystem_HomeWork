using HighSchoolManagementSystem.Messages;
using HighSchoolManagementSystem.Models;
using HighSchoolManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolManagementSystem.DataService
{
    public class ClassroomService
    {
        private List<Classroom> classrooms;

        public ClassroomService()
        {
            classrooms = new List<Classroom>();
        }

        public void AddClassroom(int id, string name)
        {

            classrooms.Add(new() { Id = id, Name = name });
        }

        public bool AssignTeacher(TeacherService teacherService, int teacherId, int classroomId)
        {
            var teachers = teacherService.GetTeachers();

            Teacher choosenTeacher = teacherService.SearchTeacherById(teachers, teacherId);
            if (ResultChecker.IdValidateChecker(choosenTeacher))
            {
                int choosenTeacherIndex = teacherService.IndexFinder(choosenTeacher);
                Classroom choosenClassroom = SearchClassroomById(classrooms, classroomId);
                if (ResultChecker.IdValidateChecker(choosenClassroom))
                {
                    int choosenClassroomIndex = IndexFinder(choosenClassroom);
                    classrooms[choosenClassroomIndex].Teacher = choosenTeacher;
                    teachers[choosenTeacherIndex].Classroom = choosenClassroom;
                    Console.WriteLine($"You have assigned teacher {choosenTeacher.Name} {choosenTeacher.Surname} to the class {choosenClassroom.Name}");
                    return true;
                }
                else
                {
                    Console.WriteLine(Messages.Messages.ClassroomNotExist);
                    return false;
                }
            }
            else
            {
                Console.WriteLine(Messages.Messages.TeacherNotExist);
                return false;
            }
        }


        public int IndexFinder(Classroom choosenClassroom)
        {
            int choosenClassroomId = choosenClassroom.Id;
            int choosenClassroomIndex = classrooms.FindIndex(p => p.Id == choosenClassroomId);
            return choosenClassroomIndex;
        }

        public bool AssignStudent(StudentService studentService, int studentId, int classroomId)
        {
            var students = studentService.GetStudents();

            Student choosenStudent = studentService.SearchStudentById(students, studentId);
            if (ResultChecker.IdValidateChecker(choosenStudent))
            {
                int choosenStudentIndex = studentService.IndexFinder(choosenStudent);
                Classroom choosenClassroom = SearchClassroomById(classrooms, classroomId);

                if (ResultChecker.IdValidateChecker(choosenClassroom))
                {
                    int choosenClassroomIndex = IndexFinder(choosenClassroom);
                    classrooms[choosenClassroomIndex].Students.Add(choosenStudent);
                    students[choosenStudentIndex].Classroom = choosenClassroom;
                    return true;
                }
                else
                {
                    Console.WriteLine(Messages.Messages.ClassroomNotExist);
                    return false;
                }
            }
            else
            {
                Console.WriteLine(Messages.Messages.StudentNotExist);
                return false;
            }
        }

        public Classroom SearchClassroomById(List<Classroom> classrooms, int classroomId)
        { 
            return classrooms.FirstOrDefault(p => p.Id == classroomId);
        }

        public Classroom SearchClassroomByName(List<Classroom> classrooms, string classroomName)
        {
            return classrooms.FirstOrDefault(p => p.Name == classroomName);
        }

        public List<Classroom> GetClassrooms()
        {
            return classrooms;
        }

        public void ShowClassroom(Classroom classroom)
        {
            if (ResultChecker.IdValidateChecker(classroom))
            {
                if (classroom.Teacher == null && classroom.Students == null)
                {
                    Console.WriteLine($"{classroom.Id}\t{classroom.Name}");
                }
                else if (classroom.Teacher != null && classroom.Students == null)
                {
                    Console.WriteLine($"{classroom.Id}\t{classroom.Name}\t{classroom.Teacher.Name} {classroom.Teacher.Surname}");
                }
                else if (classroom.Teacher == null && classroom.Students != null)
                {
                    Console.WriteLine($"{classroom.Id}\t{classroom.Name}");
                    foreach (Student student in classroom.Students)
                    {
                        Console.WriteLine($"Student of the class : {student.Id} {student.Name} {student.Surname}");
                    }
                }
                else
                {
                    Console.WriteLine($"{classroom.Id}\t{classroom.Name}");
                    Console.WriteLine($"Teacher of the class : {classroom.Teacher.Id} {classroom.Teacher.Name} {classroom.Teacher.Surname}");
                    foreach (Student student in classroom.Students)
                    {
                        Console.WriteLine($"Student of the class : {student.Id} {student.Name} {student.Surname}");
                    }
                }
            }
            else
            {
                Console.WriteLine(Messages.Messages.ClassroomNotExist);
            }

        }

        public void ShowClassrooms()
        {
            if (ResultChecker.ListValidateChecker(classrooms))
            {
                foreach (Classroom classroom in classrooms)
                {
                    ShowClassroom(classroom);
                }
            }
            else
            {
                Console.WriteLine(Messages.Messages.ClassroomIsEmpty);
            }

        }
    }
}
