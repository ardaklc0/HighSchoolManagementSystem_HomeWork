using HighSchoolManagementSystem;
using HighSchoolManagementSystem.DataService;
using HighSchoolManagementSystem.Logger;
using HighSchoolManagementSystem.Messages;
using HighSchoolManagementSystem.Models;
using HighSchoolManagementSystem.Utilities;
using System.Data.SqlTypes;

TeacherService teacherService = new TeacherService();
StudentService studentService = new StudentService();
ClassroomService classroomService = new ClassroomService();
FileLogger fileLogger = new FileLogger();

fileLogger.Log(Messages.StraightLine);
fileLogger.Log($"\n{Messages.LogBeginning} : {DateTime.Now} : {Messages.Success}\n");
bool isQuit = true;
while (isQuit)
{
    string switchNumber = GetChoices();
    if (switchNumber.ToString().ToLower() == "q")
    {
        fileLogger.Log($"\n{Messages.SuccessQuit} : {DateTime.Now} : {Messages.Success}");
        isQuit = false;
    }
    else
    {
        string switchNumberString = switchNumber;
        if (ResultChecker.EventChecker(switchNumberString, 1, 6))
        {
            fileLogger.Log($"\n{switchNumberString} : {Messages.SuccessInput} : {DateTime.Now} : {Messages.Success}");
            int switchNumberInt = Convert.ToInt32(switchNumberString);
            switch (switchNumberInt)
            {
                case 1:
                    fileLogger.Log($"\n{Messages.AddStudentOperation} : {DateTime.Now} : {Messages.Success}");
                    AddStudent(studentService, fileLogger);
                    break;
                case 2:
                    fileLogger.Log($"\n{Messages.AddTeacherOperation} : {DateTime.Now} : {Messages.Success}");
                    AddTeacher(teacherService, fileLogger);
                    break;
                case 3:
                    fileLogger.Log($"\n{Messages.AddClassroomOperation} : {DateTime.Now} : {Messages.Success}");
                    AddClassroom(classroomService, fileLogger);
                    break;
                case 4:
                    fileLogger.Log($"\n{Messages.AssignStudentOperation} : {DateTime.Now} : {Messages.Success}");
                    AssignStudentToClass(studentService, classroomService, fileLogger);
                    break;
                case 5:
                    fileLogger.Log($"\n{Messages.AssignTeacherOperation} : {DateTime.Now} : {Messages.Success}");
                    AssignTeacherToClass(teacherService, classroomService, fileLogger);
                    break;
                case 6:
                    string secondSwitchNumber = GetSearchChoices();
                    if (secondSwitchNumber.ToString().ToLower() == "q")
                    {
                        fileLogger.Log($"\n{Messages.SuccessQuit} : {DateTime.Now} : {Messages.Success}");
                        isQuit = false;
                    }
                    else
                    {
                        string secondSwitchNumberString = secondSwitchNumber;
                        if (ResultChecker.EventChecker(secondSwitchNumberString, 1, 8))
                        {
                            fileLogger.Log($"\n{secondSwitchNumberString} : {Messages.SuccessInput} : {DateTime.Now} : {Messages.Error}");
                            int secondSwitchNumberInt = Convert.ToInt32(secondSwitchNumberString);
                            switch (secondSwitchNumberInt)
                            {
                                case 1:
                                    SearchStudentById(studentService);
                                    break;
                                case 2:
                                    SearchStudentByName(studentService);
                                    break;
                                case 3:
                                    SearchTeacherById(teacherService);
                                    break;
                                case 4:
                                    SearchTeacherByName(teacherService);
                                    break;
                                case 5:
                                    SearchClassById(classroomService);
                                    break;
                                case 6:
                                    SearchClassByName(classroomService);
                                    break;
                                case 7:
                                    SearchStudentInTheClassById(classroomService, studentService);
                                    break;
                                case 8:
                                    SearchTeacherInTheClassById(classroomService, teacherService);
                                    break;
                            }
                        }
                        else
                        {
                            fileLogger.Log($"{secondSwitchNumber} : {Messages.ErrorInput} : {DateTime.Now} {Messages.Error}");
                        }
                    }
                    break;
            }
        }
        else
        {
            fileLogger.Log($"{switchNumberString} : {Messages.ErrorInput} : {DateTime.Now} {Messages.Error}");
        }
    }
}


