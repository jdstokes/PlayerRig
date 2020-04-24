using UnityEngine;
using UnityEngine.XR;

public abstract class UnityXRInputProvider : IInputProvider
{
    public IButtonInput triggerButtonInput;
    public IButtonInput button1Input;
    public IButtonInput button2Input;

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
}
