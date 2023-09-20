using System;
//using System.Collections.Generic;
//using System.IO;

class Program
{
    
    private static Random _random = new Random();        //objeto Random para generar lista de mensajes aleatorios
    private static List<string> _messages = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion you felt today?",
        "If you had one thing you could do today, what would it be?"
    };

    static void Main()
    {
        
        List<string> entries = new List<string>();     //lista para almacenar las entradas del diario.

        while (true)
        {
        
            Console.WriteLine("Diary Menu:");
            Console.WriteLine("1. Add an entry");
            Console.WriteLine("2. View entries");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Delete last entry");
            Console.WriteLine("6. Delete entire journal");
            Console.WriteLine("7. Quit");

            Console.Write("Select an option (1-7): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    
                    string randomMessage = GetRandomMessage();   //mensaje aleatorio
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    Console.WriteLine($"{currentDate}\n{randomMessage}");
                    Console.Write("Write your diary entry: ");
                    string entry = Console.ReadLine();
                    
                    entries.Add($"{currentDate}\n{randomMessage}\n{entry}\n");   //entrada al diario
                    break;

                case "2":
                    
                    Console.WriteLine("Diary Entries:\n");     //entradas almacenadas en el diario.
                    foreach (var item in entries)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case "3":
                    
                    Console.Write("Enter a filename to save the journal: ");    //Solicitud de nombre de archivo
                    string saveFileName = Console.ReadLine();
                    File.WriteAllLines(saveFileName, entries);    //guarda entradas en archivo.
                    Console.WriteLine("Journal saved successfully.");
                    break;

                case "4":
                    
                    Console.Write("Enter a filename to load the journal: ");  //Solicita a usuario nombre de archivo
                    string loadFileName = Console.ReadLine();
                    if (File.Exists(loadFileName))     //carga la entrada desde archivo si existe.
                    {
                        entries = new List<string>(File.ReadAllLines(loadFileName));
                        Console.WriteLine("Journal loaded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("File not found.");
                    }
                    break;

                case "5":
                    
                    if (entries.Count > 0)
                    {
                        entries.RemoveAt(entries.Count - 1);  //Elimina la última entrada (Previo a opción 3)
                        Console.WriteLine("Last entry deleted.");
                    }
                    else
                    {
                        Console.WriteLine("No entries to delete.");
                    }
                    break;

                case "6":
                    
                    entries.Clear();    //Borramos todas las entradas  INCOMPLETO
                    Console.WriteLine("Journal cleared.");
                    break;

                case "7":
                                            //Salimos del programa.
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    
    private static string GetRandomMessage()   //Obtención de mensaje aleatorio
    {
        int randomIndex = _random.Next(_messages.Count);
        return _messages[randomIndex];
    }
}