// Code was made using photon tutorial: https://www.youtube.com/watch?v=KGzMxalSqQE&t=671s&ab_channel=RugbugRedfern
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
	public string menuName;
	public bool open;

	public void Open()
	{
		open = true;
		gameObject.SetActive(true);
	}

	public void Close()
	{
		open = false;
		gameObject.SetActive(false);
	}
}