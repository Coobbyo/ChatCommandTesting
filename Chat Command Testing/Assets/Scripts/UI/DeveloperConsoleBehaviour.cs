using System;
using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class DeveloperConsoleBehaviour : MonoBehaviour
{
	[SerializeField] private string prefix = string.Empty;
	[SerializeField] private ConsoleCommand[] commands =  new ConsoleCommand[0];

	[SerializeField] private bool freezeOnType = true;

	[Header("UI")]
	[SerializeField] private GameObject uiCanvas = null;
	[SerializeField] private TMP_Text chatOutput = null;
	[SerializeField] private TMP_InputField chatInput = null;

	private float pausedTimeScale;
	private static event Action<string> OnMessage;

	private static DeveloperConsoleBehaviour instance;

	private DeveloperConsole developerConsole;
	private DeveloperConsole DeveloperConsole
	{
		get
		{
			if(developerConsole != null) { return developerConsole; }
			return developerConsole = new DeveloperConsole(prefix, commands);
		}
	}

	private void Awake()
	{
		if(instance != null && instance != this)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;

		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		OnMessage += HandleNewMessage;
	}

	private void OnDestroy()
	{
		OnMessage -= HandleNewMessage;
	}

	public void Toggle(CallbackContext context)
	{
		if(!context.action.triggered) return;

		if(uiCanvas.activeSelf)
		{
			Time.timeScale = pausedTimeScale;
			uiCanvas.SetActive(false);
		}
		else
		{
			pausedTimeScale = Time.timeScale;
			Time.timeScale = freezeOnType ? 0 : 1;
			uiCanvas.SetActive(true);
			chatInput.ActivateInputField();
		}
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

	public void ProcessCommand(string inputValue)
	{
		DeveloperConsole.ProcessCommand(inputValue);

		//chatInput.text = string.Empty;
	}
}
