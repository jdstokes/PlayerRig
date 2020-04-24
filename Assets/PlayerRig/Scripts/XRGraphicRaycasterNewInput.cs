using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class XRGraphicRaycasterNewInput : MonoBehaviour
{
    public GameObject laserPointer;
    private LayerMask layerMask;

    public List<Behaviour> disableOnUIBehaviour = new List<Behaviour>();

    public GameObject pointerEnterObject;
    public GameObject pointerDownObject;

    public bool isPressed;

    private void Start()
    {
        layerMask = LayerMask.GetMask("UI");
    }

    void LateUpdate()
    {
        HandleEnterAndExit();

        if (PlayerInput.TriggerButtonInput.GetButtonDown())
        {
            OnPressStart();
        }

        if (PlayerInput.TriggerButtonInput.GetButton())
        {

            OnPressEnter();
        }

        if (PlayerInput.TriggerButtonInput.GetButtonUp())
        {
            OnPressEnd();
        }
    }

    void HandleEnterAndExit()
    {
        if (Physics.Raycast(laserPointer.transform.position, laserPointer.transform.forward, 
            out RaycastHit hit, 100, layerMask))
        {
            GraphicRaycaster graphicRaycaster = hit.collider.GetComponentInParent<GraphicRaycaster>();
            if (graphicRaycaster != null)
            {
               // laserPointer.SetActive(true);
                SetObjectsActive(false);

                Vector3 screenPoint = Camera.main.WorldToScreenPoint(hit.point);
                PointerEventData eventData = new PointerEventData(EventSystem.current);
                eventData.position = screenPoint;
                List<RaycastResult> list = new List<RaycastResult>();
                graphicRaycaster.Raycast(eventData, list);
                if (list.Count > 0)
                {
                    foreach (var target in list)
                    {
                        if (pointerEnterObject == target.gameObject)
                        {
  
                            break;
                        }
                        var pointer = new PointerEventData(EventSystem.current);
                        if (ExecuteEvents.Execute(target.gameObject, pointer, ExecuteEvents.pointerEnterHandler))
                        {
                            ClearFocus();
                            pointerEnterObject = target.gameObject;
                            break;
                        }
                    }
                    return;
                }
            }

        }

        ClearFocus();
        SetObjectsActive(true);
    }

    void OnPressStart()
    {
        if (pointerEnterObject)
        {
            pointerDownObject = pointerEnterObject;
            Debug.Log(pointerDownObject.name);

            var pointer = new PointerEventData(EventSystem.current);

            if (ExecuteEvents.Execute(pointerDownObject, pointer, ExecuteEvents.pointerDownHandler))
            {
            }
        }

        // Immediately deselect button
        //EventSystem.current.SetSelectedGameObject(null);
    }

    void OnPressEnter()
    {
        if (pointerEnterObject)
        {
            pointerDownObject = pointerEnterObject;

            var pointer = new PointerEventData(EventSystem.current);

            if (ExecuteEvents.Execute(pointerDownObject, pointer, ExecuteEvents.pointerEnterHandler))
            {
            }
        }
    }

    void OnPressEnd()
    {
        var pointer = new PointerEventData(EventSystem.current);
        if (ExecuteEvents.Execute(pointerDownObject, pointer, ExecuteEvents.pointerUpHandler))
        {
        }
        if (pointerDownObject == pointerEnterObject)
        {
            if (ExecuteEvents.Execute(pointerDownObject, pointer, ExecuteEvents.pointerClickHandler))
            {
            }
        }
        pointerDownObject = null;
        EventSystem.current.SetSelectedGameObject(null);
    }

    void ClearFocus()
    {
        if (!pointerEnterObject)
        {
            return;
        }

        var pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(pointerEnterObject, pointer, ExecuteEvents.pointerExitHandler);
        pointerEnterObject = null;
    }

    void SetObjectsActive(bool active)
    {
        foreach (var behaviour in disableOnUIBehaviour)
        {
            behaviour.enabled = active;
        }
    }
}