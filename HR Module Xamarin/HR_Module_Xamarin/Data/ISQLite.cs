using SQLite;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Module_Xamarin.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }   
}