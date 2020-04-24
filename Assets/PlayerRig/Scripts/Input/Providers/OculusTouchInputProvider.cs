using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OculusTouchInputProvider : UnityXRInputProvider,IInputProvider 
{
    public OculusTouchInputProvider()
    {
        this.triggerButtonInput = new CTriggerInput();
        this.button1Input = new CButton1Input();
        this.button2Input = new CButton2Input();
    }

    private class CTriggerInput : IButtonInput
    {
        public bool GetButton()
        {
            if (Input.GetButton("XRI_Right_TriggerButton"))
            {
                Debug.Log("Trigger Button");

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonDown()
        {
            if (Input.GetButtonDown("XRI_Right_TriggerButton"))
            {
                Debug.Log("Trigger Button Down");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonUp()
        {
            if (Input.GetButtonUp("XRI_Right_TriggerButton"))
            {
                Debug.Log("Trigger Button");

                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private class CButton1Input : IButtonInput
    {

        public bool GetButton()
        {
            if (Input.GetButton("XRI_Right_PrimaryButton"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonDown()
        {
            if (Input.GetButtonDown("XRI_Right_PrimaryButton"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonUp()
        {
            if (Input.GetButtonUp("XRI_Right_PrimaryButton"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private class CButton2Input : IButtonInput
    {

        public bool GetButton()
        {
            if (Input.GetButton("XRI_Right_SecondaryButton"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonDown()
        {
            if (Input.GetButtonDown("XRI_Right_SecondaryButton"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonUp()
        {
            if (Input.GetButtonUp("XRI_Right_SecondaryButton"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
