
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace note
{
    interface INoteRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int _ID);
        bool Insert(string Titel,string Note);
        bool Update(int _ID, string Titel, string Note);
        bool Delete(int _ID);
    }
}
