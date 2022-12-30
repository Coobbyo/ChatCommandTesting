using UnityEngine;

[CreateAssetMenu(fileName = "New Join Command", menuName = "Utilities/DeveloperConsole/Commands/Join Command")]
public class JoinCommand : ConsoleCommand
{
	public override bool Process(string[] args)
	{
		return PlayerManager.Instance.SpawnPlayer(args[0]);
	}
}
