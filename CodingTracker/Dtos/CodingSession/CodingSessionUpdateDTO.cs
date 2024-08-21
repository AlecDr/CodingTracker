namespace HabitLogger.Dtos.HabitOccurrence;

internal class CodingSessionUpdateDTO : CodingSessionStoreDTO
{
    internal int Id { get; }
    internal CodingSessionUpdateDTO(int id, string username, string? description, string startTime, string endTime) : base(username, description, startTime, endTime)
    {
        Id = id;
    }
}
