using System;
using System.Text.RegularExpressions;
using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;

namespace LibraryConsoleProject.Controllers
{
	public class LibraryController
	{
		private readonly ILibraryService _libraryService;

		public LibraryController()
		{
			_libraryService = new LibraryService();
		}

		public void Create()
		{
			ConsoleColor.Cyan.WriteConsole("Add library name");
			Name: string name = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(name))
			{
                ConsoleColor.Red.WriteConsole("Dont be empty");
                goto Name;
            }

			bool isMatch = Regex.IsMatch(name, @"\d");

			if (isMatch)
			{
                ConsoleColor.Red.WriteConsole("Dont add digit format");
                goto Name;
            }

            SeatCount: ConsoleColor.Cyan.WriteConsole("Add library seat count");
            string seatCountStr = Console.ReadLine();

			int seatCount;

			bool isCorrectSeatCount = int.TryParse(seatCountStr, out seatCount);

			if (isCorrectSeatCount)

			{
				Library library = new()
				{
					Name = name,
					SeatCount = seatCount

				};
				_libraryService.Create(library);
				ConsoleColor.Green.WriteConsole("Library create success");

			}
			else
			{
				ConsoleColor.Red.WriteConsole("Please add seatCount format again");
				goto SeatCount;
			}

        }


		public void GetAll()
		{
			var result = _libraryService.GetAll();

			foreach (var item in result)
			{
				string data = $"{item.Id} - {item.Name} - {item.SeatCount}";
				ConsoleColor.Green.WriteConsole(data);
			}
		}

		public void GetById()
		{
            ConsoleColor.Cyan.WriteConsole("Add Library Id");
			Id: string idStr = Console.ReadLine();

			int id;

			bool IsCorrectId = int.TryParse(idStr, out id);

			if (IsCorrectId)
			{
				var result = _libraryService.GetById(id);

				if (result is null)
				{

                    ConsoleColor.Red.WriteConsole("Data not found,Write id again");
                    goto Id;
                }

                string data = $"{result.Id} - {result.Name} - {result.SeatCount}";
                ConsoleColor.Green.WriteConsole(data);
            }
			else
			{
                ConsoleColor.Red.WriteConsole("Please add id format again");
                goto Id;
            }

        }


		public void FilterBySeatCount()
		{
        SeatCount: ConsoleColor.Cyan.WriteConsole("Add First seat count");
            string firstSeatCountStr = Console.ReadLine();

            int firstSeatCount;

            bool isCorrectFirstSeatCount = int.TryParse(firstSeatCountStr, out firstSeatCount);

            ConsoleColor.Cyan.WriteConsole("Add second seat count");
            string secondSeatCountStr = Console.ReadLine();

            int secondSeatCount;

            bool isCorrectSecondSeatCount = int.TryParse(secondSeatCountStr, out secondSeatCount);

			if (isCorrectFirstSeatCount && isCorrectSecondSeatCount)
			{
				var result = _libraryService.GetAllByExpression(m=>m.SeatCount>firstSeatCount && m.SeatCount<secondSeatCount);

				foreach (var item in result)
				{
                    string data = $"{item.Id} - {item.Name} - {item.SeatCount}";
                    ConsoleColor.Green.WriteConsole(data);
                }
			}
			else
			{
                ConsoleColor.Red.WriteConsole("Please add correct format for seat counts");
                goto SeatCount;
            }
        }


        public void SearchByName()
        {

            ConsoleColor.Cyan.WriteConsole("Add text");
        SearchText: string searchText = Console.ReadLine();

            if (searchText == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("You must enter something");
                goto SearchText;
            }
	
			
                List<Library> result = _libraryService.GetAllByExpression(m => m.Name.Contains(searchText));

          

            if (result is null)
			{
				ConsoleColor.Red.WriteConsole("Data not Found");
				goto SearchText;
			}

			else
			{
				foreach (var item in result)
				{
					string data = $"{item.Id} - {item.Name} - {item.SeatCount}";
					ConsoleColor.Green.WriteConsole(data);
				}

			}


        }

    }
}

