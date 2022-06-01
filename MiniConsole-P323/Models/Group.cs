using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniConsole_P323.Models
{
    partial class Group
    {
        public int Id { get; }
        private static int _id;
        public string Name { get; }
        public int MaxCount { get; }
        public Student[] students;
      public Group(string name,int maxCount)
        {
            Name = name;
            MaxCount = maxCount;
            Id = ++_id;
            students = new Student[0];
        }
    }
}
