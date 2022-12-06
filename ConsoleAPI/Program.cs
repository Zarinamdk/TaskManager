using System.Diagnostics;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace ConsoleAPI
{
    class Propgram
    {
        static void Main()
        {
            {
                StartNotepad();
                //StartOperaStr("https://ru.wikipedia.org/wiki/Заглавная_страница");
                StartWord();
                // StartExcel();
                //StartOpera();
                //StartPaint();
                List<string> processesList = ProcessesList();

                foreach (var process in processesList)
                {
                    Console.WriteLine(process);
                }
                Console.WriteLine("Введите ID: ");
                KillId(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введите Name: ");
                KillName();
                //StartNotepad(); 



                /// <summary>
                /// Список процессов
                /// </summary>
                /// <returns></returns>
                static List<string> ProcessesList()
                {
                    List<string> list = new List<string>();

                    Process[] processes = Process.GetProcesses();

                    foreach (var process in processes)
                    {
                        list.Add($"{process.Id} \t{process.ProcessName}");
                    }
                    return list;
                }

                /// <summary>
                /// Пример запуска процесса по имени (для системных стандартных процессов)
                /// </summary>
                static void StartNotepad()
                {
                    Process.Start("notepad");
                }
                static void StartPaint()
                {
                    Process.Start("mspaint");
                }

                /// <summary>
                /// Пример запуска процесса по exe
                /// </summary>
                static void StartWord()
                {
                    string path = @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE";
                    if (File.Exists(path))
                    {
                        Process.Start(path);
                    }
                    else
                    {
                        Console.WriteLine("Неверная директория");
                    }
                }
                static void StartExcel()
                {
                    string path = @"C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE";
                    if (File.Exists(path))
                    {
                        Process.Start(path);
                    }
                    else
                    {
                        Console.WriteLine("Неверная директория");
                    }
                }
                static void StartOpera()
                {
                    string path = @"C:\Program Files\Opera GX\opera.exe";
                    if (File.Exists(path))
                    {
                        Process.Start(path);
                    }
                    else
                    {
                        Console.WriteLine("Неверная директория");
                    }
                }

                /// <summary>
                /// Пример запуска процесса по exe + открытие странички
                /// </summary>
                static void StartOperaStr(string address)
                {
                    ProcessStartInfo procInfo = new ProcessStartInfo();

                    string path = @"C:\Program Files\Opera GX\opera.exe";

                    if (File.Exists(path))
                    {
                        // Вариант 1
                        Process.Start(path, address);

                        // Вариант 2
                        /*
                        procInfo.FileName = path;
                        procInfo.Arguments = address;
                        Process.Start(procInfo);
                        */
                    }
                    else
                    {
                        Console.WriteLine("Неверная директория");
                    }
                }

                static void KillId(int id)
                {
                    Process.GetProcessById(id).Kill();
                }

                static void KillName()
                {
                    string name = Console.ReadLine();
                    Process[] procList = Process.GetProcesses();
                    foreach (var proc in procList)
                    {
                        if (proc.ProcessName == name)
                        {
                            proc.Kill();
                        }
                    }
                }

                /*
                bool running = true;
                while (running)                // запускаем бесконечный цикл
                {
                    Console.Write("Введите kill по id или name: ");
                    string command = Console.ReadLine();

                    switch (command)
                    {
                        case "clear":
                            Clear();
                            break;
                        case "killid":
                            Console.Write("Введите id: ");
                            KillId1(Convert.ToInt32(Console.ReadLine()));
                            break;
                        case "killname":
                            Console.Write("Введите name: ");
                            KillName1();
                            break;
                        case "exit":
                            running = false;
                            break;
                    }
                }
                static void Clear()
                {
                    Console.Clear();
                }
                static void KillId1(int id1)
                {
                    Process.GetProcessById(id1).Kill();
                }
                static void KillName1()
                {
                    string name = Console.ReadLine();
                    Process[] procList = Process.GetProcesses();
                    foreach (var proc in procList)
                    {
                        if (proc.ProcessName == name)
                        {
                            proc.Kill();
                        }
                    }
                }
                */             
            }
        }
    }
}