using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLaser : MonoBehaviour
{
    public LayerMask layerMask;
    public ReticleHand reticle;

    private LineRenderer laser;
    private float defaultDistance = 1f;
    private float defaultLength = 0.4f;
    private bool changeDistanceOnCollide = true;

    private void Awake()
    {
        laser = GetComponent<LineRenderer>();
    }
    private void Update()
    {
       RaycastHit hit;
   
        if (changeDistanceOnCollide && Physics.Raycast(transform.position, transform.forward, out hit,10, layerMask))
        {
            if (hit.collider)
            {
                Vector3 hitPoint = hit.point;
                Vector3 startPoint = hitPoint;
                laser.SetPosition(0, transform.position);
                laser.SetPosition(1, hitPoint);
                reticle.Show();
                reticle.SetPosition(hit);
//                Debug.Log("collider hit");
            }
            else
            {
                laser.SetPosition(0, transform.position);
                laser.SetPosition(1, transform.forward* defaultDistance);
                reticle.Hide();
            }
        }
        else
        {
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, transform.position + (transform.forward * defaultDistance));
            reticle.Hide();
        }

    }


}
