using Domain.Models;
using LibraryConsoleProject.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;

Menues();
LibraryController library = new();

while (true)
{

    Operation: string operationStr = Console.ReadLine();

    int operation;

    bool isCorrectOperation = int.TryParse(operationStr, out operation);

    if (isCorrectOperation)
    {

        switch (operation)
        {
            case (int)Operations.CreateLibrary:
                library.Create();
                break;
            case (int)Operations.DeleteLibrary:
                Console.WriteLine("Library delete");
                break;
            case (int)Operations.EditLibrary:
                Console.WriteLine("Library edit");
                break;
            case (int)Operations.GetAllLibraries:
                library.GetAll();
                break;
            case (int)Operations.GetLibraryById:
                library.GetById();
                break;
            case (int)Operations.FilterBySeatCount:
                library.FilterBySeatCount();
                break;
            case (int)Operations.SearchByName:
                library.SearchByName();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Please write correct option");
                goto Operation;
                
        }
    }

    else
    {
        ConsoleColor.Red.WriteConsole("Please write correct option format");
        goto Operation;
    }
}



static void Menues()
{
    ConsoleColor.Cyan.WriteConsole("Choose one option for working with application: " +
    "Library Operations: 1 - Create, 2 - Delete, 3 - Edit,4 - GetAll, 5 - GetById");
}