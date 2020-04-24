using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class Teleport : MonoBehaviour
{
    //public LineRenderer myLine;
    //private Vector3 hitPoint;
    //private bool shouldTeleport;

    //void Update()
    //{
    //    if (XRInput.Instance.GetInput(InputType.ShootLaser))
    //    {
    //        RaycastHit hit;
    //        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
    //        {
    //            hitPoint = hit.point;
    //            myLine.SetPosition(0,transform.position);
    //            myLine.SetPosition(1, hitPoint);
    //            myLine.enabled = true;
    //            shouldTeleport = true;

    //        }
    //        else
    //        {
    //            shouldTeleport = false;
    //            myLine.enabled = false;
    //        }
    //    }
    //    else if (!XRInput.Instance.GetInput(InputType.ShootLaser))
    //    {
    //        myLine.enabled = false;
    //        if (shouldTeleport)
    //        {
    //            shouldTeleport = false;

    //        }
    //    }
    //}


}
