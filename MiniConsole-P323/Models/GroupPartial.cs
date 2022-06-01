using MiniConsole_P323.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniConsole_P323.Models
{
    partial class Group
    {
        public override string ToString()
        {
            return $"{Name}";
        }
        public bool AddStudent(Student student)
        {
            if (students.Length==MaxCount)
            {
                return false;
            }
            Array.Resize(ref students, students.Length + 1);
            students[students.Length - 1] = student;
            return true;
        }
        public void ShowStudents()
        {
            Helper.Print($"{Name} qrupu", ConsoleColor.Yellow);
            foreach (var item in students)
            {
                Helper.Print(item.ToString(), ConsoleColor.Green);
            }

        }
    }
}
