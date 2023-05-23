using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapSaber : MonoBehaviour
{
    public Transform controllerTransform;

    public void GrabTransform() {
        //Find controller that picked up saber
        controllerTransform = this.transform.parent;
    }
}
