using CodingTracker.Helpers;
using HabitLogger.Dtos.HabitOccurrence;
using System.Data.SQLite;

namespace CodingTracker.Daos;

internal abstract class CodingSessionsDao
{
    internal static CodingSessionShowDTO? FindCodingSession(int id, string username)
    {
        CodingSessionShowDTO? codingSession = null;

        using (SQLiteCommand command = DatabaseHelper.CreateCommand())
        {
            DatabaseHelper.SqliteConnection!.Open();

            command.CommandText = "SELECT id, description, start_date, end_date, duration_in_seconds FROM CODING_SESSIONS WHERE id = @id AND username = @username;";
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("username", username);

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    codingSession = new CodingSessionShowDTO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt64(4));
                }
            }

            DatabaseHelper.SqliteConnection!.Close();
        }

        return codingSession;
    }

    internal static List<CodingSessionShowDTO> GetAllCodingSessions(string username)
    {
        List<CodingSessionShowDTO> codingSessions = [];

        using (SQLiteCommand command = DatabaseHelper.CreateCommand())
        {
            DatabaseHelper.SqliteConnection!.Open();
            command.CommandText = "SELECT id, description, start_date, end_date, duration_in_seconds FROM CODING_SESSIONS WHERE username = @username;";
            command.Parameters.AddWithValue("username", username);

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    codingSessions.Add(new CodingSessionShowDTO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt64(4)));
                }
            }


            DatabaseHelper.SqliteConnection!.Close();
        }

        return codingSessions;
    }

    internal static void StoreCodingSession(CodingSessionStoreDTO codingSessionStoreDTO)
    {
        DatabaseHelper.SqliteConnection!.Open();

        using (SQLiteCommand command = DatabaseHelper.CreateCommand())
        {
            command.CommandText = "INSERT INTO CODING_SESSIONS (description, username, start_date, end_date, duration_in_seconds) VALUES (@description, @username, @startDate, @endDate, @durationInSeconds)";

            command.Parameters.AddWithValue("description", codingSessionStoreDTO.Description);
            command.Parameters.AddWithValue("username", codingSessionStoreDTO.Username);
            command.Parameters.AddWithValue("startDate", codingSessionStoreDTO.StartDateTime);
            command.Parameters.AddWithValue("endDate", codingSessionStoreDTO.EndDateTime);
            command.Parameters.AddWithValue("durationInSeconds", codingSessionStoreDTO.DurationInSeconds);

            command.ExecuteNonQuery();
        }

        DatabaseHelper.SqliteConnection!.Close();
    }

    internal static bool UpdateCodingSession(CodingSessionUpdateDTO codingSessionUpdateDTO)
    {
        CodingSessionShowDTO? codingSession = FindCodingSession(codingSessionUpdateDTO.Id, codingSessionUpdateDTO.Username);

        if (codingSession != null)
        {
            DatabaseHelper.SqliteConnection!.Open();

            using (SQLiteCommand command = DatabaseHelper.CreateCommand())
            {
                command.CommandText = "UPDATE CODING_SESSIONS SET description = @description, start_date = @startDate, end_date = @endDate, duration_in_seconds = @durationInSeconds WHERE id = @id and username = @username;";

                command.Parameters.AddWithValue("id", codingSessionUpdateDTO.Id);
                command.Parameters.AddWithValue("description", codingSessionUpdateDTO.Description);
                command.Parameters.AddWithValue("startDate", codingSessionUpdateDTO.StartDateTime);
                command.Parameters.AddWithValue("endDate", codingSessionUpdateDTO.EndDateTime);
                command.Parameters.AddWithValue("username", codingSessionUpdateDTO.Username);
                command.Parameters.AddWithValue("durationInSeconds", codingSessionUpdateDTO.DurationInSeconds);

                command.ExecuteNonQuery();
            }

            DatabaseHelper.SqliteConnection!.Close();

            return true;
        }

        return false;
    }

    internal static bool DeleteCodingSession(int id, string username)
    {
        CodingSessionShowDTO? codingSession = FindCodingSession(id, username);

        if (codingSession != null)
        {
            DatabaseHelper.SqliteConnection!.Open();

            using (SQLiteCommand command = DatabaseHelper.CreateCommand())
            {
                command.CommandText = "DELETE FROM CODING_SESSIONS WHERE id = @id and username = @username;";

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("username", username);

                command.ExecuteNonQuery();
            }

            DatabaseHelper.SqliteConnection!.Close();

            return true;
        }

        return false;
    }
}
