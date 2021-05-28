using OfficeManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeManager.ViewModels
{
    public class PersonViewModel : IPersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DisplayName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }


    }
}
