using System.Collections.Generic;

namespace OfficeManager.Interfaces
{
    public interface IRoom
    {
        int Id { get; set; }
        string Name { get; set; }
        IEnumerable<IPerson> Occupants { get; set; }
        int OccupantsCount { get; }
    }
}