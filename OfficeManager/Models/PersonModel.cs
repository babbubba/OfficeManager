using bs.Data.Interfaces.BaseEntities;
using OfficeManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeManager.Models
{
    public class PersonModel : IPersonModel, IPersistentEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string DisplayName
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }

        public virtual DateTime BirthDate { get; set; }

        public virtual int Age
        {
            get
            {
                return DateTime.Today.Year - BirthDate.Year;
            }
        }

        public virtual IRoomModel Room { get; set; }
    }
}
