using HR_Module_Xamarin.Model;
using HR_Module_Xamarin.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HR_Module_Xamarin
{
    public class ProjectsPage : ContentPage
    {
        ListView listView;
        public ProjectsPage()
        {
            Title = "Projects";

            listView = new ListView();
            listView.ItemTemplate = new DataTemplate
                    (typeof(ProjectCell));
            listView.ItemTapped += async (sender, e) =>
            {
                Project item = (Project)e.Item;
                await Navigation.PushAsync(new ProjectDetailsPage(item));
            };

            Button createProject = new Button
            {
                Text = "Create project"
            };

            createProject.Clicked += async (sender, args) =>
            await Navigation.PushAsync(new ProjectCreatePage());

            var layout = new StackLayout();
            layout.Children.Add(listView);
            layout.Children.Add(createProject);
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            Content = layout;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = App.Database.GetProjectsWithRelatons();
        }
    }
    public class ProjectCell : ViewCell
    {
        public ProjectCell()
        {
            var name = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 20
            };

            name.SetBinding(Label.TextProperty, "Name");

            var position = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 20,
                TextColor = Color.Green
            };

            position.SetBinding(Label.TextProperty, "Project.Name");

            var layout = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                Children = { name, position }
            };

            View = layout;
        }
    }
}
