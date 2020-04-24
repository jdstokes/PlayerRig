using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputManager : MonoBehaviour
{
    private void Awake()
    {
        InitInputProviders();
    }

    private void InitInputProviders()
    {
        CompoundInputProvider compoundInputProvider = new CompoundInputProvider();
        compoundInputProvider.AddInputProvider(new OculusTouchInputProvider());
        //compoundInputProvider.AddInputProvider(new UnityXRInputProvider());

        PlayerInput.InputProvider = compoundInputProvider;
        compoundInputProvider.AddInputProvider(new KeyboardAndMouseInputProvider());
        PlayerInput.InputProvider = compoundInputProvider;
    }
}
