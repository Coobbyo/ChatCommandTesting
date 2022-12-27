using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//-message
public class MessageCommand : IChatCommandHandler
{
    public void HandleCommmand(ChatCommandData data)
    {
        Debug.Log("addMessage to overlay chat");
    }
}

//-join
public class JoinCommand : IChatCommandHandler
{
    public void HandleCommmand(ChatCommandData data)
    {
        Debug.Log("New player joined");
        //PlayerManager.Instance.AddPlayer();
    }
}

public class RaceCollection : CommandCollection
{
    public RaceCollection()
    {
        commands.Add(ChatCommands.CmdMessage, new MessageCommand());
        commands.Add(ChatCommands.CmdJoin, new JoinCommand());
    }
}
