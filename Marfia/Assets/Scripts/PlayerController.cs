using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerController : MonoBehaviourPunCallbacks
{
	[SerializeField] GameObject cameraHolder;
	[SerializeField] float mouseSensitivity;
	float verticalLookRotation;
	PhotonView PV;
	PlayerManager playerManager;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
		playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();
	}

	void Start()
	{
		if(PV.IsMine)
		{

		}
		else
		{
			Destroy(GetComponentInChildren<Camera>().gameObject);
		}
	}

	void Update()
	{
		if(!PV.IsMine)
			return;

		Look();
	}

	void Look()
	{
		transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

		verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

		cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
	}

	public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
	{
		if(!PV.IsMine && targetPlayer == PV.Owner)
		{
			// EquipItem((int)changedProps["itemIndex"]);
		}
	}

	public void TakeDamage(float damage)
	{
		PV.RPC("RPC_TakeDamage", RpcTarget.All, damage);
	}

	[PunRPC]
	void RPC_TakeDamage(float damage)
	{
		if(!PV.IsMine)
			return;

		// if(currentHealth <= 0)
		// {
		// 	playerManager.Die();
		// }
	}
}