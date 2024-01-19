using MonkeyFinder.Interfaces.Services;

namespace MonkeyFinder.Services;

public class MonkeyService : IMonkeyService
{
    public async Task<IList<Monkey>> GetMonkeys()
    {
        IList<Monkey> monkeyList = new List<Monkey>();

        return monkeyList;
    }
}
