using System.ComponentModel.DataAnnotations;

namespace WelcomeAcademy6.DataModel
{
    public class Worker
    {
        [Key]
        [Required]
        [MaxLength(4), MinLength(4)] // 4 caratteri, il primo deve essere una lettera alfabeto e poi 3 numeri
        public string Matricola { get; set; }
        [Required]
        [MinLength(3)]
        public string FullName { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Department { get; set; }

        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Cap { get; set; }
        public string Phone { get; set; }

        public List<WorkDay> WorkDays { get; set; } = [];

        public Worker()
        {

        }

        public Worker(string matricola, string fullName, string role, string department, int age, string address, string city, string province, string cap, string phone)
        {
            Matricola = matricola;
            FullName = fullName;
            Role = role;
            Department = department;
            Age = age;
            Address = address;
            City = city;
            Province = province;
            Cap = cap;
            Phone = phone;
        }
    }
}
