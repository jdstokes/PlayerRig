using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocomotion : MonoBehaviour
{
    public bool isLeftHand;
    private string trackpadX;
    private string trackpadY;


    private Vector2 trackpad;

    private Vector3 playerForward;
    private Vector3 playerRight;


    public Transform vrRig;
    public Transform director;



    void Start()
    {
        if (!isLeftHand)
        {
            trackpadX = "Left Trackpad X";
            trackpadX = "Left Trackpad X";
        }
        else
        {
            trackpadX = "Right Trackpad X";
            trackpadX = "Right Trackpad Y";
        }


    }

    // Update is called once per frame
    void Update()
    {
        trackpad = new Vector2(Input.GetAxis(trackpadX), Input.GetAxis(trackpadY));

        if (trackpad.magnitude < 0.2f)
        {
            trackpad = Vector2.zero;
        }

        playerForward = director.forward;
        playerForward.y = 0;
        playerForward.Normalize();
        playerRight = director.right;
        playerRight.y = 0;
        playerRight.Normalize();

        vrRig.Translate(playerForward * trackpad.y * Time.deltaTime);
        vrRig.Translate(playerRight * trackpad.x * Time.deltaTime);
    }
}
