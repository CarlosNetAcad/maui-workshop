using System;
namespace MonkeyFinder.Interfaces.Services
{
	public interface IMonkeyService
	{
		Task<IList<Monkey>> GetMonkeys();
	}
}