static void AddStudent(StudentService studentService, FileLogger fileLogger)
{

    Console.WriteLine(Messages.StraightLine);
    Console.Write(Messages.EnterAnId);
    string studentIdString = Console.ReadLine();
    if (!ResultChecker.IdIntChecker(studentIdString))
    {
        fileLogger.Log($"{studentIdString} : {Messages.NotANumber} : {DateTime.Now} : {Messages.Error}");
        fileLogger.Log($"{Messages.ErrorStudentAppend} : {DateTime.Now} : {Messages.Error}");
        Console.WriteLine(Messages.NotANumber);
    }
    else
    {
        int studentId = Convert.ToInt32(studentIdString);
        Console.Write(Messages.EnterAName);
        string studentName = Console.ReadLine();
        if (!ResultChecker.NameSurnameStringChecker(studentName))
        {
            fileLogger.Log($"{studentId} : {DateTime.Now} : {Messages.Success}");
            fileLogger.Log($"{studentName} : {Messages.NotAName} : {DateTime.Now} : {Messages.Error}");
            fileLogger.Log($"{Messages.ErrorStudentAppend} : {DateTime.Now} : {Messages.Error}");
            Console.WriteLine(Messages.NotAName);
        }
        else
        {
            Console.Write(Messages.EnterASurname);
            string studentSurname = Console.ReadLine();
            Console.WriteLine(Messages.StraightLine);
            if (!ResultChecker.NameSurnameStringChecker(studentSurname))
            {
                fileLogger.Log($"{studentId} : {DateTime.Now} : {Messages.Success}");
                fileLogger.Log($"{studentName} : {DateTime.Now} : {Messages.Success}");
                fileLogger.Log($"{studentSurname} : {Messages.NotASurname} : {DateTime.Now} : {Messages.Error} ");
                fileLogger.Log($"{Messages.ErrorStudentAppend} : {DateTime.Now} : {Messages.Error}");
                Console.WriteLine(Messages.NotASurname);
            }
            else
            {
                studentService.AddStudent(studentId, studentName, studentSurname);
                Console.WriteLine(Messages.StraightLine);
                studentService.ShowStudents();
                Console.WriteLine(Messages.StraightLine);
                fileLogger.Log($"{studentIdString} {studentName} {studentSurname} : {DateTime.Now} : {Messages.Success}");
                fileLogger.Log($"{Messages.SuccessStudentAppend} : {DateTime.Now} : {Messages.Success}");
            }
        }
    }



}

