using HR_Module_Xamarin.View;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Module_Xamarin.Model
{
    public class Position
    {

        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }

        [OneToMany]
        public List<Employee> Employees { get; set; }
    }
}
