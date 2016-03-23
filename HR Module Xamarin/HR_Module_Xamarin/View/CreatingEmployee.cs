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
            var projectName = new Entry { Placeholder = "ProjectName", Keyboard = Keyboard.Chat, FontSize = 25 };
            projectName.SetBinding(Entry.TextProperty, "ProjectName");
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
            //var hisManager = new Entry { Placeholder = "HisManager", Keyboard = Keyboard.Url, FontSize = 25 };

            List<string> itemsSource = HRModuleDataBase.GetPositionsName();
            BindablePicker bindablePicker = new BindablePicker { Title = "Choose Position"};
            bindablePicker.ItemsSource = itemsSource;
            bindablePicker.SelectedIndexChanged += (object sender, EventArgs e) => {
                var picker = sender as BindablePicker;
                position.Text = picker.SelectedIndex.ToString();

            };

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) => {
                var save = (Employee)BindingContext;
                App.Database.SaveEmployee(save);
                Navigation.PopAsync();
            };

            StackLayout stacklayout = new StackLayout
            {
                Children = { name, projectName, salary, city, email, phone, bindablePicker, position, saveButton }
            };

            Content = stacklayout;
        }
    }
}
