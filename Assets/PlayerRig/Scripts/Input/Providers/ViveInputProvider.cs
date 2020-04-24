using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class ViveInputProvider : UnityXRInputProvider,IInputProvider 
{
    public ViveInputProvider()
    {
        this.triggerButtonInput = new CTriggerInput();
        this.button1Input = new CButton1Input();
        this.button2Input = new CButton2Input();
    }

    private class CTriggerInput : IButtonInput
    {
        public bool GetButton()
        {

            bool touched = false;

            if (Input.GetButton("XRI_Right_TriggerButton"))
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
            if (Input.GetButtonDown("XRI_Right_TriggerButton"))
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
            if (Input.GetButtonUp("XRI_Right_TriggerButton"))
            {
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
            if (Input.GetButton("XRI_Right_Primary2DAxisClick"))
            {
                if (Input.GetAxis("XRI_Right_Primary2DAxis_Vertical") < 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonDown()
        {
            if (Input.GetButtonDown("XRI_Right_Primary2DAxisClick"))
            {
                if (Input.GetAxis("XRI_Right_Primary2DAxis_Vertical") < 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonUp()
        {
            if (Input.GetButtonUp("XRI_Right_Primary2DAxisClick"))
            {
                if (Input.GetAxis("XRI_Right_Primary2DAxis_Vertical") < 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
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
            if (Input.GetButton("XRI_Right_Primary2DAxisClick"))
            {
                if (Input.GetAxis("XRI_Right_Primary2DAxis_Vertical") > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonDown()
        {
            if (Input.GetButtonDown("XRI_Right_Primary2DAxisClick"))
            {
                if (Input.GetAxis("XRI_Right_Primary2DAxis_Vertical") > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonUp()
        {
            if (Input.GetButtonUp("XRI_Right_Primary2DAxisClick"))
            {
                if (Input.GetAxis("XRI_Right_Primary2DAxis_Vertical") > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
