using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeAcademy6.DataModel
{
    public class WorkDay
    {
        [Key]
        public int ID { get; set; }
        public DateTime ActivityDate { get; set; }
        public string? JobType { get; set; }
        public decimal TotalHours { get; set; }
        public string? Matricola { get; set; }

        public WorkDay()
        { }
        public WorkDay(int id,DateTime activitydate,string jobtype, decimal totalhours, string matricola)
        {
            ID = id;
            ActivityDate = activitydate;
            JobType = jobtype;
            TotalHours = totalhours;
            Matricola = matricola;
        }
    }
}
