using System;

namespace OfficeManager.Interfaces
{
    public interface IPersonViewModel
    {
        int Age { get; set; }
        DateTime BirthDate { get; set; }
        string DisplayName { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        int RoomId { get; set; }
        string RoomName { get; set; }
        string Surname { get; set; }
    }
}