using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
	public int ID;
	PhotonView PV;
	GameObject controller;

	void Awake()
	{
		PV = GetComponent<PhotonView>();

		var players = PhotonNetwork.CurrentRoom.Players;
		foreach(var player in players)
		{
			if((player.Value.ToString().Contains(PV.Owner.NickName)))
			{
				ID = player.Key;
			}
		}
	}

	void Start()
	{
		if(PV.IsMine)
		{
			CreateController();
		}
	}

	void CreateController()
	{
		Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint(ID);
		controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
	}
}