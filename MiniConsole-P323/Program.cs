using MiniConsole_P323.Helpers;
using MiniConsole_P323.Models;
using System;
using System.Collections.Generic;

namespace MiniConsole_P323
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Group> groups = new List<Group>();
            while (true)
            {
                Helper.Print("1-Qrup yarat,2-Qrupa telebe elave et,3-Telebeni sil,4-telebelerin siyahisini goster,5-Axtarish,6-Cixish",
                    ConsoleColor.Green);
                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int menu);
                if (isInt && menu>=1 && menu <=6)
                {
                    if (menu==6)
                    {
                        break;
                    }
                    switch (menu)
                    {
                        case 1:
                            Helper.Print("Qrup adi daxil et", ConsoleColor.Yellow);
                            string groupName = Console.ReadLine();
                            if (groups.Exists(x => x.Name.ToLower() == groupName.ToLower()))
                            {
                                Helper.Print("Bu qrup artiq movcuddur!!!", ConsoleColor.Red);
                                goto case 1;
                            }
                            InputMaxCount:
                            Helper.Print("Qrupun max sayini daxil et", ConsoleColor.Yellow);
                            string IsmaxCount = Console.ReadLine();
                            isInt = int.TryParse(IsmaxCount, out int maxCount);
                            if (!isInt)
                            {
                                Helper.Print("Duzgun daxil et", ConsoleColor.Red);
                                goto InputMaxCount;
                            }
                            Group group = new Group(groupName, maxCount);
                            groups.Add(group);
                            Helper.Print($"{groupName}--yaradildi", ConsoleColor.Green);
                            break;
                            case 2:
                            if (groups.Count==0)
                            {
                                Helper.Print("Group yoxdur", ConsoleColor.Red);
                                goto case 1;
                            }
                            inputGroup:
                            Helper.Print("Qruplarimin siyahisi", ConsoleColor.Yellow);
                            foreach (var item in groups)
                            {
                                Helper.Print(item.ToString(), ConsoleColor.Yellow);
                            }
                            string ExistGroupName = Console.ReadLine();
                           Group ExistGroup= groups.Find(x => x.Name == ExistGroupName);
                            if (ExistGroup==null)
                            {
                                Helper.Print("Bu adda group movcud deyil", ConsoleColor.Red);
                                goto inputGroup;
                            }
                            Helper.Print("Telebenin ad soyadini yaz", ConsoleColor.Green);
                            string fullname = Console.ReadLine();
                            Student student = new Student(fullname);
                            if (!ExistGroup.AddStudent(student))
                            {
                                Helper.Print("Limiti Ashmisiniz!!!", ConsoleColor.Red);
                                goto inputGroup;
                            }
                            Helper.Print($"{ExistGroup} {student} elave olundu ", ConsoleColor.Green);
                            break;
                        case 3:
                            if (groups.Count == 0)
                            {
                                Helper.Print("Group yoxdur", ConsoleColor.Red);
                                goto case 1;
                            }
                        inputGroup2:
                            Helper.Print("Qruplarimin siyahisi", ConsoleColor.Yellow);
                            foreach (var item in groups)
                            {
                                Helper.Print(item.ToString(), ConsoleColor.Yellow);
                            }
                            ExistGroupName = Console.ReadLine();
                            ExistGroup = groups.Find(x => x.Name == ExistGroupName);
                            if (ExistGroup == null)
                            {
                                Helper.Print("Bu adda group movcud deyil", ConsoleColor.Red);
                                goto inputGroup2;
                            }
                            removableStu:
                            ExistGroup.ShowStudents();
                            Helper.Print("Silmek istediyiviz telebenin id-ni qeyd edin", ConsoleColor.Green);
                            int id = int.Parse(Console.ReadLine());
                            if (!ExistGroup.RemoveStudent(id))
                            {
                                Helper.Print($"{id}-li telebe movcud deyil!!!", ConsoleColor.Red);
                                goto removableStu;
                            }
                            Helper.Print($"{id}-li telebe Silindi!!!", ConsoleColor.Green);
                            break;
                        case 4:
                            if (groups.Count == 0)
                            {
                                Helper.Print("Group yoxdur", ConsoleColor.Red);
                                goto case 1;
                            }
                            foreach (var item in groups)
                            {
                                item.ShowStudents();
                            }
                            break;
                        case 5:
                            if (groups.Count == 0)
                            {
                                Helper.Print("Group yoxdur", ConsoleColor.Red);
                                goto case 1;
                            }
                        inputGroup3:
                            Helper.Print("Qruplarimin siyahisi", ConsoleColor.Yellow);
                            foreach (var item in groups)
                            {
                                Helper.Print(item.ToString(), ConsoleColor.Yellow);
                            }
                            ExistGroupName = Console.ReadLine();
                            ExistGroup = groups.Find(x => x.Name == ExistGroupName);
                            if (ExistGroup == null)
                            {
                                Helper.Print("Bu adda group movcud deyil", ConsoleColor.Red);
                                goto inputGroup3;
                            }
                            Helper.Print("Axtardiqiviz telebenin adini qeyd edin", ConsoleColor.Green);
                            string serach = Console.ReadLine();
                            ExistGroup.Search(serach);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Helper.Print("Duzgun daxil edin",
                   ConsoleColor.Red);
                   
                }
            }
        }
    }
}
