using HR_Module_Xamarin.Model;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Module_Xamarin.View
{
    public class Employee
    {


        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }

        public string Salary { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [ForeignKey(typeof(Position))]
        public int PositionId { get; set; }

        [ManyToOne]
        public Position Position { get; set; }

        [ForeignKey(typeof(Project))]
        public int ProjectId { get; set; }

        [ManyToOne]
        public Project Project { get; set; }

        [ForeignKey(typeof(Employee))]
        public int ManId { get; set; }

        [OneToOne]
        public Employee Manager { get; set; }
    }
}