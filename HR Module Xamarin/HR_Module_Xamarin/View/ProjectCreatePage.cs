using HR_Module_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HR_Module_Xamarin.Data;

namespace HR_Module_Xamarin.View
{
    class ProjectCreatePage : ContentPage
    {
        public ProjectCreatePage()
        {
            Title = "Create project";

            var project = new Project();

            this.BindingContext = project;

            var name = new Entry { Placeholder = "Name", FontSize = 25 };
            name.SetBinding(Entry.TextProperty, "Name");
            var projectManager = new Entry { Placeholder = "Project Manager", Keyboard = Keyboard.Chat, FontSize = 25, IsVisible = false };
            projectManager.SetBinding(Entry.TextProperty, "PM");

            List<string> itemsSource = HRModuleDataBase.GetPMName();
            BindablePicker bindablePicker = new BindablePicker { Title = "Choose Position" };
            bindablePicker.ItemsSource = itemsSource;
            bindablePicker.SelectedIndexChanged += (object sender, EventArgs e) => {
                var picker = sender as BindablePicker;
                projectManager.Text = picker.SelectedIndex.ToString();

            };

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) => {
                var save = (Project)BindingContext;
                App.Database.SaveProject(save);
                Navigation.PopAsync();
            };

            StackLayout stacklayout = new StackLayout
            {
                Children = { name, projectManager, bindablePicker, saveButton, }
            };

            Content = stacklayout;
        }
    }
}
