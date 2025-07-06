using System;
using System.Collections.Generic;
using System.Linq;
using FavouritesFeature;
using FavouritesFeature.Models;

public class UserService : IUserService
{
    private readonly List<User> _users;

    public UserService(List<User> users)
    {
        _users = users;
    }

    public AddFavouriteResult AddFavourite(int userId, int restaurantId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        if (user == null) return AddFavouriteResult.UserNotFound;
        if (user.FavouriteRestaurantIds.Contains(restaurantId)) return AddFavouriteResult.AlreadyAdded;

        user.FavouriteRestaurantIds.Add(restaurantId);
        return AddFavouriteResult.Success;
    }

    public RemoveFavouriteResponse RemoveFavourite(int userId, int restaurantId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        if (user == null) return RemoveFavouriteResponse.UserNotFound;

        return user.FavouriteRestaurantIds.Remove(restaurantId)
            ? RemoveFavouriteResponse.Success
            : RemoveFavouriteResponse.NotAFavourite;
    }

    public List<int> GetFavouritesIds(int userId)
    {
        return _users.FirstOrDefault(u => u.Id == userId)?.FavouriteRestaurantIds ?? new List<int>();
    }
}