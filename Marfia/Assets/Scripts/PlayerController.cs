using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerController : MonoBehaviourPunCallbacks
{
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
	}
}