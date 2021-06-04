using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SebastianBuriComplementario
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
