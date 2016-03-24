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
    class ProjectDetailsPage : ContentPage
    {
        private Project item;
        
        public ProjectDetailsPage(Project initialItem)
        {
            Title = "Project Details Page";

            this.item = initialItem;

            Label nameLabel = new Label

            {
                Text = "Name",
                TextColor = Color.Green,
                FontSize = 15
            };

            Label name = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = item.Name,
                FontSize = 30
            };
            
            Label projectManagerLabel = new Label
            {
                Text = "Project manager",
                TextColor = Color.Green,
                FontSize = 15
            };

            Label projectManager = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = item.ProjectManager.Name,
                FontSize = 30
            };

            string employeesString = "";

            employeesString = item.Employees.Count == 0 ? "No employees" : String.Join(", ", item.Employees);

            Label employeesLabel = new Label
            {
                Text = "Employees",
                TextColor = Color.Green,
                FontSize = 15
            };

            Label employees = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                Text = employeesString,
                FontSize = 30
            };

            var stackLayout = new StackLayout
            {
                Children = { nameLabel, name, projectManagerLabel, projectManager, employeesLabel, employees }
            };

            this.Content = stackLayout;
        }
    }
}
