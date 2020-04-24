using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleport : MonoBehaviour
{
    public bool isLeftHand;
    private string trackPadPress;


    private LineRenderer myline;
    private bool shouldTeleport;
    private Vector3 hitPoint;

    public Transform VRPlayer;

    private void Start()
    {
        if (isLeftHand)
        {
            trackPadPress = "Left Trackpad Press";
        }
        else
        {
            trackPadPress = "Right Trackpad Press";
        }

        myline = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetButton(trackPadPress))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,transform.forward,out hit, 100))
            {
                hitPoint = hit.point;
                myline.SetPosition(0, transform.position);
                myline.enabled = true;
                shouldTeleport = true;
            }
            else
            {
                shouldTeleport = false;
                myline.enabled = false;
            }
        }
        else if (Input.GetButtonUp(trackPadPress))
        {
            myline.enabled = false;
            if (shouldTeleport)
            {
                VRPlayer.position = hitPoint;
            }
        }
    }
}
