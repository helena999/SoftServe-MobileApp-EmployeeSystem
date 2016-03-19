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
    public class EmployeePositions : ContentPage
    {
        ListView listView;
        public EmployeePositions()
        {
            Title = "Employee Postion";

            listView = new ListView();
            listView.ItemTemplate = new DataTemplate
                    (typeof(EmployeeCell));
            listView.ItemTapped += async (sender, e) =>
            {
                Employee item = (Employee)e.Item;
                await Navigation.PushAsync(new EmployeeDetailsPage(item));


            };
            Button createEmployee = new Button
            {
                Text = "Create New Employee"
            };
            createEmployee.Clicked += async (sender, args) =>
            await Navigation.PushAsync(new CreatingEmployee());

            var layout = new StackLayout();
            layout.Children.Add(listView);
            layout.Children.Add(createEmployee);
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            Content = layout;

            
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = App.Database.GetEmployeesWithRelatins();
        }
    }
    public class EmployeeCell : ViewCell
    {
        public EmployeeCell()
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
            position.SetBinding(Label.TextProperty, "Position.Name");

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
