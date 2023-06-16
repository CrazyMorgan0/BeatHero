using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    //Speed the beat comes to the player
    [SerializeField]
    float speed = 2.0f;
    public bool pause = true;
    
    IEnumerator WaitForPlayer() {
        yield return new WaitForSeconds(0.5f);
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Use the forward direction of the beat until in front of the player
        if(transform.localPosition.z < 14) {
            transform.position += Time.deltaTime * transform.forward * speed;
        } else if (pause) {
            StartCoroutine(WaitForPlayer());
        } else {
            //Cube hasn't been sliced, continue to killzone
            transform.position += Time.deltaTime * transform.forward * speed;
        }
    }
}
