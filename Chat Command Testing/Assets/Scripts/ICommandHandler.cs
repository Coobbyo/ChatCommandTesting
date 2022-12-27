using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChatCommandHandler
{
    void HandleCommmand(ChatCommandData data);
}

//data for each command
public class ChatCommandData
{
    public string Author;
    public List<string> Arguments;
}

//Definition of prefex and list of commands
//Is there a better way of doing this? I'm moving this to the same file as the Generic Commands for now
public static class ChatCommands
{
    public static readonly string CmdPrefix = "-"; //command prefix
    public static readonly string CmdMessage = "message";
    public static readonly string CmdJoin = "join";
}

//!message command
public class DisplayMessageCommand : IChatCommandHandler
{
    public void HandleCommmand(ChatCommandData data)
    {
        //Debug.Log($"<color=cyan>Raw Message:{data.Message}</color>");

        // strip the !message command from the message and trim the leading whitespace
        //string actualMessage = data.Message.Substring(0 + (ChatCommands.CmdPrefix + ChatCommands.CmdMessage).Length).TrimStart(' ');
        //Debug.Log($"<color=cyan>{data.Author} says {actualMessage}</color>");
    }
}

public class CommandCollection
{
    protected Dictionary<string, IChatCommandHandler> commands;

    //Can have different collections for different scenes
    public CommandCollection()
    {
        commands = new Dictionary<string, IChatCommandHandler>();
        commands.Add(ChatCommands.CmdMessage, new DisplayMessageCommand());
    }

    public bool HasCommand(string command)
    {
        return commands.ContainsKey(command) ? true : false;
    }

    public void ExecuteCommand(string command, ChatCommandData data)
    {
        command = command.Substring(1); //Remove the command prefix
        if(HasCommand(command))
        {
            commands[command].HandleCommmand(data);
        }
    }
}
