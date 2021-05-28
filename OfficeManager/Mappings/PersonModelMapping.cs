using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using OfficeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeManager.Mappings
{
    public class PersonModelMapping : ClassMapping<PersonModel>
    {
        public PersonModelMapping()
        {
            Table("Persons");
            Id(x => x.Id, map =>
            {
                map.Column("Id");
                map.Generator(Generators.Increment);
            });
            Property(x => x.Name, map => map.Length(72));
            Property(x => x.Surname, map => map.Length(72));
            Property(x => x.BirthDate);
            ManyToOne(x => x.Room, map =>
            {
                map.Class(typeof(RoomModel));
                map.ForeignKey("FK_Persons_Room");
                map.Column("RoomId");
                map.Fetch(FetchKind.Join);
                map.Lazy(LazyRelation.NoLazy);
            });

        }
    }
}
