using System.Collections.Generic;
using FavouritesFeature.Models;

namespace FavouritesFeature;

public interface IUserService
{
    AddFavouriteResult AddFavourite(int userId, int restaurantId);
    RemoveFavouriteResponse RemoveFavourite(int userId, int restaurantId);
    List<int> GetFavouritesIds(int userId);
}