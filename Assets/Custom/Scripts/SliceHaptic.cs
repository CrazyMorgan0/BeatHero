using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SliceHaptic : MonoBehaviour
{   
    public GameObject leftHand;
    public GameObject rightHand;
    private XRController leftController;
    private XRController rightController;

    public void Start() {
        leftController = GetComponent<XRController>();
        rightController = GetComponent<XRController>();
    }

    public void LeftHapticOnScore(int score) {
        leftController.SendHapticImpulse((float)score / 500, (float)score / 1000);
    }

    public void RightHapticOnScore(int score) {
        rightController.SendHapticImpulse((float)score / 500, (float)score / 1000);
    }
}
