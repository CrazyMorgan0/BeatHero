using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    //Speed the beat comes to the player
    [SerializeField]
    float speed = 2.0f;
    public bool pause = true;

    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Saber") {
            if(this.gameObject.name == "BlueBeat" || this.gameObject.name == "BlueSliced") {
                
            } else if(this.gameObject.name == "DoubleBeat") {
                
            } else if(this.gameObject.name == "DoubleSliced") {

            } else if(this.gameObject.name == "BarBeat") {

            } 
        }
    }

    //Give the player time to hit the cube
    IEnumerator WaitForPlayer() {
        yield return new WaitForSeconds(2f);
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
