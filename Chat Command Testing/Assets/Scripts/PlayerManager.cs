using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	[SerializeField] private GameObject playerPrefab;
	[SerializeField] private float spawnRadius = 1f;

	private List<Player> players = new List<Player>();

	private  static PlayerManager instance;
	public static PlayerManager Instance { get { return instance; } }

	private void Awake()
	{
		if(instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
		}
	}

	public bool SpawnPlayer(string username)
	{
		if(FindPlayer(username) != null) return false;

		Vector3 spawnPoint = new Vector3(Random.Range(0f, spawnRadius), 0f, Random.Range(0f, spawnRadius));
		GameObject playerGO = Instantiate(playerPrefab, spawnPoint, Quaternion.identity, transform);

		Player player = playerGO.GetComponent<Player>();
		player.username = username;
		players.Add(player);

		return true;
	}

	public Player FindPlayer(string username)
	{
		foreach (Player player in players)
		{
			if(username == player.username)
				return player;
		}

		return null;
	}
}
