using MiniConsole_P323.Helpers;
using MiniConsole_P323.Models;
using System;

namespace MiniConsole_P323
{
    class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[0];
            while (true)
            {
                Helper.Print("1-Qrup yarat,2-Qrupa telebe elave et,3-telebelerin siyahisini goster,4-cixish",
                    ConsoleColor.Green);
                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int menu);
                if (isInt && menu>=1 && menu <=4)
                {
                    if (menu==5)
                    {
                        break;
                    }
                    switch (menu)
                    {
                        
                        case 1:
                            Helper.Print("Qrup adi daxil et", ConsoleColor.Yellow);
                            string groupName = Console.ReadLine();
                            foreach (var item in groups)
                            {
                                if (item.Name.ToLower()== groupName.ToLower())
                                {
                                    Helper.Print($"{groupName} adli qrup movcuddur!!", ConsoleColor.Red);
                                    goto case 1;
                                }
                            }
                            InputMaxCount:
                            Helper.Print("Qrupun max sayini daxil et", ConsoleColor.Yellow);
                            string IsmaxCount = Console.ReadLine();
                            isInt = int.TryParse(result, out int maxCount);
                            if (!isInt)
                            {
                                Helper.Print("Duzgun daxil et", ConsoleColor.Red);
                                goto InputMaxCount;
                            }
                            Group group = new Group(groupName, maxCount);
                            Array.Resize(ref groups, groups.Length + 1);
                            groups[groups.Length - 1] = group;
                            Helper.Print($"{groupName}--yaradildi", ConsoleColor.Green);
                            break;
                            case 2:
                            if (groups.Length==0)
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
                           Group ExistGroup= Array.Find(groups, x => x.Name == ExistGroupName);
                            if (ExistGroup==null)
                            {
                                Helper.Print("Bu adda group movcud deyil", ConsoleColor.Red);
                                goto inputGroup;
                            }
                          
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
