using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafe : MonoBehaviour
{
	[SerializeField] private List<Transform> availableSeats = new List<Transform>();
	private List<Transform> occupiedSeats = new List<Transform>();

	private  static Cafe instance;
	public static Cafe Instance { get { return instance; } }

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

	public Transform FindOpenSeat()
	{
		if(availableSeats.Count > 0)
		{
			Transform seat = availableSeats[Random.Range(0, availableSeats.Count)];
			availableSeats.Remove(seat);
			occupiedSeats.Add(seat);
			return seat;
		}

		return null;
	}
}
