using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAnimScript : MonoBehaviour
{
	public Animator ninjaAnimator;

	IEnumerator CrouchAndStand() {
		ninjaAnimator.SetBool("isWalking", true);
		yield return new WaitForSeconds(1f);
		ninjaAnimator.SetBool("isWalking", false);
	}
	public void Crouch() {
		StartCoroutine(CrouchAndStand());
	}

	IEnumerator Dance() {
		ninjaAnimator.SetBool("isDancing", true);
		yield return new WaitForSeconds(1f);
		ninjaAnimator.SetBool("isWalking", false);
	}
	public void VictoryWalk() {
		StartCoroutine(Dance());
	}
	
	IEnumerator Attack() {
		ninjaAnimator.SetBool("isAttacking", true);
		yield return new WaitForSeconds(.2f);
		ninjaAnimator.SetBool("isAttacking", false);
	}
	public void Slash() {
		StartCoroutine(Attack());
	}
}
