using System;
using TMPro;
using UnityEngine;

//From https://www.youtube.com/watch?v=p-2QFmCMBt8
//I eventually want to implement this into the Developer console...maybe rename somethings?
public class ChatWindow : MonoBehaviour
{
	[SerializeField] private TMP_Text chatOutput = null;
	[SerializeField] private TMP_InputField chatInput = null;

	private static event Action<string> OnMessage;

	private void Start()
	{
		OnMessage += HandleNewMessage;
	}

	private void OnDestroy()
	{
		OnMessage -= HandleNewMessage;
	}

	private void HandleNewMessage(string message)
	{
		chatOutput.text += message;
	}

	public void Send(string message)
	{
		if(!Input.GetKeyDown(KeyCode.Return)) return;
		if(string.IsNullOrWhiteSpace(message)) return;

		NewSendMessage(chatInput.text);

		chatInput.text = string.Empty;
	}

	private void NewSendMessage(string message)
	{
		string username = "Coobbyo";
		//validate here (spam, profanity, NSFW, etc)
		HandleMessage($"[{username}]: {message}");
	}

	private void HandleMessage(string message)
	{
		OnMessage?.Invoke($"\n{message}");
	}
}
