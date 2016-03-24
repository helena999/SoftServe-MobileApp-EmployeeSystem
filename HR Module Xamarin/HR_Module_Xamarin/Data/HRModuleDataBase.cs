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

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public HRModuleDataBase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();

            // create the tables
            database.CreateTable<Position>();
            SeedPositions();
            database.CreateTable<Employee>();
            database.CreateTable<Project>();
        }

        public IEnumerable<Employee> GetEmployee()
        {
            lock (locker)
            {
                return (from i in database.Table<Employee>() select i).ToList();
            }
        }

        public Employee GetEmployee(int id)
        {
            lock (locker)
            {
                return database.Table<Employee>().FirstOrDefault(x => x.ID == id);
            }
        }

        public IEnumerable<Employee> GetEmployeesWithRelations()
        {
            lock (locker)
            {
                return database.GetAllWithChildren<Employee>();
            }
        }

        public Employee GetEmployeeWithRelation(int id)
        {
            lock (locker)
            {
                return database.GetWithChildren<Employee>(id);
            }
        }

        //public int SaveEmployee(Employee item)
        //{
        //    lock (locker)
        //    {
        //        if (item.ID != 0)
        //        {
        //            database.Update(item);
        //            return item.ID;
        //        }
        //        else {
        //            return database.Insert(item);
        //        }
        //    }
        //}

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

        public void SaveProjectWithRelation(Project item)
        {
            lock (locker)
            {
                database.Insert(item);
            }
        }

        public IEnumerable<Project> GetProject()
        {
            lock (locker)
            {
                return (from i in database.Table<Project>() select i).ToList();
            }
        }


        public IEnumerable<Project> GetProjectsWithRelations()
        {
            lock (locker)
            {
                return database.GetAllWithChildren<Project>();
            }
        }

        //public Project GetProjectWithRelatons(int id)
        //{
        //    lock (locker)
        //    {
        //        return database.GetWithChildren<Project>(id);
        //    }
        //}


        public Project GetProject(int id)
        {
            lock (locker)
            {
                return database.Table<Project>().FirstOrDefault(x => x.Id == id);
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

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Project>(id);
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
        public static List<string> GetPMName()
        {
            var sql = from i in database.Table<Employee>() where i.PositionId == 6 select i.Name;
            var listTL = new List<string>();

            foreach (var item in sql)
            {
                listTL.Add(item);
            }

            return listTL;
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

        public IEnumerable<Project> GetManagerProjectsNames(int managerId)
        {
            var managerProjects = from projects in database.Table<Project>() where projects.PM == managerId select projects;

            return managerProjects;
        }

        /*public IEnumerable<Employee> GetProjectEmployees(int projectId)
        {
            var projectEmployees = from projects in database.Table<Project>() where projects.Id == projectId select projects;

            return projectEmployees;
        }*/
    }
}