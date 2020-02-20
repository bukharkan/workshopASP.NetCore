using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopACCICore.Models;

namespace WorkshopACCICore.DAL
{
    public interface IMahasiswa
    {
        IEnumerable<Mahasiswa> GetAll();
        Mahasiswa GetById(string id);
        void Insert(Mahasiswa mahasiswa);
        void Update(Mahasiswa mahasiswa);
        void Delete(Mahasiswa mahasiswa);
    }
}
