using HighSchoolManagementSystem.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolManagementSystem.Logger
{
    public class FileLogger :  ILogger
    {
        private readonly string filePath;

        public FileLogger()
        { 
            filePath = $@"{TakeProjectPath()}\logger.txt";
        }

        public void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(message);
            }
        }

        public string TakeProjectPath()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            int index = projectPath.IndexOf("\\bin");
            if (index > 0)
            {
                projectPath = projectPath.Substring(0, index);
            }
            return projectPath;
        }


    }
}
