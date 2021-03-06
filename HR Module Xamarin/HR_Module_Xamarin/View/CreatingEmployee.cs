﻿using HR_Module_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using HR_Module_Xamarin.Data;
using HR_Module_Xamarin.Controls;

namespace HR_Module_Xamarin.View
{
    class CreatingEmployee : ContentPage
    {
        public CreatingEmployee()
        {
            Title = "Creating Employee";

            var employee = new Employee();

            this.BindingContext = employee;

            var name = new Entry { Placeholder = "Name", FontSize = Constants.ValueLabelSize };
            name.SetBinding(Entry.TextProperty, "Name");

            var project = new Entry { Placeholder = "Project", Keyboard = Keyboard.Chat, FontSize = Constants.ValueLabelSize, IsVisible = false };
            project.SetBinding(Entry.TextProperty, "ProjectId");

            var salary = new Entry { Placeholder = "Salary", Keyboard = Keyboard.Numeric, FontSize = Constants.ValueLabelSize };
            salary.SetBinding(Entry.TextProperty, "Salary");

            var city = new Entry { Placeholder = "City", Keyboard = Keyboard.Text, FontSize = Constants.ValueLabelSize };
            city.SetBinding(Entry.TextProperty, "City");

            var email = new Entry { Placeholder = "Email", Keyboard = Keyboard.Email, FontSize = Constants.ValueLabelSize };
            email.SetBinding(Entry.TextProperty, "Email");

            var phone = new Entry { Placeholder = "Phone", Keyboard = Keyboard.Telephone, FontSize = Constants.ValueLabelSize };
            phone.SetBinding(Entry.TextProperty, "Phone");

            var position = new Entry { Placeholder = "Position", Keyboard = Keyboard.Text, FontSize = Constants.ValueLabelSize, IsVisible = false };
            position.SetBinding(Entry.TextProperty, "PositionId");

            var hisManager = new Entry { Placeholder = "HisManager", Keyboard = Keyboard.Url, FontSize = Constants.ValueLabelSize, IsVisible = false };
            hisManager.SetBinding(Entry.TextProperty, "ManId");

            // Get Delivery Directors for Project Managers
            List<Employee> managers = App.Database.GetDeliveryDirectors().ToList<Employee>();
            List<string> managersNames = new List<string>();
            for (int i = 0; i < managers.Count; i++)
            {
                managersNames.Add(managers[i].Name);
            }

            // Set Delivery Director to the current Project Manager
            BindablePicker bindableManagersPicker = new BindablePicker { Title = "Choose Manager" };
            bindableManagersPicker.IsVisible = false;
            bindableManagersPicker.ItemsSource = managersNames;
            bindableManagersPicker.SelectedIndexChanged += (object sender, EventArgs e) => {
                var picker = sender as BindablePicker;
                var pickerSelectedIndex = picker.SelectedIndex;
                hisManager.Text = managers[pickerSelectedIndex].ID.ToString();
            };

            // Get all projects for the Employees
            List<Project> projects = App.Database.GetProjectsWithRelations().ToList<Project>();
            List<string> projectsnames = new List<string>();
            for (int i = 0; i < projects.Count; i++)
            {
                projectsnames.Add(projects[i].Name);
            }

            // Set Project to current Employee
            BindablePicker bindableProjectPicker = new BindablePicker { Title = "Choose Project" };
            bindableProjectPicker.ItemsSource = projectsnames;
            bindableProjectPicker.SelectedIndexChanged += (object sender, EventArgs e) => {
                var picker = sender as BindablePicker;
                var pickerSelectedIndex = picker.SelectedIndex;
                project.Text = projects[pickerSelectedIndex].Id.ToString();
                hisManager.Text = projects[pickerSelectedIndex].ProjectManager.ID.ToString();
            };

            // Get all positions
            List<string> positions = HRModuleDataBase.GetPositionsName();
            // Set Position to the Employee
            BindablePicker bindablePositionPicker = new BindablePicker { Title = "Choose Position"};
            bindablePositionPicker.ItemsSource = positions;
            bindablePositionPicker.SelectedIndexChanged += (object sender, EventArgs e) => {
                var picker = sender as BindablePicker;
                position.Text = picker.SelectedIndex.ToString();

                int projectManagerId = (int)Constants.Positions.ProjectManager;
                if (position.Text == projectManagerId.ToString())
                {
                    bindableManagersPicker.IsVisible = true;
                    bindableProjectPicker.IsVisible = false;
                }
                else
                {
                    bindableManagersPicker.IsVisible = false;
                    bindableProjectPicker.IsVisible = true;
                }
            };
            
            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) => {
                var save = (Employee)BindingContext;
                App.Database.SaveEmployeeWithRelation(save);
                Navigation.PopAsync();
            };

            StackLayout stacklayout = new StackLayout
            {
                Children = { name, project, salary, city, email, phone, bindablePositionPicker, bindableProjectPicker, position, hisManager, bindableManagersPicker, saveButton }
            };

            Content = stacklayout;
        }
    }
}
