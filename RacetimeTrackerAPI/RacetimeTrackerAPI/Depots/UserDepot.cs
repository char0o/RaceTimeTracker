using RacetimeTrackerAPI.Context;

namespace RacetimeTrackerAPI.Depots;

public class UserDepot
{
    private readonly AppDbContext _context;

    public UserDepot(AppDbContext context)
    {
        this._context = context;
    }

    public DTOs.User? GetUserById(int id)
    {
        return this._context.Users
            .Where(u => u.Id == id)
            .Select(u => u.ToDTO())
            .FirstOrDefault();
    }
    
    public DTOs.User? GetUserByName(string name)
    {
        return this._context.Users
            .Where(u => u.Name == name)
            .Select(u => u.ToDTO())
            .FirstOrDefault();
    }

    public IEnumerable<DTOs.User> GetUsers()
    {
        return this._context.Users
            .Select(u => u.ToDTO());
    }

    public int AddUser(DTOs.User user)
    {
        Entities.User newUser = new Entities.User(user);
        this._context.Users.Add(newUser);
        this._context.SaveChanges();
        return newUser.Id;
    }
}