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
    class EditEmployeePage : ContentPage
    {
        private Employee item;

        public EditEmployeePage(Employee item)
        {
            Title = "Edit Employee Page";

            this.item = item;
            this.BindingContext = item;

            Label nameLabel = new Label { Text = "Name", FontSize = Constants.TitleLabelSize };
            var name = new Entry { Placeholder = "Name", FontSize = Constants.ValueLabelSize };
            name.SetBinding(Entry.TextProperty, "Name");

            Label salaryLabel = new Label { Text = "Salary", FontSize = Constants.TitleLabelSize };
            var salary = new Entry { Placeholder = "Salary", Keyboard = Keyboard.Numeric, FontSize = Constants.ValueLabelSize };
            salary.SetBinding(Entry.TextProperty, "Salary");

            Label cityLabel = new Label { Text = "City", FontSize = Constants.TitleLabelSize };
            var city = new Entry { Placeholder = "City", Keyboard = Keyboard.Text, FontSize = Constants.ValueLabelSize };
            city.SetBinding(Entry.TextProperty, "City");

            Label emailLabel = new Label { Text = "Email", FontSize = Constants.TitleLabelSize };
            var email = new Entry { Placeholder = "Email", Keyboard = Keyboard.Email, FontSize = Constants.ValueLabelSize };
            email.SetBinding(Entry.TextProperty, "Email");

            Label phoneLabel = new Label { Text = "Phone", FontSize = Constants.TitleLabelSize };
            var phone = new Entry { Placeholder = "Phone", Keyboard = Keyboard.Telephone, FontSize = Constants.ValueLabelSize };
            phone.SetBinding(Entry.TextProperty, "Phone");
            
            var editButton = new Button { Text = "Edit" };
            editButton.Clicked += async (sender, e) => {
                var employeeToUpdate = (Employee)BindingContext;
                App.Database.SaveEmployee(employeeToUpdate);
                await Navigation.PushAsync(new EmployeeDetailsPage(employeeToUpdate));
            };

            var goHomeButton = new Button { Text = "HomePage" };
            goHomeButton.Clicked += async (sender, e) => {                
                await Navigation.PushAsync(new HomePage());
            };

            StackLayout stacklayout = new StackLayout
            {
                Children = { nameLabel,
                            name,
                            salaryLabel,
                            salary,
                            cityLabel,
                            city,
                            emailLabel,
                            email,
                            phoneLabel,
                            phone,
                            editButton,
                            goHomeButton
                }
            };

            Content = stacklayout;
        }
    }
}
