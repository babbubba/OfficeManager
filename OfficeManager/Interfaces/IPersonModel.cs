using System;

namespace OfficeManager.Interfaces
{
    public interface IPersonModel
    {
        int Age { get; }
        DateTime BirthDate { get; set; }
        string DisplayName { get; }
        int Id { get; set; }
        string Name { get; set; }
        IRoomModel Room { get; set; }
        string Surname { get; set; }
    }
}