static void AddTeacher(TeacherService teacherService, FileLogger fileLogger)
{

    Console.WriteLine(Messages.StraightLine);
    Console.Write(Messages.EnterAnId);
    string teacherIdString = Console.ReadLine();
    if (!ResultChecker.IdIntChecker(teacherIdString))
    {
        fileLogger.Log($"{teacherIdString} : {Messages.NotANumber} : {DateTime.Now} : {Messages.Error}");
        fileLogger.Log($"{Messages.ErrorTeacherAppend} : {DateTime.Now} : {Messages.Error}");
        Console.WriteLine(Messages.NotANumber);
    }
    else
    {
        int teacherId = Convert.ToInt32(teacherIdString);
        Console.Write(Messages.EnterAName);
        string teacherName = Console.ReadLine();
        if (!ResultChecker.NameSurnameStringChecker(teacherName))
        {
            fileLogger.Log($"{teacherId} : {DateTime.Now} : {Messages.Success}");
            fileLogger.Log($"{teacherName} : {Messages.NotAName} : {DateTime.Now} : {Messages.Error}");
            fileLogger.Log($"{Messages.ErrorTeacherAppend} : {DateTime.Now} : {Messages.Error}");
            Console.WriteLine(Messages.NotAName);
        }
        else
        {
            Console.Write(Messages.EnterASurname);
            string teacherSurname = Console.ReadLine();
            Console.WriteLine(Messages.StraightLine);
            if (!ResultChecker.NameSurnameStringChecker(teacherSurname))
            {
                fileLogger.Log($"{teacherId} : {DateTime.Now} : {Messages.Success}");
                fileLogger.Log($"{teacherName} : {DateTime.Now} : {Messages.Success}");
                fileLogger.Log($"{teacherSurname} : {Messages.NotASurname} : {DateTime.Now} : {Messages.Error} ");
                fileLogger.Log($"{Messages.ErrorTeacherAppend} : {DateTime.Now} : {Messages.Error}");
                Console.WriteLine(Messages.NotASurname);
            }
            else
            {
                teacherService.AddTeacher(teacherId, teacherName, teacherSurname);
                Console.WriteLine(Messages.StraightLine);
                teacherService.ShowTeachers();
                Console.WriteLine(Messages.StraightLine);
                fileLogger.Log($"{teacherIdString} {teacherName} {teacherSurname} : {DateTime.Now} : {Messages.Success}");
                fileLogger.Log($"{Messages.SuccessTeacherAppend} : {DateTime.Now} : {Messages.Success}");

            }
        }
    }


}

static void AddClassroom(ClassroomService classroomService, FileLogger fileLogger)
{
    Console.WriteLine(Messages.StraightLine);
    Console.Write(Messages.EnterAnId);
    string classroomIdString = Console.ReadLine();
    if (!ResultChecker.IdIntChecker(classroomIdString))
    {
        fileLogger.Log($"{classroomIdString} : {Messages.NotANumber} : {DateTime.Now} : {Messages.Error}");
        fileLogger.Log($"{Messages.ErrorClassroomAppend} : {DateTime.Now} : {Messages.Error}");
        Console.WriteLine(Messages.NotANumber);
    }
    else
    {
        int classroomId = Convert.ToInt32(classroomIdString);
        Console.Write(Messages.EnterAName);
        string classroomName = Console.ReadLine();
        if (!ResultChecker.NameSurnameStringChecker(classroomName))
        {

            fileLogger.Log($"{classroomId} : {DateTime.Now} : {Messages.Success}");
            fileLogger.Log($"{classroomName} : {Messages.NotAName} : {DateTime.Now} : {Messages.Error}");
            fileLogger.Log($"{Messages.ErrorClassroomAppend} : {DateTime.Now} : {Messages.Error}");
            Console.WriteLine(Messages.NotAName);
        }
        else
        {
            Console.WriteLine(Messages.StraightLine);
            classroomService.AddClassroom(classroomId, classroomName);
            Console.WriteLine(Messages.StraightLine);
            classroomService.ShowClassrooms();
            Console.WriteLine(Messages.StraightLine);
            fileLogger.Log($"{classroomIdString} {classroomName} : {DateTime.Now} : {Messages.Success}");
            fileLogger.Log($"{Messages.SuccessClassroomAppend} : {DateTime.Now} : {Messages.Success}");
        }
    }
}

