using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedBeat : MonoBehaviour
{
    private Rigidbody rb;

    //Give the player time to slice the cube repeatedly
    IEnumerator WaitForPlayer() {
        yield return new WaitForSeconds(1f);
        //Slices all fall
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(WaitForPlayer());
        //Cull sliced cubes to avoid frame drops
        Destroy(gameObject, 15f);
    }
}
