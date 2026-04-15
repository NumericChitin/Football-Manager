using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Data.Models;

namespace WinFormsApp1.Logic
{
    public class BaseOperation<T> : IDisposable where T : class
    {
        protected FootballManagerContext db;
        protected DbSet<T> Set;

        public BaseOperation()
        {
            string connString = Program.Configuration.GetConnectionString("FootballManagerDb");
            db = new FootballManagerContext(connString);

            Set = db.Set<T>();
            Set.Load();
        }

        public BindingList<T> GetBindingList()
            => Set.Local.ToBindingList();

        public void Add(T entity) => Set.Add(entity);
        public void Remove(T entity) => Set.Remove(entity);
        public void Save() => db.SaveChanges();

        public void Dispose() => db?.Dispose();
        public FootballManagerContext Context => db;
    }

}
