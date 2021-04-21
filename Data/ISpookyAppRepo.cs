using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpookyApp.Models;

namespace SpookyApp.Data
{
    public interface ISpookyAppRepo
    {
        bool SaveChanges();
        IEnumerable<Spooky> GetAllSpooky();
        Spooky GetSpookyById(int id);
        void CreateSpooky(Spooky cmd);
        void UpdateSpooky(Spooky cmd);
        void DeleteSpooky(Spooky cmd);
    }
}