static void AssignStudentToClass(StudentService studentService, ClassroomService classroomService, FileLogger fileLogger)
{

    Console.WriteLine(Messages.StraightLine);
    studentService.ShowStudents();
    if (!ResultChecker.ListEmptinessChecker(studentService.GetStudents()))
    {
        fileLogger.Log($"{Messages.ErrorStudentListEmpty} : {DateTime.Now} : {Messages.Error}");
        fileLogger.Log($"{Messages.ErrorStudentAssign} : {DateTime.Now} : {Messages.Error}");
        Console.WriteLine(Messages.StudentsAreEmpty);
    }
    else
    {
        Console.WriteLine(Messages.StraightLine);
        Console.Write(Messages.ChooseStudentIdToAddClass);
        string assignedStudentIdString = Console.ReadLine();
        if (!ResultChecker.IdIntChecker(assignedStudentIdString))
        {
            fileLogger.Log($"{assignedStudentIdString} : {DateTime.Now} : {Messages.Error}");
            fileLogger.Log($"{Messages.ErrorStudentAssign} : {DateTime.Now} : {Messages.Error}");
            Console.WriteLine(Messages.NotANumber);
        }
        else
        {
            int assignedStudentId = Convert.ToInt32(assignedStudentIdString);
            Console.WriteLine(Messages.StraightLine);
            classroomService.ShowClassrooms();
            if (!ResultChecker.ListEmptinessChecker(classroomService.GetClassrooms()))
            {
                fileLogger.Log($"{assignedStudentIdString} : {DateTime.Now} : {Messages.Success}");
                fileLogger.Log($"{Messages.ErrorClassListEmpty} : {DateTime.Now} : {Messages.Error}");
                fileLogger.Log($"{Messages.ErrorStudentAssign} : {DateTime.Now} : {Messages.Error}");
                Console.WriteLine(Messages.ClassesAreEmpty);
            }
            else
            {
                Console.WriteLine(Messages.StraightLine);
                Console.Write(Messages.ChooseClassIdToAddStudent);
                string assignedClassIdForStudentString = Console.ReadLine();
                if (!ResultChecker.IdIntChecker(assignedClassIdForStudentString))
                {
                    fileLogger.Log($"{assignedStudentIdString} : {DateTime.Now} : {Messages.Success}");
                    fileLogger.Log($"{assignedClassIdForStudentString} : {Messages.NotANumber} : {DateTime.Now} : {Messages.Error}");
                    fileLogger.Log($"{Messages.ErrorStudentAssign} : {DateTime.Now} : {Messages.Error}");
                    Console.WriteLine(Messages.NotANumber);
                }
                else
                {
                    int assignedClassIdForStudent = Convert.ToInt32(assignedClassIdForStudentString);

                    if (!classroomService.AssignStudent(studentService, assignedStudentId, assignedClassIdForStudent))
                    {
                        fileLogger.Log($"{assignedStudentIdString} to {assignedClassIdForStudent} : {DateTime.Now} : {Messages.Error}");
                        fileLogger.Log($"{Messages.ErrorStudentAssign} : {DateTime.Now} : {Messages.Error}");
                    }
                    else
                    {
                        Console.WriteLine(Messages.StraightLine);
                        classroomService.ShowClassrooms();
                        Console.WriteLine(Messages.StraightLine);
                        studentService.ShowStudents();
                        Console.WriteLine(Messages.StraightLine);
                        fileLogger.Log($"{assignedStudentIdString} to {assignedClassIdForStudent} : {DateTime.Now} : {Messages.Success}");
                        fileLogger.Log($"{Messages.SuccessStudentAssign} : {DateTime.Now} : {Messages.Success}");
                    }
                }

            }
        }
    }

}

