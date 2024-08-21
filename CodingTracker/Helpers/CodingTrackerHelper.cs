
using CodingTracker.Daos;
using HabitLogger.Dtos.HabitOccurrence;

namespace CodingTracker.Helpers;

internal class CodingTrackerHelper
{
    string? CurrentUser { get; set; }

    internal void Run()
    {
        while (CurrentUser == null)
        {
            CheckUser();
        }

        string option = GetOption();

        RouteToOption(option.ElementAt(0));
    }

    private string GetOption()
    {
        string option = ConsoleHelper.ShowMainMenu(CurrentUser!);

        while (option == null || option.Trim() == "")
        {
            ConsoleHelper.ClearWindow();
            option = ConsoleHelper.ShowMainMenu(CurrentUser!);
        }

        return option;
    }

    private void CheckUser()
    {
        if (CurrentUser == null)
        {
            AskName();
            ConsoleHelper.ClearWindow();
        }
    }

    private void AskName()
    {
        ConsoleHelper.ShowTitle("User Selection");

        string? name = ConsoleHelper.GetText("What is your [blue]name[/]? ");

        if (name != null && name.Trim().Length > 0)
        {
            CurrentUser = name;
        }
    }

    private void CreateCodingSession()
    {
        ConsoleHelper.ShowTitle("Create an Coding Session");

        string? description = ConsoleHelper.GetText("What's the description?");
        DateTime startDate = ConsoleHelper.GetDateTime("Enter the start date");
        DateTime endDate = ConsoleHelper.GetDateTime("Enter the end date");

        CodingSessionsDao.StoreCodingSession(new CodingSessionStoreDTO(
            CurrentUser!,
            description,
            startDate.ToString("yyyy-MM-dd HH:mm:ss"),
            endDate.ToString("yyyy-MM-dd HH:mm:ss"))
        );

        ConsoleHelper.ShowMessage("Coding session stored successfully!");

        ConsoleHelper.PressAnyKeyToContinue();
    }

    private void UpdateCodingSession()
    {
        ConsoleHelper.ShowTitle("Update an codingSession");

        int? id = ShowCodingSessionsAndAskForId("Whats the Coding session ID to update?");

        if (id.HasValue)
        {
            string? description = ConsoleHelper.GetText("What's the description?");
            DateTime startDate = ConsoleHelper.GetDateTime("Enter the start date");
            DateTime endDate = ConsoleHelper.GetDateTime("Enter the end date");



            bool result = CodingSessionsDao.UpdateCodingSession(new CodingSessionUpdateDTO(
                id.Value,
                CurrentUser!,
                description,
                startDate.ToString("yyyy-MM-dd HH:mm:ss"),
                endDate.ToString("yyyy-MM-dd HH:mm:ss"))
            );

            ConsoleHelper.ShowMessage(result ? "Coding session updated successfully!" : "Something went wrong :(");
            ConsoleHelper.PressAnyKeyToContinue();
        }
        else
        {
            ConsoleHelper.ShowMessage("No Coding sessions found.");
            ConsoleHelper.PressAnyKeyToContinue();
        }
    }

    private void DeleteCodingSession()
    {
        ConsoleHelper.ShowTitle("Delete a Coding session");

        int? id = ShowCodingSessionsAndAskForId("Whats the Coding session ID to delete?");

        if (id.HasValue)
        {
            bool result = CodingSessionsDao.DeleteCodingSession(id.Value, CurrentUser!);

            ConsoleHelper.ShowMessage(result ? "Coding session deleted successfully!" : "Something went wrong :(");
            ConsoleHelper.PressAnyKeyToContinue();
        }
        else
        {
            ConsoleHelper.ShowMessage("No Coding sessions found.");
            ConsoleHelper.PressAnyKeyToContinue();
        }
    }

    private void PrintCodingSession(CodingSessionShowDTO codingSession)
    {
        ConsoleHelper.ShowMessage($"{codingSession.Id} - {codingSession.StartDate} to {codingSession.EndDate} - {codingSession.Description}");
    }

    private void ListCodingSessions()
    {
        ConsoleHelper.ShowTitle("List of codingSessions");

        List<CodingSessionShowDTO> codingSessions = CodingSessionsDao.GetAllCodingSessions(CurrentUser!);

        if (codingSessions.Count() > 0)
        {
            foreach (CodingSessionShowDTO codingSession in codingSessions)
            {
                PrintCodingSession(codingSession);
            }

            ConsoleHelper.PressAnyKeyToContinue();
        }
        else
        {
            ConsoleHelper.ShowMessage("No Coding sessions found.");
            ConsoleHelper.PressAnyKeyToContinue();
        }

    }

    private int? ShowCodingSessionsAndAskForId(string message)
    {
        List<CodingSessionShowDTO> codingSessions = CodingSessionsDao.GetAllCodingSessions(CurrentUser!);

        if (codingSessions.Count <= 0)
        {
            return null;
        }
        else
        {
            foreach (CodingSessionShowDTO codingSession in codingSessions)
            {
                PrintCodingSession(codingSession);
            }

            ConsoleHelper.ShowMessage("");

            int.TryParse(ConsoleHelper.GetText(message), out int id);

            return codingSessions.Where(codingSession => codingSession.Id == (id > 0 ? id : 0)).Count() > 0 ? id : null;
        }
    }

    private void RouteToOption(char option)
    {
        switch (option)
        {
            case '1':
                CreateCodingSession();
                Run();
                break;
            case '2':
                ListCodingSessions();
                Run();
                break;
            case '3':
                UpdateCodingSession();
                Run();
                break;
            case '4':
                DeleteCodingSession();
                Run();
                break;
            case '5':
                AskName();
                Run();
                break;

            default:
                Run();
                break;
        }
    }

    internal static List<string> GetMenuChoices()
    {
        return [
            "1 - [blue]C[/]reate a Coding session",
            "2 - [blue]L[/]ist all Coding sessions",
            "3 - [blue]U[/]pdate Coding session",
            "4 - [blue]D[/]elete Coding session",
            "5 - [blue]A[/]lter username",
            ];
    }
}
