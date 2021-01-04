using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class SpawnManager : MonoBehaviour
{
	public static SpawnManager Instance;
	public SpawnPoint[] spawnpoints;

	void Awake()
	{
		Instance = this;
		spawnpoints = GetComponentsInChildren<SpawnPoint>();
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
