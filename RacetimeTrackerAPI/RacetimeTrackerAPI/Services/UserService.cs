using RacetimeTrackerAPI.Depots;
using RacetimeTrackerAPI.DTOs;

namespace RacetimeTrackerAPI.Services;

public class UserService
{
    private readonly UserDepot _userDepot;

    public UserService(UserDepot userDepot)
    {
        this._userDepot = userDepot;
    }

    public User? GetUserByName(string name)
    {
        return this._userDepot.GetUserByName(name);
    }

    public IEnumerable<User> GetUsers()
    {
        return this._userDepot.GetUsers();
    }

    public User? GetUserById(int id)
    {
        return this._userDepot.GetUserById(id);
    }

    public int AddUser(User user)
    {
        return this._userDepot.AddUser(user);
    }
}