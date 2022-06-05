
namespace SimonSays.API.Core;

public class SimonSays : ISimonSays
{
  List<SayModel> SaysList = new List<SayModel>();
  Random rnd = new Random();

  public SayModel Compare(SayModel inputSay)
  {
    PurgeSays();

    SayModel? currSay = SaysList.SingleOrDefault(say => say.Id.Equals(inputSay.Id));
    if (currSay == null)
    {
      SayModel noExitsSay = new SayModel(0, 0);
      noExitsSay.Says.Clear(); // Count checking so NoContent() will be send
      return noExitsSay;
    }

    var areEquals = Enumerable.SequenceEqual(currSay.Says, inputSay.Says);
    if (!areEquals)
    {
      SaysList.Remove(currSay);

      SayModel failSay = new SayModel(0, 0);
      failSay.Says.Clear(); // Count checking so NoContent() will be send
      return failSay;
    }

    currSay.Says.Add(rnd.Next(currSay.MaxValue) + 1);
    currSay.LastUpdate = DateTime.Now;
    return currSay;
  }

  public SayModel GetSays(int interactWaitMinutes, int maxValue)
  {
    PurgeSays();

    SayModel newSay = new SayModel(interactWaitMinutes, maxValue);
    SaysList.Add(newSay);
    return newSay;
  }

  void PurgeSays()
  {
    SaysList.RemoveAll(say => (DateTime.Now - say.LastUpdate).TotalMinutes > say.MinutesUntilRemove);
  }
}
