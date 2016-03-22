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

<<<<<<< HEAD
        public ProjectDetailsPage(Project initialItem)
        {
            Title = "Project Details Page";

            this.item = initialItem;

            Label nameLabel = new Label
=======

        public ProjectDetailsPage(Project item)
        {
            Title = "Project Details Page";



            this.item = item;
            Label name = new Label
>>>>>>> origin/problem_with_project_details
            {
                Text = "Name",
                TextColor = Color.Green,
                FontSize = 15
            };
<<<<<<< HEAD
            
            Label name = new Label
=======
            Label nameLabel = new Label
>>>>>>> origin/problem_with_project_details
            {
                VerticalOptions = LayoutOptions.Center,
                Text = item.Name,
                FontSize = 30
            };

<<<<<<< HEAD
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

            var stackLayout = new StackLayout
            {
                Children = { nameLabel, name, projectManagerLabel, projectManager }
=======
            Label projectManager = new Label
            {
                Text = "Project Manager",
                TextColor = Color.Green,
                FontSize = 15
            };
            Label projectManagerLabel = new Label
            {
                Text = item.ProjectManager.Name,
                FontSize = 30
            };
            
            var stackLayout = new StackLayout
            {
                Children = { name, nameLabel, projectManager, projectManagerLabel }
>>>>>>> origin/problem_with_project_details
            };

            this.Content = stackLayout;
        }
    }
}
