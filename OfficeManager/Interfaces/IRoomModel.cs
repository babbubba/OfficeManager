using System.Collections.Generic;

namespace OfficeManager.Interfaces
{
    public interface IRoomModel
    {
        int Id { get; set; }
        string Name { get; set; }
        IEnumerable<IPersonModel> Occupants { get; set; }
        int OccupantsCount { get; }
    }
}