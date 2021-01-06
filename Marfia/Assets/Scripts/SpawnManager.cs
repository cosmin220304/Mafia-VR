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
		for (int i = numberOfPlayers + 1; i < allSpawns.Length; i++)
		{
			allSpawns[i].gameObject.transform.parent.gameObject.SetActive(false);
		}


		// if (numberOfPlayers == 4)
		// {
		// 	var rolesString = new List<string>() {
		// 		"mafia",
		// 		Random.Range(0, 2) == 0 ? "doctor" : "detective",
		// 		"villager",
		// 		"villager",
		// 	};


		// }
	}

	// void populareRoles(List<string> rolesString)
	// {
	// 	int i = 0;
	// 	while (rolesString.Count > 0)
	// 	{
	// 		int index = Random.Range(0, rolesString.Count);

	// 		Hashtable roleHash = new Hashtable();
	// 		roleHash.Add("role", rolesString[index]);
	// 		PhotonNetwork.CurrentRoom.Players[i].SetCustomProperties(roleHash);

	// 		i++;
	// 		rolesString.RemoveAt(index);
	// 	}
	// }

	void Increment()
	{
		order = (int)PhotonNetwork.CurrentRoom.CustomProperties["order"];
		order++;
		Hashtable hash = new Hashtable();
		hash.Add("order", order);
		PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
	}

	void OnRoomPropertiesUpdate(Hashtable changedProps)
	{
		order = (int)changedProps["order"];
	}

	public Transform GetSpawnpoint(int id)
	{
		if(id < spawnpoints.Length)
		{
			return spawnpoints[id].transform;
		}

		Increment();
		// spawnpoint 0 is for spectators
		return spawnpoints[0].transform;
	}
}
