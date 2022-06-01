using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniConsole_P323.Models
{
    class Student
    {
        public int Id { get; }
        public string FullName { get; }
        public static int _id;
        public Student()
        {
            Id = ++_id;
        }
        public Student(string fullname):this()
        {
            FullName = fullname;
        }
        public override string ToString()
        {
            return $"{Id}--{FullName}";
        }

    }
}
