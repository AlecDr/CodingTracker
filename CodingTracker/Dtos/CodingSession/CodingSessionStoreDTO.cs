namespace HabitLogger.Dtos.HabitOccurrence;

internal class CodingSessionStoreDTO
{
    internal string Username { get; }
    internal string? Description { get; }
    internal string StartDateTime { get; }
    internal string EndDateTime { get; }
    internal long DurationInSeconds { get; }

    internal CodingSessionStoreDTO(string username, string? description, string startDateTime, string endDateTime, long durationInSeconds)
    {
        Username = username;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        DurationInSeconds = durationInSeconds;
    }
}
