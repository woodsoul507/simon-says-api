using Microsoft.AspNetCore.Mvc;
using SimonSays.API.Core;

namespace SimonSays.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class SimonSaysController : ControllerBase
{
  private readonly ISimonSays _simonSays;

  public SimonSaysController(ISimonSays simonSays)
  {
    _simonSays = simonSays;
  }

  /// <summary>
  /// New Simon Says
  /// </summary>
  /// <returns>Starts a new Simon Says game</returns>
  /// <remarks>
  /// Sample request:
  ///
  ///     Default interactWaitMinutes = 5 and maxValue = 4
  ///     GET /SimonSays
  ///     
  ///     or
  ///     
  ///     Custom interactWaitMinutes and maxValue query parameter
  ///     GET /SimonSays?interactWaitMinutes=2&amp;maxValue=6
  ///
  /// </remarks>
  /// <response code="200">Returns a new Simon Says</response>
  [HttpGet(Name = "Get")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public IActionResult Get([FromQuery] int interactWaitMinutes = 5, [FromQuery] int maxValue = 4)
  {
    SayModel says = _simonSays.GetSays(interactWaitMinutes, maxValue);
    return Ok(says);
  }

  /// <summary>
  /// Compare Simon Says
  /// </summary>
  /// <returns>Current Simon Says with new number added</returns>
  /// <remarks>
  /// Sample request:
  ///
  ///     POST /SimonSays
  ///     {
  ///         "id": "811f2c97-1bdb-4be2-b610-1920a112e2e0-258333523301",
  ///         "says": [
  ///            2,
  ///            4
  ///         ]
  ///     }
  ///
  /// </remarks>
  /// <response code="201">Returns the current Simon Says with new Say (number) added</response>
  /// <response code="204">Empty response if input was incorrect or has expired already</response>
  [HttpPost(Name = "Post")]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult Post([FromBody] SayModel sayModel)
  {
    SayModel response = _simonSays.Compare(sayModel);
    if (response.Says.Count == 0)
    {
      return NoContent();
    }

    return StatusCode(StatusCodes.Status201Created, response);
  }
}
