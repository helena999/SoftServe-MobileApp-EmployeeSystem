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
                FontSize = Constants.TitleLabelSize
            };

            Label nameLabel = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = item.Name,
                FontSize = Constants.ValueLabelSize
            };

            Label email = new Label
            {
                Text = "Email",
                TextColor = Color.Green,
                FontSize = Constants.TitleLabelSize
            };

            Label emailLabel = new Label
            {
                Text = item.Email,
                FontSize = Constants.ValueLabelSize
            };

            Label work = new Label
            {
                Text = "City",
                TextColor = Color.Green,
                FontSize = Constants.TitleLabelSize
            };

            Label workPlaceLabel = new Label
            {
                Text = item.City,
                FontSize = Constants.ValueLabelSize
            };

            Label project = new Label
            {
                Text = "Project",
                TextColor = Color.Green,
                FontSize = Constants.TitleLabelSize
            };

            string projects = "";

            if (item.PositionId == (int)Constants.Positions.ProjectManager)
            {
                var managerProjects = App.Database.GetManagerProjectsNames(item.ID);

                projects = managerProjects.Count == 0 ? "No project" : String.Join(", ", managerProjects);
            }
            else
            {
                projects = item.Project != null ? item.Project.Name : "No project";
            }

           Label projectLabel = new Label
            {
                Text = projects,
                FontSize = Constants.ValueLabelSize
           };

            Label manager = new Label
            {
                Text = "Manager",
                TextColor = Color.Green,
                FontSize = Constants.TitleLabelSize
            };

            Label managerLabel = new Label
            {
                Text = item.Manager != null ? item.Manager.Name : "No manager", // TODO
                FontSize = Constants.ValueLabelSize
            };

            Label position = new Label
            {
                Text = "Position",
                TextColor = Color.Green,
                FontSize = Constants.TitleLabelSize
            };

            Label positionLabel = new Label
            {
                Text = item.Position.Name,
                FontSize = Constants.ValueLabelSize
            };

            Label salary = new Label
            {
                Text = "Salary",
                TextColor = Color.Green,
                FontSize = Constants.TitleLabelSize
            };

            Label salaryLabel = new Label
            {
                Text = item.Salary,
                FontSize = Constants.ValueLabelSize
            };

            Label phone = new Label
            {
                Text = "Phone",
                TextColor = Color.Green,
                FontSize = Constants.TitleLabelSize
            };

            Label phoneLabel = new Label
            {
                Text = item.Phone != null ? item.Phone : "No phone",
                FontSize = Constants.ValueLabelSize
            };

            var editButton = new Button { Text = "Edit Employee" };
            editButton.Clicked += async (sender, args) =>
            await Navigation.PushAsync(new EditEmployeePage(item));

            var goHomeButton = new Button { Text = "HomePage" };
            goHomeButton.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new HomePage());
            };

            var stackLayout = new StackLayout
            {
                Children = { name, nameLabel, email,emailLabel, work,workPlaceLabel, project, projectLabel, manager, managerLabel, position, positionLabel, phone, phoneLabel, salary,salaryLabel, editButton, goHomeButton }
            };

            this.Content = stackLayout;
        }
    }
}
