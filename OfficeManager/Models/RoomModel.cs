using OfficeManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeManager.Models
{
    public class RoomModel : IRoomModel
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual IEnumerable<IPersonModel> Occupants { get; set; }

        public virtual int OccupantsCount
        {
            get
            {
                return Occupants?.Count() ?? 0;
            }
        }
    }
}
