using System.Collections.Generic;
using System.Linq;

public class UserService
{
    private readonly List<User> _users;

    public UserService(List<User> users)
    {
        _users = users;
    }

    public void AddFavourite(int userId, int restaurantId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        if (user != null && !user.FavouriteRestaurantIds.Contains(restaurantId))
        {
            user.FavouriteRestaurantIds.Add(restaurantId);
        }
    }

    public void RemoveFavourite(int userId, int restaurantId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        user?.FavouriteRestaurantIds.Remove(restaurantId);
    }

    public List<int> GetFavourites(int userId)
    {
        return _users.FirstOrDefault(u => u.Id == userId)?.FavouriteRestaurantIds ?? new List<int>();
    }
}