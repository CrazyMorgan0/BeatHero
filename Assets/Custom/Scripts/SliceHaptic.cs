using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceHaptic : MonoBehaviour
{   
    public void Start() {
        var leftHand = new List<UnityEngine.XR.InputDevice>();
        var rightHand = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHand);
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, rightHand);
    }
}
