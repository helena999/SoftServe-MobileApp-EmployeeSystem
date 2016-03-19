using HR_Module_Xamarin.Data;
using HR_Module_Xamarin.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HR_Module_Xamarin
{
    public class App : Application
    {
        static HRModuleDataBase database;
        public static HRModuleDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new HRModuleDataBase();
                }
                return database;
            }
        }
        public int ResumeAtTodoId { get; set; }
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
