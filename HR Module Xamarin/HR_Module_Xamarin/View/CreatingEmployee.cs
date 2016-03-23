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
    class CreatingEmployee : ContentPage
    {
        public CreatingEmployee()
        {
            Title = "Creating Employee";

            var employee = new Employee();

            this.BindingContext = employee;

            var name = new Entry { Placeholder = "Name", FontSize = 25 };
            name.SetBinding(Entry.TextProperty, "Name");
            var project = new Entry { Placeholder = "Project", Keyboard = Keyboard.Chat, FontSize = 25, IsVisible = false };
            project.SetBinding(Entry.TextProperty, "ProjectId");
            var salary = new Entry { Placeholder = "Salary", Keyboard = Keyboard.Numeric, FontSize = 25 };
            salary.SetBinding(Entry.TextProperty, "Salary");
            var city = new Entry { Placeholder = "City", Keyboard = Keyboard.Text, FontSize = 25 };
            city.SetBinding(Entry.TextProperty, "City");
            var email = new Entry { Placeholder = "Email", Keyboard = Keyboard.Email, FontSize = 25 };
            email.SetBinding(Entry.TextProperty, "Email");
            var phone = new Entry { Placeholder = "Phone", Keyboard = Keyboard.Telephone, FontSize = 25 };
            phone.SetBinding(Entry.TextProperty, "Phone");
            var position = new Entry { Placeholder = "Position", Keyboard = Keyboard.Text, FontSize = 25, IsVisible = false };
            position.SetBinding(Entry.TextProperty, "PositionId");
            var hisManager = new Entry { Placeholder = "HisManager", Keyboard = Keyboard.Url, FontSize = 25, IsVisible = false };
            hisManager.SetBinding(Entry.TextProperty, "ManId");

            List<string> itemsSource = HRModuleDataBase.GetPositionsName();
            BindablePicker bindablePositionPicker = new BindablePicker { Title = "Choose Position"};
            bindablePositionPicker.ItemsSource = itemsSource;
            bindablePositionPicker.SelectedIndexChanged += (object sender, EventArgs e) => {
                var picker = sender as BindablePicker;
                position.Text = picker.SelectedIndex.ToString();

            };

            List<Project> projects = App.Database.GetProjectsWithRelatons().ToList<Project>();
            List<string> projectsnames = new List<string>();
            for (int i = 0; i < projects.Count; i++)
            {
                projectsnames.Add(projects[i].Name);
            }

            BindablePicker bindableProjectPicker = new BindablePicker { Title = "Choose Project" };
            bindableProjectPicker.ItemsSource = projectsnames;
            bindableProjectPicker.SelectedIndexChanged += (object sender, EventArgs e) => {
                var picker = sender as BindablePicker;
                var pickerSelectedIndex = picker.SelectedIndex;
                project.Text = projects[pickerSelectedIndex].Id.ToString();
                hisManager.Text = projects[pickerSelectedIndex].ProjectManager.ID.ToString();

            };

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) => {
                var save = (Employee)BindingContext;
                App.Database.SaveEmployeeWithRelation(save);
                Navigation.PopAsync();
            };

            StackLayout stacklayout = new StackLayout
            {
                Children = { name, project, salary, city, email, phone, bindablePositionPicker, bindableProjectPicker, position, hisManager, saveButton }
            };

            Content = stacklayout;
        }
    }
}
