using HR_Module_Xamarin.Model;
using HR_Module_Xamarin.View;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HR_Module_Xamarin.Data
{
    public class HRModuleDataBase
    {
        static object locker = new object();

        static SQLiteConnection database;

        public HRModuleDataBase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();

            // create the tables
            database.CreateTable<Position>();
            SeedPositions();
            database.CreateTable<Employee>();
            SeedCEOandDD();
            database.CreateTable<Project>();
        }

        public IEnumerable<Employee> GetEmployeesWithRelations()
        {
            lock (locker)
            {
                return database.GetAllWithChildren<Employee>();
            }
        }
        public int SaveEmployee(Employee item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else {
                    return database.Insert(item);
                }
            }
        }
        //need to fix returt type
        public void SaveEmployeeWithRelation(Employee item)
        {
            lock (locker)
            {
                SaveEmployee(item);
                var positionToUpdate = GetPosition(item.PositionId);
                positionToUpdate.Employees = new List<Employee>();
                positionToUpdate.Employees.Add(item);
                database.Update(positionToUpdate);
 
            }
        }


        public IEnumerable<Project> GetProjectsWithRelations()
        {
            lock (locker)
            {
                return database.GetAllWithChildren<Project>();
            }
        }

        public int SaveProject(Project item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    database.Update(item);
                    return item.Id;
                }
                else {
                    return database.Insert(item);
                }
            }
        }
        public Position GetPosition(int id)
        {
            lock (locker)
            {
                return database.Table<Position>().FirstOrDefault(x => x.Id == id);
            }
        }

        private int SavePosition(Position position)
        {
            lock (locker)
            {
                return database.Insert(position);
            }
        }

        private void SeedPositions()
        {
            //Check if Position table is empty and seed it with positions
            var isPositionTableEmpty = !database.Table<Position>().Any();

            if (isPositionTableEmpty)
            {
                List<Position> positions = new List<Position>()
            {
                new Position
                {
                    Id = 0,
                    Name = "Unknown"
                },
                new Position
                {
                    Id = 1,
                    Name = "Trainee"
                },
                new Position
                {
                    Id = 2,
                    Name = "Junior"
                },
                new Position
                {
                    Id = 3,
                    Name = "Intermediate"
                },
                new Position
                {
                    Id = 4,
                    Name = "Senior"
                },
                new Position
                {
                    Id = 5,
                    Name = "Team leader"
                },
                new Position
                {
                    Id = 6,
                    Name = "Project Manager"
                },
                new Position
                {
                    Id = 7,
                    Name = "Delivery Director"
                },
                new Position
                {
                    Id = 8,
                    Name = "CEO"
                }
            };

                foreach (var position in positions)
                {
                    SavePosition(position);
                }
            }
        }

        private void SeedCEOandDD()
        {
            //Check if Employee table is empty and seed it with positions
            var isEmployeeTableEmpty = !database.Table<Employee>().Any();

            if (isEmployeeTableEmpty)
            {
                List<Employee> employees = new List<Employee>()
                {
                    new Employee
                    {
                        Name = "John Atanasov",
                        Salary = "10000",
                        City = "Madrid",
                        Email = "jo@gt.bg",
                        Phone = "23432432",
                        PositionId = 8
                    },

                    new Employee
                    {
                        Name = "Alan Dill",
                        Salary = "5000",
                        City = "Madrid",
                        Email = "al@gt.bg",
                        Phone = "44334",
                        PositionId = 7,
                        ManId = 1
                    }
                };

                foreach (var employee in employees)
                {
                    SaveEmployeeWithRelation(employee);
                }
            }
        }

        public static List<string> GetPositionsName()
        {
            var sql = from i in database.Table<Position>() select i.Name;
            var listL = new List<string>();

            foreach (var item in sql)
            {
                listL.Add(item);
            }

            return listL;
        }

        public IEnumerable<Employee> GetProjectManagers()
        {
            var projectManagers = from i in database.Table<Employee>() where i.PositionId == 6 select i;

            return projectManagers;
        }

        public IEnumerable<Employee> GetDeliveryDirectors()
        {
            var projectManagers = from i in database.Table<Employee>() where i.PositionId == 7 select i;

            return projectManagers;
        }

        public List<string> GetManagerProjectsNames(int managerId)
        {
            var managerProjects = from projects in database.Table<Project>() where projects.PM == managerId select projects.Name;

            return managerProjects.ToList();
        }
    }
}