static void AssignTeacherToClass(TeacherService teacherService, ClassroomService classroomService, FileLogger fileLogger)
{
    Console.WriteLine(Messages.StraightLine);
    teacherService.ShowTeachers();
    if (!ResultChecker.ListEmptinessChecker(teacherService.GetTeachers()))
    {
        fileLogger.Log($"{Messages.ErrorTeacherListEmpty} : {DateTime.Now} : {Messages.Error}");
        fileLogger.Log($"{Messages.ErrorTeacherAssign} : {DateTime.Now} : {Messages.Error}");
        Console.WriteLine(Messages.TeachersAreEmpty);
    }
    else
    {
        Console.WriteLine(Messages.StraightLine);
        Console.Write(Messages.ChooseTeacherIdToAddClass);
        string assignedTeacherIdString = Console.ReadLine();
        if (!ResultChecker.IdIntChecker(assignedTeacherIdString))
        {
            fileLogger.Log($"{assignedTeacherIdString} : {DateTime.Now} : {Messages.Error}");
            fileLogger.Log($"{Messages.ErrorTeacherAssign} : {DateTime.Now} : {Messages.Error}");
            Console.WriteLine(Messages.NotANumber);
        }
        else
        {
            int assignedTeacherId = Convert.ToInt32(assignedTeacherIdString);
            Console.WriteLine(Messages.StraightLine);
            classroomService.ShowClassrooms();
            if (!ResultChecker.ListEmptinessChecker(classroomService.GetClassrooms()))
            {
                fileLogger.Log($"{assignedTeacherIdString} : {DateTime.Now} : {Messages.Success}");
                fileLogger.Log($"{Messages.ErrorTeacherListEmpty} : {DateTime.Now} : {Messages.Error}");
                fileLogger.Log($"{Messages.ErrorTeacherAssign} : {DateTime.Now} : {Messages.Error}");
                Console.WriteLine(Messages.ClassesAreEmpty);
            }
            else
            {
                Console.WriteLine(Messages.StraightLine);
                Console.Write(Messages.ChooseClassIdToAddTeacher);
                string assignedClassIdForTeacherString = Console.ReadLine();
                if (!ResultChecker.IdIntChecker(assignedClassIdForTeacherString))
                {
                    fileLogger.Log($"{assignedTeacherIdString} : {DateTime.Now} : {Messages.Success}");
                    fileLogger.Log($"{assignedClassIdForTeacherString} : {Messages.NotANumber} : {DateTime.Now} : {Messages.Error}");
                    fileLogger.Log($"{Messages.ErrorStudentAssign} : {DateTime.Now} : {Messages.Error}");
                    Console.WriteLine(Messages.NotANumber);
                }
                else
                {
                    int assignedClassIdForTeacher = Convert.ToInt32(assignedClassIdForTeacherString);
                    if (!classroomService.AssignTeacher(teacherService, assignedTeacherId, assignedClassIdForTeacher))
                    {
                        fileLogger.Log($"{assignedTeacherIdString} to {assignedClassIdForTeacher} : {DateTime.Now} : {Messages.Error}");
                        fileLogger.Log($"{Messages.ErrorStudentAssign} : {DateTime.Now} : {Messages.Error}");
                    }
                    else
                    {
                        Console.WriteLine(Messages.StraightLine);
                        classroomService.ShowClassrooms();
                        Console.WriteLine(Messages.StraightLine);
                        teacherService.ShowTeachers();
                        Console.WriteLine(Messages.StraightLine);
                        fileLogger.Log($"{assignedTeacherIdString} to {assignedClassIdForTeacher} : {DateTime.Now} : {Messages.Success}");
                        fileLogger.Log($"{Messages.SuccessTeacherAssign} : {DateTime.Now} : {Messages.Success}");
                    }
                }

            }

        }

    }

}

static void SearchStudentById(StudentService studentService)
{
    Console.WriteLine(Messages.StraightLine);
    if (ResultChecker.ListEmptinessChecker(studentService.GetStudents()))
    {
        Console.WriteLine(Messages.ProvideStudentId);
        Console.Write(Messages.EnterAnId);
        string searchedStudentIdString = Console.ReadLine();
        if (ResultChecker.IdIntChecker(searchedStudentIdString))
        {
            int searchedStudentId = Convert.ToInt32(searchedStudentIdString);
            Student searchedStudentById = studentService.SearchStudentById(studentService.GetStudents(), searchedStudentId);
            studentService.ShowStudent(searchedStudentById);
            Console.WriteLine(Messages.StraightLine);
        }
        else
        {
            Console.WriteLine(Messages.NotANumber);
        }
    }
    else
    {
        Console.WriteLine(Messages.StudentsAreEmpty);
    }

}

