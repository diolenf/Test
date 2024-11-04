using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using WelcomeAcademy6.DataModel;

namespace WelcomeAcademy6.BLogic
{

    #region Metodi Privati
    #endregion

    #region Metodi Pubblici


    // Commenti : lkdjfldsfjsdjfk
    public class WorkerManager
    {
        string lineSeparator = new('-', 90);
        private Worker worker = new();
        public List<Worker> Workers = [];
        public List<Worker> WorkersErrors = [];
        private List<Worker> foundWorkers = [];

        /// <summary>
        /// Funzione per l'inserimento di un lavoratore
        /// </summary>
        /// <returns>Ritorna true/false se l'inserimento nella lista è riuscito</returns>
        public bool Insert()
        {
            bool result = false;
            bool isValidField = false;
            int xCursor = 0;
            int yCursor = 0;

            try
            {
                Console.Clear();
                Console.WriteLine("Inserimento Lavoratore");
                Console.WriteLine(lineSeparator);
                Console.Write("Inserire Numero Matricola: ");

                xCursor = Console.GetCursorPosition().Left;
                yCursor = Console.GetCursorPosition().Top;

                string matricola = string.Empty;
                while (!isValidField)
                {
                    matricola = Console.ReadLine();
                    if (matricola.Length == 4)
                    {
                        isValidField = true;
                    }
                    else
                    {
                        Console.WriteLine("Obblicatori 4 caratteri");
                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.Write(new string(' ', matricola.Length));
                        Console.SetCursorPosition(xCursor, yCursor);
                    }
                }
                isValidField = false;

                string fullName = string.Empty;
                Console.Write("Inserire Nominativo completo: ");

                xCursor = Console.GetCursorPosition().Left;
                yCursor = Console.GetCursorPosition().Top;
                while (!isValidField)
                {
                    fullName = Console.ReadLine();
                    if (fullName.Length >= 3)
                    {
                        isValidField = true;
                    }
                    else
                    {
                        Console.WriteLine("Almeno tre caratteri");
                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.Write(new string(' ', fullName.Length));
                        Console.SetCursorPosition(xCursor, yCursor);
                    }
                }

                isValidField = false;
                Console.Write("Inserire Ruolo aziendale: ");

                xCursor = Console.GetCursorPosition().Left;
                yCursor = Console.GetCursorPosition().Top;
                string role = string.Empty;
                while (!isValidField)
                {
                    role = Console.ReadLine();
                    if (role.Length >= 3)
                    {
                        isValidField = true;
                    }
                    else
                    {
                        Console.WriteLine("Almeno tre caratteri");
                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.Write(new string(' ', role.Length));
                        Console.SetCursorPosition(xCursor, yCursor);
                    }
                }

                isValidField = false;
                Console.Write("Inserire dipartimento: ");

                xCursor = Console.GetCursorPosition().Left;
                yCursor = Console.GetCursorPosition().Top;
                string department = string.Empty;
                while (!isValidField)
                {
                    department = Console.ReadLine();
                    if (department.Length >= 3)
                    { isValidField = true; }
                    else
                    {
                        Console.WriteLine("Almeno tre caratteri");
                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.Write(new string(' ', department.Length));
                        Console.SetCursorPosition(xCursor, yCursor);
                    }
                }
                Console.Write("Inserire età (maggiore/uguale 18): ");
                _ = int.TryParse(Console.ReadLine(), out int validAge);
                int age = validAge;
                Console.WriteLine("Inserire indirizzo: ");
                string address = Console.ReadLine();
                Console.WriteLine("Inserire città: ");
                string city = Console.ReadLine();
                Console.WriteLine("Inserire provincia: ");
                string province = Console.ReadLine();
                Console.WriteLine("Inserire CAP: ");
                string cap = Console.ReadLine();
                Console.WriteLine("Inserire telefono: ");
                string phone = Console.ReadLine();

                worker = new(matricola, fullName, role, department, age, address, city, province, cap, phone);

                //worker.WorkDays.Add(new(1, DateTime.Now, "Trasferta", 9, matricola)); // OKKIO, qui va messa,
                // eventualmente, la logica per
                // l'inserimento della giornata lavorativa
                InsertWorkDays(worker, matricola);

                Workers.Add(worker);

                result = true;
                Console.WriteLine("Lavoratore inserito correttamente");

                // Versione due per il caricamento worker nella lista e di seguito carcamento giornata lavorativa
                //Workers.Add(new(matricola, fullName, role, department, age, address, city, province, cap, phone));
                // potrei richiedere i dati della giornata di lavoro e inserirli sul worker appena creato
                //Workers[Workers.Count - 1].WorkDays.Add(new(1,DateTime.Now,"Trasferta",9, matricola));
            }
            catch (Exception ex)
            {
                Console.WriteLine($":ATTENZIONE: Errore imprevisto {ex.Message}");
            }

            return result;
        }

