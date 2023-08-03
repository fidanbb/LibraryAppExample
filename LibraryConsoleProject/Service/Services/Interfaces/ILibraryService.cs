using System;
using System.Linq.Expressions;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface ILibraryService
	{
		void Create(Library library);

		List<Library> GetAll();

		Library GetById(int id);

		List<Library> GetAllByExpression(Expression<Func<Library, bool>> expression);
    } 
}

