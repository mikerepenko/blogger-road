using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visible : MonoBehaviour
{
	GameObject Died;

	private void Start()
	{
		Died = GameObject.Find("PlayerMain");
	}

    private void OnBecameInvisible()
    {
		Died.GetComponent<Die>().dead = true;
    }
}
