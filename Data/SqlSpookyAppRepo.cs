using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpookyApp.Data;
using SpookyApp.Models;

namespace SpookyApp.Data
{
    public class SqlSpookyAppRepo : ISpookyAppRepo
    {
        private readonly SpookyAppContext _context;

        public SqlSpookyAppRepo(SpookyAppContext context)
        {
            _context = context;
        }

        public void CreateSpooky(Spooky cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Spookys.Add(cmd);
        }

        public void DeleteSpooky(Spooky cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Spookys.Remove(cmd);
        }

        public IEnumerable<Spooky> GetAllSpooky()
        {
            return _context.Spookys.ToList();
        }

        public Spooky GetSpookyById(int id)
        {
            return _context.Spookys.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSpooky(Spooky cmd)
        {

        }
    }
}
