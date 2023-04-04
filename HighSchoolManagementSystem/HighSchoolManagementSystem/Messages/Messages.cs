using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolManagementSystem.Messages
{
    public static class Messages
    {
        // Straight Line
        public static string StraightLine = "-------------------------------------------------------";

        // Operation reader
        public static string EnterAnOperation = "Enter an operation: ";

        // Pressing Q
        public static string PressQToQuit = "Press q to quit: ";

        // Adding functions
        public static string AddStudent = "1 - Add Student";
        public static string AddTeacher = "2 - Add Teacher";
        public static string AddClassroom = "3 - Add Classroom";

        // Assigning functions
        public static string AssignStudentToClass = "4 - Assign student to class";
        public static string AssignTeacherToClass = "5 - Assign teacher to class";

        // Searching page
        public static string SearchingPage = "6 - Searching page";

        // ID, Name, Surname
        public static string EnterAnId = "Enter an id: ";
        public static string EnterAName = "Enter a name: ";
        public static string EnterASurname = "Enter a surname: ";
        public static string ProvideStudentId = "Please provide a student id";
        public static string ProvideStudentName = "Please provide a student name";
        public static string ProvideTeacherId = "Please provide a teacher id";
        public static string ProvideTeacherName = "Please provide a teacher name";
        public static string ProvideClassroomId = "Please provide a classroom id";
        public static string ProvideClassroomName = "Please provide a classroom name";

        // Choosing functions
        public static string ChooseStudentIdToAddClass = "Choose a student id to add to a classroom: ";
        public static string ChooseClassIdToAddStudent = "Choose a classroom id to add student: ";
        public static string ChooseTeacherIdToAddClass = "Choose a teacher id to add to a classroom: ";
        public static string ChooseClassIdToAddTeacher = "Choose a class id to add teacher: ";

        // Searching functions
        public static string SearchStudentById = "1 - Search student by id";
        public static string SearchStudentByName = "2 - Search student by name";
        public static string SearchTeacherById = "3 - Search teacher by id";
        public static string SearchTeacherByName = "4 - Search teacher by name";
        public static string SearchClassroomById = "5 - Search classroom by id";
        public static string SearchClassroomByName = "6 - Search classroom by name";
        public static string SearchStudentInTheClass = "7 - Search student in the class";
        public static string SearchTeacherInTheClass = "8 - Search teacher in the class";

        // Error messages
        public static string StudentNotExist = "Student does not exist in the current content";
        public static string ClassroomNotExist = "Classroom does not exist in the current content";
        public static string TeacherNotExist = "Teacher does not exist in the current content";
        public static string ClassroomIsEmpty = "Classroom list is empty";
        public static string TeacherIsEmpty = "Teacher list is empty";
        public static string StudentIsEmpty = "Student list is empty";
        public static string NotANumber = "You did not provide a right input. Enter a number please";
        public static string NotAName = "You did not provide a right input. Enter a name please";
        public static string NotASurname = "You did not provide a right input. Enter a surname please";
        public static string StudentsAreEmpty = "You cannot make a choice since student list is empty";
        public static string ClassesAreEmpty = "You cannot make a choice since classroom list is empty";
        public static string TeachersAreEmpty = "You cannot make a choice since teacher list is empty";

        // Log Beginning message
        public static string LogBeginning = $"Those process have been made at";
        public static string AddStudentOperation = $"User have been entered the \"Add Student\" operation";
        public static string AddTeacherOperation = $"User have been entered the \"Add Teacher\" operation";
        public static string AddClassroomOperation = $"User have been entered the \"Add Classroom\" operation";
        public static string AssignStudentOperation = $"User have been entered the \"Assign Student To Classroom\" operation";
        public static string AssignTeacherOperation = $"User have been entered the \"Assign Teacher To Classroom\" operation";

        // Log success messages
        public static string Success = "[SUCCESS]";
        public static string SuccessQuit = "User have ended the session";
        public static string SuccessInput = "User have entered a right input while trying to choose the operation";
        public static string SuccessStudentAppend = $"Student have been added";
        public static string SuccessTeacherAppend = $"Teacher have been added";
        public static string SuccessClassroomAppend = $"Classroom have been added";
        public static string SuccessStudentAssign = $"Student have been assigned to class";
        public static string SuccessTeacherAssign = $"Teacher have been assigned to class";


        // Log error messages
        public static string Error = "[ERROR]";
        public static string ErrorInput = "User have entered a wrong input while trying to choose the operation";
        public static string ErrorStudentAppend = $"Student could not be added";
        public static string ErrorTeacherAppend = $"Teacher could not be added";
        public static string ErrorClassroomAppend = $"Classroom could not be added";
        public static string ErrorStudentAssign = $"Student could not be assigned to class";
        public static string ErrorTeacherAssign = $"Teacher could not be assigned to class";
        public static string ErrorClassListEmpty = $"Class user have choosen is empty";
        public static string ErrorStudentListEmpty = $"Students user have choosen is empty";
        public static string ErrorTeacherListEmpty = $"Teachers user have choosen is empty";
    }
}
