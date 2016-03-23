using HR_Module_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HR_Module_Xamarin.View;

namespace HR_Module_Xamarin
{
    class EmployeeDetailsPage : ContentPage
    {
        private Employee item;
      

        public EmployeeDetailsPage(Employee item)
        {
            Title = "Employee Details Page";

              

            this.item = item;
            Label name = new Label
            {
                Text = "Name",
                TextColor = Color.Green,
                FontSize = 15
            };
            Label nameLabel = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = item.Name,
                FontSize = 30
            };

            Label email = new Label
            {
                Text = "Email",
                TextColor = Color.Green,
                FontSize = 15
            };
            Label emailLabel = new Label
            {
                Text = item.Email,
                FontSize = 30
            };
            Label work = new Label
            {
                Text = "City",
                TextColor = Color.Green,
                FontSize = 15

            };
            Label workPlaceLabel = new Label
            {
                Text = item.City,
                FontSize = 30
            };

            Label project = new Label
            {
                Text = "Project",
                TextColor = Color.Green,
                FontSize = 15
            };

            string projects = "";

            if (item.PositionId == 6)
            {
                var managerProjects = App.Database.GetManagerProjectsNames(item.ID).ToList<Project>();

                StringBuilder result = new StringBuilder();

                int i;
                for (i = 0; i < managerProjects.Count; i++)
                {
                    result.Append(managerProjects[i].Name + ", ");
                }
                
                //result.Append(managerProjects[i].Name);

                projects = result.ToString();

                //projects = String.Join(", ", managerProjects);
            } else {
                projects = item.Project != null ? item.Project.Name : "No project";
            }

            Label projectLabel = new Label
            {
                Text = projects,
                FontSize = 30
            };

            Label manager = new Label
            {
                Text = "Manager",
                TextColor = Color.Green,
                FontSize = 15
            };

            Label managerLabel = new Label
            {
                Text = item.Manager != null ? item.Manager.Name : "No manager", // TODO
                FontSize = 30
            };

            Label position = new Label
            {
                Text = "Position",
                TextColor = Color.Green,
                FontSize = 15

            };

            Label positionLabel = new Label
            {
                Text = item.Position.Name,
                FontSize = 30
            };

            Label salary = new Label
            {
                Text = "Salary",
                TextColor = Color.Green,
                FontSize = 15

            };
            Label salaryLabel = new Label
            {
                Text = item.Salary,
                FontSize = 30
            };
            Label phone = new Label
            {
                Text = "Phone",
                TextColor = Color.Green,
                FontSize = 15

            };
            Label phoneLabel = new Label
            {
                Text = item.Phone.ToString(),
                FontSize = 30
            };
            var stackLayout = new StackLayout
            {
                Children = { name, nameLabel, email,emailLabel, work,workPlaceLabel, project, projectLabel, manager, managerLabel, position, positionLabel, phone, phoneLabel, salary,salaryLabel }
            };

            this.Content = stackLayout;
        }
    }
}
