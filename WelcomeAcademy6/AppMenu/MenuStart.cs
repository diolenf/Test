using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeAcademy6.DataModel;
using WelcomeAcademy6.BLogic;
using Microsoft.VisualBasic;

namespace WelcomeAcademy6.AppMenu
{
    internal static class MenuStart
    {
        public static void Show()
        {
            bool exitLoop = false;
            string lineSeparator = new('-', 75);
            WorkerManager workerManager = new();

            try
            {
                while (!exitLoop)
                {
                    Console.Clear();
                    Console.WriteLine(lineSeparator);
                    Console.WriteLine("Benvenuto in Academy6 Corporation");
                    Console.WriteLine(lineSeparator);
                    Console.WriteLine();
                    Console.WriteLine("1. Inserimento Lavoratore");
                    Console.WriteLine(lineSeparator);
                    Console.WriteLine("2. Inserimento Settimana Lavorativa");
                    Console.WriteLine(lineSeparator);
                    Console.WriteLine("3. Eliminazione Lavoratore --> giorno lavorativo");
                    Console.WriteLine(lineSeparator);
                    Console.WriteLine("4. Visualizzazione Lavoratori");
                    Console.WriteLine(lineSeparator);
                    Console.WriteLine("5. Ricera Lavoratore --> Matricola, Nominativo, Giorno lavorativo");
                    Console.WriteLine(lineSeparator);
                    Console.WriteLine("6. Importa lavoratori da file esterno");
                    Console.WriteLine(lineSeparator);
                    Console.WriteLine("7. Esci");
                    Console.WriteLine(lineSeparator);
                    Console.WriteLine("8. Ricerca Lavoratori");
                    Console.WriteLine(lineSeparator);
                    Console.WriteLine("9. Salva Elenco Lavoratori su File esterno.");
                    Console.WriteLine(lineSeparator);
                    Console.WriteLine("10. Estrazione Dati Lavoratori con Lambda Expression / LinQ.");
                    Console.WriteLine(lineSeparator);
                    Console.Write("Eseguire scelta da 1 a 9: ");

                    //ConsoleKeyInfo sceltaString = Console.ReadKey();
                    string sceltaString = Console.ReadLine();
                    bool resultChoice = int.TryParse(sceltaString, out int scelta);

                    switch (scelta)
                    {
                        case 1:
                            workerManager.Insert();
                            break;
                        case 2:
                            workerManager.InsertWorkDays(new Worker());
                            break;
                        case 3:
                            Console.WriteLine("\nEliminazione Lavoratore --> giorno lavorativo");
                            break;
                        case 4:
                            workerManager.PrintWorkers();
                            break;
                        case 5:
                            Console.WriteLine("\nRicerca Lavoratore --> Matricola, Nominativo, Giorno lavorativo");
                            break;
                        case 6:
                            workerManager.ImportWorkersFile("E:\\Claude61\\CLALearning\\FileDati\\Employees2.txt");
                            break;
                        case 7:
                            Console.WriteLine("\nUscita dal programma");
                            exitLoop = true;
                            break;
                        case 8:
                            string typeValue = string.Empty;
                            Console.Write("\nRicerca: inserire un valore tra Matricola, Nominativo, Data lavorativa: ");
                            string sValue = Console.ReadLine();
                            switch (sValue.Length)
                            {
                                case 4:
                                    typeValue = "Ricerca per Matricola";
                                    break;
                                case > 4:
                                    if (!DateTime.TryParse(sValue, out DateTime validDate))
                                        typeValue = "Ricerca per Nominativo";
                                    else
                                        typeValue = "Ricerca per Data lavorativa";
                                    break;
                            }
                            List<Worker> foundWs = workerManager.FindAndShowWorkers(sValue.ToUpper());
                            
                            Console.WriteLine(lineSeparator);
                            Console.WriteLine($"\n{typeValue}");
                            Console.WriteLine(lineSeparator);

                            foreach (var w in foundWs)
                            {
                                Console.WriteLine($"Matricola: {w.Matricola} - " +
                                    $"Nominativo: {w.FullName} - Ruolo: {w.Role} - Dipartimento: {w.Department}");
                                Console.WriteLine(lineSeparator);
                                foreach (var wd in w.WorkDays)
                                {
                                    Console.WriteLine($"Data: {wd.ActivityDate} - Tipo Lavoro: {wd.JobType} - Ore: {wd.TotalHours}");
                                }
                            }
                            break;
                            case 9:
                            //workerManager.ExportWorkersToXml();
                            //workerManager.ImportWOrkersFromJson();

                            bool saveJson = false;

                            Console.Write("\nSalvataggio su file Json? (S/N): ");
                            string choiceValue = Console.ReadLine();
                            saveJson = choiceValue.ToUpper() == "S" ? true : false;

                            workerManager.SaveWorkersToFile(saveJson);
                            break;
                        case 10:
                            workerManager.RunLambdaExpressionAndLinQ();
                            break;
                        default:
                            Console.WriteLine("\nScelta non valida");
                            break;
                    }

                    Console.WriteLine("Premere un tasto per continuare");
                    _ = Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($":ATTENZIONE: Errore imprevisto {ex.Message}");
            }
        }
    }
}