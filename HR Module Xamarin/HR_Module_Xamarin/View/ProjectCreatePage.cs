using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HR_Module_Xamarin.View
{
    class ProjectCreatePage : ContentPage
    {

        public class ListItem
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string WorkPlace { get; set; }
            public string Position { get; set; }
            public string Phone { get; set; }
            public string ProjectName { get; set; }

        }

        public ProjectCreatePage()
        {
            Title = "Create project";

            ListView listView = new ListView()
            {
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("Key"),
                GroupHeaderTemplate = new DataTemplate(typeof(HeaderCell)),
                HasUnevenRows = true,
                GroupShortNameBinding = new Binding("Key"),


                ItemTemplate = new DataTemplate(typeof(TextCell))
                {
                    Bindings = {
                            { TextCell.TextProperty, new Binding("Name") }
                            //{ TextCell.DetailProperty, new Binding("ProjectName") }
                            //}
                },
                }
            };

            listView.ItemTapped += async (sender, e) =>
            {
                ListItem item = (ListItem)e.Item;
                //await DisplayAlert("Tapped", item.Name.ToString() + " was selected.", "OK");
                //((ListView)sender).SelectedItem = null;
                //await Navigation.PushAsync(new EmployeeDetailsPage(item));
                //listView.SelectedItem = null;
            };

            List<Group> itemsGrouped = new List<Group> {
                new Group ("Trainee", new List<ListItem> {
                new ListItem {Name = "Asen", ProjectName="HR Module",Email = "ss@.gmail.com",WorkPlace = "Sofia"},
                new ListItem {Name = "Ivan", ProjectName ="HR Module"},
                            }),

                new Group ("Junior", new List<ListItem>{
                new ListItem {Name = "Dimitur", ProjectName ="HR Module"}

                }),
                 new Group ("Intermediate", new List<ListItem>{
                new ListItem {Name = "Martin", ProjectName ="HR Module"}

                }),
                  new Group ("Senior", new List<ListItem>{
                new ListItem {Name = "Dragan", ProjectName ="HR Module"}

                }),
                   new Group ("Team Leader", new List<ListItem>{
                new ListItem {Name = "Ivo", ProjectName ="HR Module"}

                }),
                    new Group ("Project Manager", new List<ListItem>{
                new ListItem {Name = "Qsen", ProjectName ="HR Module"}

                }),
                     new Group ("Delivery Director", new List<ListItem>{
                new ListItem {Name = "Ivanka", ProjectName ="HR Module"}

                }),
                      new Group ("CEO", new List<ListItem>{
                new ListItem {Name = "Simona"},

                })

            };

            Label nameLabel = new Label
            {
                Text = "Project name",
                FontSize = 20
            };

            Entry nameEntry = new Entry
            {
                Placeholder = "Name",
                VerticalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Text
            };

            Label descriptionLabel = new Label
            {
                Text = "Description",
                FontSize = 20
            };

            Entry descriptionEntry = new Entry
            {
                Placeholder = "Description",
                VerticalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Text
            };

            Label managerLabel = new Label
            {
                Text = "Project manager",
                FontSize = 20
            };

            Picker managerPicker = new Picker
            {
                Title = "Option",
            };

            var options = new List<string> { "First", "Second", "Third", "Fourth" };
            foreach (string optionName in options)
            {
                managerPicker.Items.Add(optionName);
            }

            listView.ItemsSource = itemsGrouped;

            Button create = new Button
            {
                Text = "Create"
            };

            StackLayout stackLayout = new StackLayout
            {
                Children = {
                    nameLabel,
                    nameEntry,
                    descriptionLabel,
                    descriptionEntry,
                    managerLabel,
                    managerPicker,
                    create
                }
            };
            this.Content = stackLayout;


            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
        }

        public class HeaderCell : ViewCell
        {
            public HeaderCell()
            {
                this.Height = 40;
                var title = new Label
                {
                    FontSize = 16,
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.Center
                };

                title.SetBinding(Label.TextProperty, "Key");



                View = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = 40,
                    BackgroundColor = Color.Black,
                    Padding = 5,
                    Orientation = StackOrientation.Horizontal,
                    Children = { title }
                };
            }
        }


        public class Group : List<ListItem>
        {
            public String Key { get; private set; }

            public Group(String key, List<ListItem> items)
            {
                Key = key;
                foreach (var item in items)
                    this.Add(item);
            }

        }
    }
}