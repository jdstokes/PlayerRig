using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRSettings : MonoBehaviour
{
    public bool isVROn;
    void Awake()
    {
        XRSettings.enabled = isVROn;
    }

}