        public void InsertWorkDays(Worker worker, string matricola = "")
        {

            bool isValidField = false;
            bool isAnotherWorkDay = true;
            int xCursor = 0;
            int yCursor = 0;
            int xStartCursor;
            int yStartCursor;

            Console.WriteLine(lineSeparator);
            Console.WriteLine("Inserimento Giornate Lavoro ");
            Console.WriteLine(lineSeparator);


            xCursor = Console.GetCursorPosition().Left;
            yCursor = Console.GetCursorPosition().Top;

            if (matricola == string.Empty)
            {
                Console.Write("Inserire Matricola:  ");
                matricola = Console.ReadLine();
                if (Workers.Find(worker => worker.Matricola == matricola) == null)
                {
                    Console.WriteLine("Matricola non trovata");
                    return;
                }
                else
                {
                    worker = Workers.Find(worker => worker.Matricola == matricola);
                }
            }

            xStartCursor = Console.GetCursorPosition().Left;
            yStartCursor = Console.GetCursorPosition().Top;

            while (isAnotherWorkDay)
            {
                isValidField = false;
                DateTime workDayDate = new(1001, 1, 1);
                Console.Write("Inserire Data: ");
                while (!isValidField)
                {
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime validDate))
                    {
                        workDayDate = validDate;
                        isValidField = true;
                    }
                    else
                    {
                        Console.WriteLine("Data non valida.");
                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.Write(new string(' ', validDate.ToString().Length));
                        Console.SetCursorPosition(xCursor, yCursor);
                    }
                }
                isValidField = false;

                string jobType = string.Empty;
                Console.Write("Inserire Tipo Attivita: ");

                xCursor = Console.GetCursorPosition().Left;
                yCursor = Console.GetCursorPosition().Top;
                while (!isValidField)
                {
                    jobType = Console.ReadLine();
                    if (jobType.Length >= 3)
                    {
                        isValidField = true;
                    }
                    else
                    {
                        Console.WriteLine("Almeno tre caratteri");
                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.Write(new string(' ', jobType.Length));
                        Console.SetCursorPosition(xCursor, yCursor);
                    }
                }

                isValidField = false;
                Console.Write("Inserire totale ore lavorate : ");

                xCursor = Console.GetCursorPosition().Left;
                yCursor = Console.GetCursorPosition().Top;
                decimal hoursActivity = 0;
                while (!isValidField)
                {
                    if (decimal.TryParse(Console.ReadLine(), out decimal validHours))
                    {
                        isValidField = true;
                    }
                    else
                    {
                        Console.WriteLine("Inserire un numero intero o con un decimale.");
                        Console.SetCursorPosition(xCursor, yCursor);
                        Console.Write(new string(' ', hoursActivity.ToString().Length));
                    }
                }

                worker.WorkDays.Add(new(worker.WorkDays.Count + 1, workDayDate, jobType, hoursActivity, matricola));
                Console.Write("Vuoi inserire un'altra giornata lavorativa? (S/ altro carattere per NO) ");

