using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class SpawnManager : MonoBehaviourPunCallbacks
{
	public static SpawnManager Instance;
	public SpawnPoint[] spawnpoints;
	public int order;

	void Awake()
	{
		Instance = this;

		var allSpawns = GetComponentsInChildren<SpawnPoint>();
		var numberOfPlayers = PhotonNetwork.CurrentRoom.Players.Count;

		//INIT SPAWNPOINTS
		spawnpoints = new SpawnPoint[numberOfPlayers + 1];
		for(int i = 0; i <= numberOfPlayers; i++)
		{
			spawnpoints[i] = allSpawns[i];
		}
		for (int i = numberOfPlayers+1; i < allSpawns.Length; i++)
		{
			allSpawns[i].gameObject.transform.parent.gameObject.SetActive(false);
		}
	}

	public Transform GetSpawnpoint(int id)
	{
		if(id < spawnpoints.Length)
		{
			return spawnpoints[id].transform;
		}

		// spawnpoint 0 is for spectators
		return spawnpoints[0].transform;
	}
}
