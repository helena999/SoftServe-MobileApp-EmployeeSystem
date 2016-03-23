using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HR_Module_Xamarin.View
{
    class HomePage : ContentPage
    {
        public HomePage()
        {
            Title = "HR Module";
            Label companyName = new Label
            {
                Text = "XcompanY",
                FontSize = 30,
                XAlign = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Start
            };

            Label pageDescriptionLbl = new Label
            {
                Text = "\nWelcome to our Employees Management System.\n\n Manage employees anywhere, anytime!\n",
                FontSize = 30,
                XAlign = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Start
            };

            Label viewsLbl = new Label
            {
                Text = "Choose view:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                XAlign = TextAlignment.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Button employeesBtn = new Button
            {
                Text = "Employees",
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
                VerticalOptions = LayoutOptions.Center,
            };

            employeesBtn.Clicked += EmployeesBtn_Clicked;

            Button projectsBtn = new Button
            {
                Text = "Projects",
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            projectsBtn.Clicked += ProjectsBtn_Clicked;

            var stackLayout = new StackLayout
            {
                Children = { companyName, pageDescriptionLbl, viewsLbl, employeesBtn, projectsBtn }
            };

            this.Content = stackLayout;
        }

        private async void EmployeesBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeePositions());
        }

        private async void ProjectsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectsPage());
        }

    }
}
