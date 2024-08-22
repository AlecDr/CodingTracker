namespace HabitLogger.Dtos.HabitOccurrence;

internal class CodingSessionUpdateDTO : CodingSessionStoreDTO
{
    internal int Id { get; }

    internal CodingSessionUpdateDTO(
        int id,
        string username,
        string? description,
        string startTime,
        string endTime,
        long durationInSeconds)
        : base(username, description, startTime, endTime, durationInSeconds)
    {
        Id = id;
    }
}
