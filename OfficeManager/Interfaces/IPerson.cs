using System;

namespace OfficeManager.Interfaces
{
    public interface IPerson
    {
        int Age { get; }
        DateTime BirthDate { get; set; }
        string DisplayName { get; }
        int Id { get; set; }
        string Name { get; set; }
        IRoom Room { get; set; }
        string Surname { get; set; }
    }
}