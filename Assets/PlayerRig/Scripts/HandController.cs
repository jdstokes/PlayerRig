using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum HandTool {Net,Controller,Pointer,None}

public class HandController : MonoBehaviour
{
    [Header("Hand Tools")]
    public GameObject pointer;
    public GameObject net;
    public GameObject controller;
    private List<GameObject> _toolList= new List<GameObject>();

    private void Awake()
    {
        _toolList.AddRange(new List<GameObject>() { pointer, net, controller });
    }

    public void EnableHandTool(HandTool tool)
    {
        StartCoroutine(EnableHandToolCo(tool));
    }

    public IEnumerator EnableHandToolCo(HandTool tool)
    {
       yield return StartCoroutine(DeactivateTools());

        switch (tool)
        {
            case HandTool.Net:
                net.SetActive(true);
                break;
            case HandTool.Controller:
                controller.SetActive(true);
                break;
            case HandTool.Pointer:
                pointer.SetActive(true);
                break;
            case HandTool.None:
                break;
        }
    }
    
    IEnumerator DeactivateTools()
    {
        foreach(var tool in _toolList)
        {
            tool.SetActive(false);
        }
        yield return null;
    }
}
