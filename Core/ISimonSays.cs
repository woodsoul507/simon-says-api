
namespace SimonSays.API.Core;

public interface ISimonSays
{
  public SayModel Compare(SayModel inputSay);

  public SayModel GetSays(int minutesUntilRemove, int maxValue);
}