                isAnotherWorkDay = Console.ReadLine().ToUpper() != "S" ? false : true;
                if (isAnotherWorkDay)
                {
                    Console.SetCursorPosition(xStartCursor, yStartCursor);
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(xStartCursor, yStartCursor);
                }
            }
        }

        public void PrintWorkers()
        {
            int screenRows = 40;
            //Workers.ForEach(w => Console.WriteLine($"Matricola: {w.Matricola}\nNominativo: {w.FullName}\nRuolo: {w.Role}\nDipartimento: {w.Department}\nEtà: {w.Age}\nIndirizzo: {w.Address}\nCittà: {w.City}\nProvincia: {w.Province}\nCAP: {w.Cap}\nTelefono: {w.Phone}"));
            Console.Clear();
            foreach (Worker worker in Workers)
            {
                Console.WriteLine(lineSeparator);
                Console.WriteLine("Anagrafica Lavoratore");
                Console.WriteLine(lineSeparator);

                Console.WriteLine($"Matricola: {worker.Matricola}");
                Console.WriteLine($"Nominativo: {worker.FullName}");
                Console.WriteLine($"Ruolo: {worker.Role}");
                Console.WriteLine($"Dipartimento: {worker.Department}");
                Console.WriteLine($"Età: {worker.Age}");
                Console.WriteLine($"Indirizzo: {worker.Address}");
                Console.WriteLine($"Città: {worker.City}");
                Console.WriteLine($"Provincia: {worker.Province}");
                Console.WriteLine($"CAP: {worker.Cap}");
                Console.WriteLine($"Telefono: {worker.Phone}");

                Console.WriteLine(lineSeparator);
                Console.WriteLine("\tGiornate Lavorative");
                Console.WriteLine(lineSeparator);

                foreach (WorkDay workDay in worker.WorkDays)
                {
                    Console.WriteLine($"\tData: {workDay.ActivityDate} - " +
                        $"Tipo Attività: {workDay.JobType} - Ore: {workDay.TotalHours} - " +
                        $"Matricola: {workDay.Matricola}");
                }

                if ((screenRows % 40) == 0)
                {
                    Console.WriteLine("Premere un tasto per continuare");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine(lineSeparator);
            Console.WriteLine("*********************** Lavoratori con errori *******************");
            Console.WriteLine(lineSeparator);

            foreach (Worker worker in WorkersErrors)
            {
                Console.WriteLine($"Matricola: {worker.Matricola}");
                Console.WriteLine($"Nominativo: {worker.FullName}");
                Console.WriteLine($"Ruolo: {worker.Role}");
                Console.WriteLine($"Dipartimento: {worker.Department}");
                Console.WriteLine($"Età: {worker.Age}");
                Console.WriteLine($"Indirizzo: {worker.Address}");
                Console.WriteLine($"Città: {worker.City}");
                Console.WriteLine($"Provincia: {worker.Province}");
                Console.WriteLine($"CAP: {worker.Cap}");
                Console.WriteLine($"Telefono: {worker.Phone}");
            }
        }
        public void ImportWorkersFile(string pathFile)
        {
            try
            {
                string[] stringWorkers = File.ReadAllLines(pathFile);
                string[] daysWork = File.ReadAllLines("E:\\Claude61\\CLALearning\\FileDati\\EmployeesActivities.txt");
                //e &&, diverso !=, oppure ||, uguaglianza ==,
                //minore uguale <=, maggiore uguale >=

                foreach (string worker in stringWorkers)
                {
                    if ((worker.Split(';')[0].Length == 4) && (int.TryParse(worker.Split(';')[4], out int validAge) == true))
                    {
                        Workers.Add(new(worker.Split(';')[0], worker.Split(';')[1],
                            worker.Split(';')[2], worker.Split(';')[3],
                            int.Parse(worker.Split(';')[4]), worker.Split(';')[5],
                            worker.Split(';')[6], worker.Split(';')[7], worker.Split(';')[8],
                            worker.Split(';')[9]));
                        foreach (string day in daysWork)
                        {
                            if (worker.Split(';')[0] == day.Split(';')[3])
                            {
                                Workers[Workers.Count - 1].WorkDays.Add(new(Workers[Workers.Count - 1].WorkDays.Count + 1,
                                    DateTime.Parse(day.Split(';')[0]), day.Split(';')[1],
                                    decimal.Parse(day.Split(';')[2]), day.Split(';')[3]));
                            }
                        }
                    }
                    else
                    {
                        WorkersErrors.Add(new(worker.Split(';')[0], worker.Split(';')[1],
                            worker.Split(';')[2], worker.Split(';')[3],
                            int.TryParse(worker.Split(';')[4], out int valid) ? valid : -1, worker.Split(';')[5],
                            worker.Split(';')[6], worker.Split(';')[7], worker.Split(';')[8],
                            worker.Split(';')[9]));
                    }
                }
                //string Workers = File.ReadAllText(pathFile);
                Console.WriteLine("File importato correttamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRORE ACCESSO FILE: {ex.Message}");
            }
        }

        public List<Worker> FindAndShowWorkers(string findValue = "")
        {

            bool isDate = DateTime.TryParse(findValue, out DateTime validDate);

            if (Workers.Count == 0)
            {
                Console.WriteLine("Nessun lavoratore presente");
                return foundWorkers;
            }
            else
            {
                switch (findValue.Length)
                {
                    case 4:
                        foreach (Worker worker in Workers)
                        {
                            if (worker.Matricola.Equals(findValue, StringComparison.CurrentCultureIgnoreCase))
                            {
                                foundWorkers.Add(worker);
                            }
                        }



                        break;
                    case > 4:
                        if (!DateTime.TryParse(findValue, out DateTime vDate))
                        {
                            foreach (Worker worker in Workers)
                            {
                                if (worker.FullName.ToUpper().Contains(findValue))
                                {
                                    foundWorkers.Add(worker);
                                }
                            }

                            //foundWorkers = Workers.FindAll(wk => wk.FullName.Equals(findValue, StringComparison.CurrentCultureIgnoreCase));
                        }
                        else
                        {
                            foreach (Worker worker in Workers)
                            {
                                foreach (WorkDay workDay in worker.WorkDays)
                                {
                                    if (workDay.ActivityDate == validDate)
                                    {
                                        foundWorkers.Add(worker);
                                    }
                                }
                            }
                        }
                        break;
                }


                return foundWorkers;
            }
        }

        public void SaveWorkersToFile(bool saveJson)
        {
            string fileName = "SaveNewEmployees.txt";
            string savePath = "E:\\Claude61\\CLALearning\\FileDati";
            //string SaveWorkers = string.Empty;
            StringBuilder SaveWorkers = new();
            string saveWorkersJson = string.Empty;

            try
            {
                foreach (Worker worker in Workers)
                {
                    SaveWorkers.AppendLine($"{worker.Matricola};{worker.FullName};{worker.Role}");
                }

                if (saveJson)
                {
                    fileName = "SaveNewEmployees.json";

                    saveWorkersJson = JsonSerializer
                        .Serialize(Workers, new JsonSerializerOptions { WriteIndented = true });

                    File.WriteAllText(Path.Combine(savePath, fileName), saveWorkersJson.ToString());
                }
                else
                { File.WriteAllText(Path.Combine(savePath, fileName), SaveWorkers.ToString()); }
            }
            catch (Exception ex)
            {
            }
        }

        public void ImportWOrkersFromJson()
        {
            string savePath = "E:\\Claude61\\CLALearning\\FileDati\\SaveNewEmployees.json";

            try
            {
                string sWorkers = File.ReadAllText(savePath);
                Workers = JsonSerializer.Deserialize<List<Worker>>(sWorkers);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public void ExportWorkersToXml()
        {
            string savePath = "E:\\Claude61\\CLALearning\\FileDati\\SaveNewEmployees.xml";
            XmlSerializer xmlSerializer = new(typeof(List<Worker>));
            StreamWriter stream = new(savePath);
            xmlSerializer.Serialize(stream, Workers);
            stream.Close();

            Workers.Clear();

            XmlSerializer xmlSerializer1 = new(typeof(List<Worker>));
            StreamReader streamReader = new(savePath);
            Workers = (List<Worker>)xmlSerializer1.Deserialize(streamReader);
            streamReader.Close();
        }

        public void RunLambdaExpressionAndLinQ()
        {
            // LINQ --> Language Integrated Query

            ImportWorkersFile("E:\\Claude61\\CLALearning\\FileDati\\Employees.txt");

            Console.WriteLine(lineSeparator);
            Console.WriteLine("Ricerca lavoratore per Matricola");
            Console.WriteLine(lineSeparator);

            Worker? wk = Workers.Find(wk => wk.Matricola.Equals("i001", StringComparison.CurrentCultureIgnoreCase));
            Worker? wk2 = Workers.Find(wk => wk.Matricola == "i001");

            if (wk != null)
                foundWorkers.Add(wk);

            Console.WriteLine(lineSeparator);
            Console.WriteLine("Ricerca lavorator(i) per Nominativo");
            Console.WriteLine(lineSeparator);

            //foundWorkers = Workers.FindAll(wk => wk.FullName.Contains("Jenn", StringComparison.CurrentCultureIgnoreCase));
            foundWorkers.AddRange(Workers.FindAll(wk => wk.FullName.Contains("Jenn", StringComparison.CurrentCultureIgnoreCase)));

            Console.WriteLine(lineSeparator);
            Console.WriteLine("Ricerca lavorati per città e età maggiore di 30 anni");
            Console.WriteLine(lineSeparator);

            //foundWorkers= Workers.FindAll(wk => wk.City.Contains("Roma", StringComparison.CurrentCultureIgnoreCase) && wk.Age > 30);
            foundWorkers.AddRange(Workers.Where(wk => wk.City.Contains("Roma", StringComparison.CurrentCultureIgnoreCase) && wk.Age > 30).ToList());
            //foundWorkers = Workers.FindAll(wk => wk.City.StartsWith("Roma", StringComparison.CurrentCultureIgnoreCase) && wk.Age > 30);

            Console.WriteLine(lineSeparator);
            Console.WriteLine("Estrazione lavoratori raggruppati per Città");
            Console.WriteLine(lineSeparator);

            var cityGroups = Workers.GroupBy(wk => new { wk.City,wk.Role});
            
            foreach (var city in cityGroups)
            {
                Console.WriteLine($"Città: {city.Key} - Totale per Gruppo: {city.Count()}");
                foreach (var wrk in city)
                {
                    Console.WriteLine($"\tMatricola: {wrk.Matricola} - Nominativo: {wrk.FullName} - Ruolo: {wrk.Role}");
                }
            }


            string sw = "Obiwan e l'imboscata dei Sabbipodi";
            sw = sw.Replace("Sabbipodi", "Jawas");
            int sPos = sw.IndexOf("Jawas");
            string sSub = sw.Substring(0, sPos);

            int[] myNumbers = { 10, 20, 30, 780, 1040, 320 };
            List<int> myNumbersList = [10, 20, 30, 780, 1040, 320, 17, 51, 79];
            Console.WriteLine($"La somma dei numeri dell'array è: {myNumbers.Sum()}");
            Console.WriteLine($"La media dei numeri dell'array è: {myNumbers.Average()}");
            List<int> pairNumbers = myNumbersList.FindAll(num => (num % 2) == 0);
            Console.WriteLine($"Elenco numeri pari dell'array : {string.Join(",", pairNumbers)}");

            Console.WriteLine(lineSeparator);
            Console.WriteLine("Estrazione lavoratori che hanno lavorato in data 13/10/2023");
            Console.WriteLine(lineSeparator);
            DateTime dtWork = new(2023, 10, 13);
            var workerByDate = Workers.Where(wk => wk.WorkDays.Any(wd => wd.ActivityDate == dtWork));

            foreach (var worker in workerByDate)
            {
                Console.WriteLine($"Matricola: {worker.Matricola} - Nominativo: {worker.FullName} - Data: {dtWork}");
                foreach (var wd in worker.WorkDays)
                {
                    Console.WriteLine($"\tData: {wd.ActivityDate} - Tipo Attività: {wd.JobType} - Ore: {wd.TotalHours}");
                }
            }

            var workersByDate = from wre in Workers
                                from wod in wre.WorkDays
                                where wod.ActivityDate == dtWork
                                group new
                                {
                                    wre.Matricola,
                                    wre.FullName,
                                    wre.Department,
                                    wod
                                } by wod.JobType into grp
                                select grp;

        }
        #endregion


    }
}
