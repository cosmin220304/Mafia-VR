using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerController : MonoBehaviourPunCallbacks
{
	public string Role;

	[SerializeField] GameObject camera, gvrReticlePointer, gvrEditorEmulator;
	PhotonView PV;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
		Cursor.visible = false;
	}

	void Start()
	{
		if(PV.IsMine)
		{

		}
		else
		{
			Destroy(camera.GetComponent<AudioListener>());
			Destroy(camera.GetComponent<FlareLayer>());
			Destroy(camera.GetComponent<Camera>());
			Destroy(gvrReticlePointer.gameObject);
			Destroy(gvrEditorEmulator.gameObject);
		}

		if (PhotonNetwork.IsMasterClient)
		{
			var numberOfPlayers = PhotonNetwork.CurrentRoom.Players.Count;
			var rolesString = new List<string>();
			if (numberOfPlayers == 2)
			{
				rolesString.Add("villager1");
				rolesString.Add("villager2");
			}
			else if (numberOfPlayers == 4)
			{
				rolesString.Add("mafia");
				rolesString.Add(Random.Range(0, 2) == 0 ? "doctor" : "detective");
				rolesString.Add("villager1");
				rolesString.Add("villager2");
			}
			populateRoles(rolesString);
		}
		else
		{
			Debug.Log("You are a non master client");
		}
	}

	void populateRoles(List<string> rolesString)
	{
		int i = 0;
		while (rolesString.Count > 0)
		{
			int index = Random.Range(0, rolesString.Count);

			Debug.Log("Role " + rolesString[index] + " player" + i);
			i++;
			rolesString.RemoveAt(index);
		}
	}
}