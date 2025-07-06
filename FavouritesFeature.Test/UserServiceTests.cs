using FavouritesFeature.Models;

namespace FavouritesFeature.Test;

public class UserServiceTests
{
    [Fact]
    public void AddFavourite_ShouldReturnSuccess_WhenNewFavouriteIsAdded()
    {
        var user = new User
        {
            Id = 1,
            Name = "TestUser",
            FavouriteRestaurantIds = new List<int>()
        };
        var users = new List<User> { user };

        var userService = new UserService(users);
        var result = userService.AddFavourite(user.Id, 1);

        Assert.Equal(AddFavouriteResult.Success, result);
    }

    [Fact]
    public void AddFavourite_ShouldReturnAlreadyAdded_WhenRestaurantIdAlreadyFavourited()
    {
        var user = new User
        {
            Id = 1,
            Name = "TestUser",
            FavouriteRestaurantIds = new List<int> { 1 }
        };
        var users = new List<User> { user };

        var userService = new UserService(users);
        var result = userService.AddFavourite(user.Id, 1);

        Assert.Equal(AddFavouriteResult.AlreadyAdded, result);
        Assert.Single(user.FavouriteRestaurantIds);
    }

    [Fact]
    public void AddFavourite_ShouldReturnUserNotFound_WhenUserDoesNotExist()
    {
        var users = new List<User>();

        var userService = new UserService(users);
        var result = userService.AddFavourite(1, 1);

        Assert.Equal(AddFavouriteResult.UserNotFound, result);
    }

    [Fact]
    public void RemoveFavourite_ShouldReturnSuccess_WhenNewFavouriteIsDeleted()
    {
        var user = new User
        {
            Id = 1,
            Name = "TestUser",
            FavouriteRestaurantIds = new List<int>()
        };
        var users = new List<User> { user };

        var userService = new UserService(users);
        var result = userService.RemoveFavourite(user.Id, 1);

        Assert.Equal(RemoveFavouriteResponse.Success, result);
    }

    [Fact]
    public void RemoveFavourite_ShouldReturnUserNotFound_WhenUserDoesNotExist()
    {
        var users = new List<User>();

        var userService = new UserService(users);
        var result = userService.RemoveFavourite(1, 1);

        Assert.Equal(RemoveFavouriteResponse.UserNotFound, result);
    }

    [Fact]
    public void RemoveFavourite_ShouldReturnNotAFavourite_WhenIdNotFound()
    {
        var user = new User
        {
            Id = 1,
            Name = "TestUser",
            FavouriteRestaurantIds = new List<int> { 2 }
        };
        var users = new List<User> { user };

        var userService = new UserService(users);
        var result = userService.RemoveFavourite(1, 1);

        Assert.Equal(RemoveFavouriteResponse.NotAFavourite, result);
        Assert.Single(user.FavouriteRestaurantIds);
    }

    [Fact]
    public void GetFavouritesIds_ShouldReturnList_WhenGivenUserId()
    {
        var user = new User
        {
            Id = 1,
            Name = "TestUser",
            FavouriteRestaurantIds = new List<int> { 1, 2 }
        };
        var users = new List<User> { user };

        var userService = new UserService(users);
        var favouriteIds = userService.GetFavouritesIds(user.Id);

        Assert.Equal(user.FavouriteRestaurantIds, favouriteIds);
    }

    [Fact]
    public void GetFavouritesIds_ShouldReturnEmptyList_IfProvidedUserDoesNotExist()
    {
        var users = new List<User>();

        var userService = new UserService(users);
        var favouriteIds = userService.GetFavouritesIds(1);

        Assert.Equal(new List<int>(), favouriteIds);
    }
}