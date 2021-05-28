using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using OfficeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeManager.Mappings
{
    public class RoomModelMapping : ClassMapping<RoomModel>
    {
        public RoomModelMapping()
        {
            Table("Rooms");
            Id(x => x.Id, map =>
            {
                map.Column("Id");
                map.Generator(Generators.Increment);
            });
            Property(x => x.Name, map => map.Length(72));
            Bag(x => x.Occupants, map => map.Key(k => k.Column("RoomId")),
                rel => rel.OneToMany(map => map.Class(typeof(PersonModel))));
        }
    }
}
