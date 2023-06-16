using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    //Speed the beat comes to the player
    [SerializeField]
    float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        //Use the forward direction of the beat until in front of the player
        transform.position += Time.deltaTime * transform.forward * speed;
    }
}
