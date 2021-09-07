using PublicAnnounceV2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAnnounceV2.Services
{
    public interface IDataService
    {
        public string AnnounceTableInsert(Announce announce);
        public string AnnounceTableUpdate(Announce announce);
        public Announce GetAnnounceById(int id);
        public List<Announce> getAllAnnounces();
    }
}
