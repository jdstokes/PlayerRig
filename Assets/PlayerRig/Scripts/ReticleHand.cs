using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleHand : MonoBehaviour
{
    public float m_DefaultDistance = 5f;      
    public bool m_UseNormal;          
    public Image m_Image;            
    public Transform m_ReticleTransform;
    public Transform m_Camera;
    public Transform ReticleTransform { get { return m_ReticleTransform; } }

    private Vector3 m_OriginalScale;                           
    private Quaternion m_OriginalRotation;                     

    public bool UseNormal
    {
        get { return m_UseNormal; }
        set { m_UseNormal = value; }
    }

    private void Awake()
    {
        // Store the original scale and rotation.
        m_OriginalScale = m_ReticleTransform.localScale;
        m_OriginalRotation = m_ReticleTransform.localRotation;
    }


    public void Hide()
    {
       m_Image.enabled = false;
    }


    public void Show()
    {
        m_Image.enabled = true;
    }

    public void SetPosition(RaycastHit hit)
    {
        m_ReticleTransform.position = hit.point;

        // If the reticle should use the normal of what has been hit...
        if (m_UseNormal)
            // ... set it's rotation based on it's forward vector facing along the normal.
            m_ReticleTransform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
        else
            // However if it isn't using the normal then it's local rotation should be as it was originally.
            //m_ReticleTransform.localRotation = m_OriginalRotation;
            m_ReticleTransform.localRotation = m_Camera.localRotation;

    }
}
