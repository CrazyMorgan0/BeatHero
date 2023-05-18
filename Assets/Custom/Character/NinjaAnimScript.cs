using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAnimScript : MonoBehaviour
{
	public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)) {
		anim.SetBool("isWalking", true);
	} else {
		anim.SetBool("isWalking", false);
	}
        if(Input.GetKey(KeyCode.X)) {
		anim.SetBool("isJumping", true);
	} else {
		anim.SetBool("isJumping", false);
	}
        if(Input.GetKey(KeyCode.C)) {
		anim.SetBool("isAttacking", true);
	} else {
		anim.SetBool("isAttacking", false);
	}
        if(Input.GetKey(KeyCode.V)) {
		anim.SetBool("isDancing", true);
	} else {
		anim.SetBool("isDancing", false);
	}
    }
}
