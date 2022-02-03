using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("TB_M_Employee")]
    public class Employee
    {
        [Key]
        public string NIK { get; set; }
        public string FirstNama { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }

        public Gender GenderId
        {
            get; set;
        }
        public enum Gender
        {
            Male,Female
        }
        [JsonIgnore]
        public virtual Account Account { get; set; }
    }
}
