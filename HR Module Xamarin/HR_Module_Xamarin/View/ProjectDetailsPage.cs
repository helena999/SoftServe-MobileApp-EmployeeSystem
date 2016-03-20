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


        public ProjectDetailsPage(Project item)
        {
            Title = "Project Details Page";



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

            Label projectManager = new Label
            {
                Text = "Project Manager",
                TextColor = Color.Green,
                FontSize = 15
            };
            Label projectManagerLabel = new Label
            {
                Text = item.ProjectManager.ToString(),
                FontSize = 30
            };
            Label teamLead = new Label
            {
                Text = "Team Leader",
                TextColor = Color.Green,
                FontSize = 15

            };
            Label temLeadLabel = new Label
            {
                Text = item.TeamLeader.ToString(),
                FontSize = 30
            };
            //Label projectLabel = new Label
            //{
            //    Text = item.ProjectName,
            //    FontSize = 30
            //};

            //Label managerLabel = new Label
            //{
            // Text = item.Manager.ToString(),
            //    FontSize = 30
            //};
            //Label position = new Label
            //{
            //    Text = "Position",
            //    TextColor = Color.Green,
            //    FontSize = 15

            //};
            //Label positionLabel = new Label
            //{
            //    Text = item.Position.Name,
            //    FontSize = 30
            //};
            //Label salary = new Label
            //{
            //    Text = "Salary",
            //    TextColor = Color.Green,
            //    FontSize = 15

            //};
            //Label salaryLabel = new Label
            //{
            //    Text = item.Salary,
            //    FontSize = 30
            //};
            //Label phone = new Label
            //{
            //    Text = "Phone",
            //    TextColor = Color.Green,
            //    FontSize = 15

            //};
            //Label phoneLabel = new Label
            //{
            //    Text = item.Phone.ToString(),
            //    FontSize = 30
            //};
            var stackLayout = new StackLayout
            {
                Children = { name, nameLabel, projectManager, projectManagerLabel, teamLead, temLeadLabel, /*projectLabel*//*,managerLabel, *//*position, positionLabel, phone, phoneLabel, salary, salaryLabel*/ }
            };

            this.Content = stackLayout;
        }
    }
}
