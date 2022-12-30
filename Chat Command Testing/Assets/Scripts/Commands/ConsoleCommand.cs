using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsoleCommand : ScriptableObject, IConsoleCommand
{
	[SerializeField] private string commandWord = string.Empty; //Shoudl eventually make this an array of words

	public string CommandWord => commandWord;
	
	public abstract bool Process(string[] args);
}
