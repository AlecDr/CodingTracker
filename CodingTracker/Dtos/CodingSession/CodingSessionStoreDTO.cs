namespace HabitLogger.Dtos.HabitOccurrence;

internal class CodingSessionStoreDTO
{
    internal string Username { get; }
    internal string? Description { get; }
    internal string StartDateTime { get; }
    internal string EndDateTime { get; }

    internal CodingSessionStoreDTO(string username, string? description, string startDateTime, string endDateTime)
    {
        Username = username;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
    }
}
