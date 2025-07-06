using System;
using System.Threading.Tasks;
using FavouritesFeature.Models;
using Microsoft.AspNetCore.Mvc;

namespace FavouritesFeature.Controllers;

[ApiController]
[Route("users/{userId}/favourites")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult AddFavourite([FromRoute]int userId, [FromBody] int restaurantId)
    {
        var result = _userService.AddFavourite(userId, restaurantId);
        switch (result)
        {
            case AddFavouriteResult.Success:
                return Ok();
            case AddFavouriteResult.UserNotFound:
                return NotFound("User not found");
            case AddFavouriteResult.AlreadyAdded:
                return Conflict("Restaurant is already in the favourites list.");
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    [HttpDelete("{restaurantId:int}")]
    public IActionResult RemoveFavourite([FromRoute]int userId, [FromRoute] int restaurantId)
    {
        var result = _userService.RemoveFavourite(userId, restaurantId);
        switch (result)
        {
            case RemoveFavouriteResponse.Success:
                return NoContent();
            case RemoveFavouriteResponse.UserNotFound:
                return NotFound("User not found");
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    [HttpGet]
    public IActionResult GetFavourites([FromRoute] int userId)
    {
        var favouritesIds = _userService.GetFavouritesIds(userId); 
        return Ok(favouritesIds);
    }
}