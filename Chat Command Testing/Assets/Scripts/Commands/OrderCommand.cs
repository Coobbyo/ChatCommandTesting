using UnityEngine;

[CreateAssetMenu(fileName = "New Order Command", menuName = "Utilities/DeveloperConsole/Commands/Order Command")]
public class OrderCommand : ConsoleCommand
{
    public override bool Process(string[] args)
    {
        string logText = string.Join(" ", args);

        Debug.Log(logText);

        return true;
    }
}
