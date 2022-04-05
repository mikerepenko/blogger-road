using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnim : MonoBehaviour {

    Animator anim;
    public GameObject Player;

	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        Move moveScript = Player.GetComponent<Move>();
        if (moveScript.Jump == true)
        {
            anim.SetBool("Jumping", true);
        }
        else
        {
            anim.SetBool("Jumping", false);
        }
	}
}