static void SearchStudentByName(StudentService studentService)
{
    Console.WriteLine(Messages.StraightLine);
    if (ResultChecker.ListEmptinessChecker(studentService.GetStudents()))
    {
        Console.WriteLine(Messages.ProvideStudentName);
        Console.Write(Messages.EnterAName);
        string searchedStudentName = Console.ReadLine();
        if (ResultChecker.NameSurnameStringChecker(searchedStudentName))
        {
            Student searchedStudentByName = studentService.SearchStudentByName(studentService.GetStudents(), searchedStudentName);
            studentService.ShowStudent(searchedStudentByName);
            Console.WriteLine(Messages.StraightLine);
        }
        else
        {
            Console.WriteLine(Messages.NotANumber);
        }
    }
    else
    {
        Console.WriteLine(Messages.StudentsAreEmpty);
    }
}

static void SearchTeacherById(TeacherService teacherService)
{
    Console.WriteLine(Messages.StraightLine);
    if (ResultChecker.ListEmptinessChecker(teacherService.GetTeachers()))
    {
        Console.WriteLine(Messages.ProvideTeacherId);
        Console.Write(Messages.EnterAnId);
        string searchedTeacherIdString = Console.ReadLine();
        if (ResultChecker.IdIntChecker(searchedTeacherIdString))
        {
            int searchedTeacherId = Convert.ToInt32(searchedTeacherIdString);
            Teacher searchedTeacherById = teacherService.SearchTeacherById(teacherService.GetTeachers(), searchedTeacherId);
            teacherService.ShowTeacher(searchedTeacherById);
            Console.WriteLine(Messages.StraightLine);
        }
        else
        {
            Console.WriteLine(Messages.NotANumber);
        }
    }
    else
    {
        Console.WriteLine(Messages.TeachersAreEmpty);
    }
}

static void SearchTeacherByName(TeacherService teacherService)
{
    Console.WriteLine(Messages.StraightLine);
    if (ResultChecker.ListEmptinessChecker(teacherService.GetTeachers()))
    {
        Console.WriteLine(Messages.ProvideTeacherName);
        Console.Write(Messages.EnterAName);
        string searchedTeacherName = Console.ReadLine();
        if (ResultChecker.NameSurnameStringChecker(searchedTeacherName))
        {
            Teacher searchedTeacherByName = teacherService.SearchTeacherByName(teacherService.GetTeachers(), searchedTeacherName);
            teacherService.ShowTeacher(searchedTeacherByName);
            Console.WriteLine(Messages.StraightLine);
        }
        else
        {
            Console.WriteLine(Messages.NotAName);
        }
    }
    else
    {
        Console.WriteLine(Messages.TeachersAreEmpty);
    }

}

static void SearchClassById(ClassroomService classroomService)
{
    Console.WriteLine(Messages.StraightLine);
    if (ResultChecker.ListEmptinessChecker(classroomService.GetClassrooms()))
    {
        Console.WriteLine(Messages.ProvideClassroomId);
        Console.Write(Messages.EnterAnId);
        string searchedClassroomIdString = Console.ReadLine();
        if (ResultChecker.IdIntChecker(searchedClassroomIdString))
        {
            int searchedClassroomId = Convert.ToInt32(searchedClassroomIdString);
            Classroom searchedClassroomById = classroomService.SearchClassroomById(classroomService.GetClassrooms(), searchedClassroomId);
            classroomService.ShowClassroom(searchedClassroomById);
            Console.WriteLine(Messages.StraightLine);
        }
        else
        {
            Console.WriteLine(Messages.NotANumber);
        }

    }
    else
    {
        Console.WriteLine(Messages.ClassesAreEmpty);
    }
}

