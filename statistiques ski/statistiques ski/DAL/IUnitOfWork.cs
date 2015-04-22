using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace statistiques_ski.DAL
{
    interface IUnitOfWork : IDisposable
    {


        void Save();
    }
}