using HR_Module_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HR_Module_Xamarin.Data;
using HR_Module_Xamarin.Controls;

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

            List<Employee> employees = App.Database.GetProjectManagers().ToList<Employee>();
            List<string> employeesNames = new List<string>();
            for (int i = 0; i < employees.Count; i++)
            {
                employeesNames.Add(employees[i].Name);
            }

            BindablePicker bindableProjectManagerPicker = new BindablePicker { Title = "Choose Project Manager" };
            bindableProjectManagerPicker.ItemsSource = employeesNames;
            bindableProjectManagerPicker.SelectedIndexChanged += (object sender, EventArgs e) => {
                var picker = sender as BindablePicker;
                var pickerSelectedIndex = picker.SelectedIndex;
                projectManager.Text = employees[pickerSelectedIndex].ID.ToString();

            };

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) => {
                var save = (Project)BindingContext;
                App.Database.SaveProject(save);
                Navigation.PopAsync();
            };

            StackLayout stacklayout = new StackLayout
            {
                Children = { name, projectManager, bindableProjectManagerPicker, saveButton, }
            };

            Content = stacklayout;
        }
    }
}
