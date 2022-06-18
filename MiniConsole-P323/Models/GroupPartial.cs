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
            if (_students.Count==MaxCount)
            {
                return false;
            }
            _students.Add(student);
            
            return true;
        }
        public void ShowStudents()
        {
            Helper.Print($"{Name} qrupu", ConsoleColor.Yellow);
            foreach (var item in _students)
            {
                Helper.Print(item.ToString(), ConsoleColor.Green);
            }
        }
        public bool RemoveStudent(int id)
        {
            Student student = _students.Find(x=>x.Id== id);
            if (student==null)
            {
                return false;
            }
            _students.Remove(student);
            return true;
        }
        public void Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Helper.Print("Boshdux buraxma",ConsoleColor.Red);
                return;
            }
            List<Student> students = _students.FindAll(x => x.FullName.ToLower().Trim().Contains(name.ToLower().Trim()));
            if (students.Count==0)
            {
                Helper.Print("Tapilmadi", ConsoleColor.Red);
                return;
            }
            Helper.Print("Tapdiqiviz telebelerin siyahisi", ConsoleColor.Green);
            foreach (var item in students)
            {
                Helper.Print(item.ToString(), ConsoleColor.Red);
            }

        }
    }
}