static void SearchClassByName(ClassroomService classroomService)
{
    Console.WriteLine(Messages.StraightLine);
    if (ResultChecker.ListEmptinessChecker(classroomService.GetClassrooms()))
    {
        Console.WriteLine(Messages.ProvideClassroomName);
        Console.Write(Messages.EnterAName);
        string searchedClassroomName = Console.ReadLine();
        if (ResultChecker.NameSurnameStringChecker(searchedClassroomName))
        {
            Classroom searchedClassroomByName = classroomService.SearchClassroomByName(classroomService.GetClassrooms(), searchedClassroomName);
            classroomService.ShowClassroom(searchedClassroomByName);
            Console.WriteLine(Messages.StraightLine);
        }
        else
        {
            Console.WriteLine(Messages.NotAName);
        }
    }
    else
    {
        Console.WriteLine(Messages.ClassesAreEmpty);
    }

}

static void SearchStudentInTheClassById(ClassroomService classroomService, StudentService studentService)
{
    Console.WriteLine(Messages.StraightLine);
    if (ResultChecker.ListEmptinessChecker(classroomService.GetClassrooms()))
    {
        foreach (Classroom classroom in classroomService.GetClassrooms())
        {
            if (ResultChecker.ListEmptinessChecker(classroom.Students))
            {
                classroomService.ShowClassrooms();
                SearchStudentById(studentService);
                Console.WriteLine(Messages.StraightLine);
                break;
            }
            else
            {
                Console.WriteLine(Messages.ClassesAreEmpty);
                break;
            }
        }
    }
    else
    {
        Console.WriteLine(Messages.ClassroomNotExist);

    }

}

static void SearchTeacherInTheClassById(ClassroomService classroomService, TeacherService teacherService)
{
    Console.WriteLine(Messages.StraightLine);
    if (ResultChecker.ListEmptinessChecker(classroomService.GetClassrooms()))
    {
        foreach (Classroom classroom in classroomService.GetClassrooms())
        {
            if (ResultChecker.EntityNullnessChecker(classroom.Teacher))
            {
                classroomService.ShowClassrooms();
                SearchTeacherById(teacherService);
                Console.WriteLine(Messages.StraightLine);
                break;
            }
            else
            {
                Console.WriteLine(Messages.ClassesAreEmpty);
                break;
            }
        }
    }
    else
    {
        Console.WriteLine(Messages.ClassroomNotExist);
    }
}

static string GetChoices()
{
    Console.WriteLine(Messages.StraightLine);
    Console.WriteLine(Messages.AddStudent);
    Console.WriteLine(Messages.AddTeacher);
    Console.WriteLine(Messages.AddClassroom);
    Console.WriteLine(Messages.AssignStudentToClass);
    Console.WriteLine(Messages.AssignTeacherToClass);
    Console.WriteLine(Messages.SearchingPage);
    Console.WriteLine(Messages.PressQToQuit);
    Console.Write(Messages.EnterAnOperation);
    string switchNumber = Console.ReadLine();
    Console.WriteLine(Messages.StraightLine);
    return switchNumber;
}

static string GetSearchChoices()
{
    Console.WriteLine(Messages.StraightLine);
    Console.WriteLine(Messages.SearchStudentById);
    Console.WriteLine(Messages.SearchStudentByName);
    Console.WriteLine(Messages.SearchTeacherById);
    Console.WriteLine(Messages.SearchTeacherByName);
    Console.WriteLine(Messages.SearchClassroomById);
    Console.WriteLine(Messages.SearchClassroomByName);
    Console.WriteLine(Messages.SearchStudentInTheClass);
    Console.WriteLine(Messages.SearchTeacherInTheClass);
    Console.WriteLine(Messages.PressQToQuit);
    Console.Write(Messages.EnterAnOperation);
    string secondSwitchNumber = Console.ReadLine();
    Console.WriteLine(Messages.StraightLine);
    return secondSwitchNumber;
}