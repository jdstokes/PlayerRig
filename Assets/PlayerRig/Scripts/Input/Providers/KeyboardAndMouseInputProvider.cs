using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardAndMouseInputProvider : IInputProvider
{
    private IButtonInput triggerButtonInput;
    private IButtonInput button1Input;
    private IButtonInput button2Input;

    public KeyboardAndMouseInputProvider()
    {
        this.triggerButtonInput = new CTriggerButtonInput();
        this.button1Input = new CButton1Input();
        this.button2Input = new CButton2Input();
    }

    public virtual IButtonInput TriggerButtonInput
    {
        get { return this.triggerButtonInput; }
    }

    public virtual IButtonInput Button1Input
    {
        get { return this.button1Input; }
    }

    public virtual IButtonInput Button2Input
    {
        get { return this.button2Input; }
    }

    private class CTriggerButtonInput : IButtonInput
    {
        public bool GetButton()
        {
            return Input.GetKey(KeyCode.Return);
        }

        public bool GetButtonDown()
        {
            return Input.GetKeyDown(KeyCode.Return);
        }

        public bool GetButtonUp()
        {
            return Input.GetKeyUp(KeyCode.Return);
        }
    }

    private class CButton1Input : IButtonInput
    {
        public bool GetButton()
        {
            return Input.GetMouseButton(0);
        }

        public bool GetButtonDown()
        {
            return Input.GetMouseButtonDown(0);
        }

        public bool GetButtonUp()
        {
            return Input.GetMouseButtonUp(0);
        }
    }

    private class CButton2Input : IButtonInput
    {
        public bool GetButton()
        {
            return Input.GetMouseButton(1);
        }

        public bool GetButtonDown()
        {
            return Input.GetMouseButtonDown(1);
        }

        public bool GetButtonUp()
        {
            return Input.GetMouseButtonUp(1);
        }
    }
}
