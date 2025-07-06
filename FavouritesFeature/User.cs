using System.Collections.Generic;

namespace FavouritesFeature;

public class User
{
    public int Id { get; init; }
    public string Name { get; set; }
    public List<int> FavouriteRestaurantIds { get; init; } = new();
}