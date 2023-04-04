using HighSchoolManagementSystem.Logger;
using HighSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolManagementSystem.Utilities
{
    public static class ResultChecker
    {
        public static bool IdValidateChecker<T>(T choosenObject)
        {
            if (choosenObject == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ListValidateChecker<T>(List<T> choosenList)
        {
            if (choosenList.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ListEmptinessChecker<T>(List<T> choosenList)
        {
            if (choosenList.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EntityNullnessChecker<T>(T choosenEntity)
        {
            if (choosenEntity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IdIntChecker(string id)
        {
            bool isDigit = false;
            foreach (char letter in id.ToCharArray().ToList())
            {
                if (char.IsLetter(letter))
                {
                    isDigit = false;
                }
                else if (!char.IsLetter(letter) && !char.IsDigit(letter))
                {
                    isDigit = false;
                }
                else
                {
                    isDigit = true;
                }
            }
            return isDigit;
        }

        public static bool NameSurnameStringChecker(string word)
        {
            bool isDigit = false;
            foreach (char letter in word.ToCharArray().ToList())
            {
                if (char.IsDigit(letter))
                {
                    isDigit = false;
                }
                else if (!char.IsLetter(letter) && !char.IsDigit(letter))
                {
                    isDigit = false;
                }
                else
                {
                    isDigit = true;
                }
            }
            return isDigit;
        }

        public static bool EventChecker(string eventSwitch, int start, int end)
        {
            if ((start<=Convert.ToInt32(eventSwitch)) && (Convert.ToInt32(eventSwitch)) <= end)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
