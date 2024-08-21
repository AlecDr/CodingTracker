namespace HabitLogger.Dtos.HabitOccurrence;

internal class CodingSessionShowDTO
{
    internal int Id { get; }
    internal string? Description { get; }
    internal string StartDate { get; }
    internal string EndDate { get; }

    internal CodingSessionShowDTO(int id, string? description, string startDate, string endDate)
    {
        Id = id;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
    }
}
