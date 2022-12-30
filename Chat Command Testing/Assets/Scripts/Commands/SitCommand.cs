using UnityEngine;

[CreateAssetMenu(fileName = "New Sit Command", menuName = "Utilities/DeveloperConsole/Commands/Sit Command")]
public class SitCommand : ConsoleCommand
{
    public override bool Process(string[] args)
    {
        Player player = PlayerManager.Instance.FindPlayer(args[0]);
        if(player == null)
        {
            Debug.Log("No player found of name " + args[0]);
            return false;
        }

        Transform seat = Cafe.Instance.FindOpenSeat();
        if(seat == null)
        {
            Debug.Log("Read my lips: NO ROOM!");
            return false;
        }

        player.transform.position = seat.position;

        return true;
    }
}
