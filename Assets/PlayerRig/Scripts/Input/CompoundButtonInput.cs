using System;

public class CompoundButtonInput : IButtonInput
{
    private IButtonInput[] buttonInputs;
    private int lastPressedIndex;

    public CompoundButtonInput() { }

    public CompoundButtonInput(params IButtonInput[] buttonInputs)
    {
        this.buttonInputs = buttonInputs;
    }

    public virtual bool GetButton()
    {
        if (this.buttonInputs != null)
        {
            for (int i = 0; i < this.buttonInputs.Length; i++)
            {
                if (this.buttonInputs[i].GetButton())
                {
                    this.lastPressedIndex = i;
                    return true;
                }
            }
        }

        return false;
    }

    public virtual bool GetButtonDown()
    {
        if (this.buttonInputs != null)
        {
            for (int i = 0; i < this.buttonInputs.Length; i++)
            {
                if (this.buttonInputs[i].GetButtonDown())
                {
                    this.lastPressedIndex = i;
                    return true;
                }
            }
        }

        return false;
    }

    public virtual bool GetButtonUp()
    {
        if (this.buttonInputs != null)
        {
            for (int i = 0; i < this.buttonInputs.Length; i++)
            {
                if (this.buttonInputs[i].GetButtonUp())
                {
                    this.lastPressedIndex = i;
                    return true;
                }
            }
        }

        return false;
    }

    public IButtonInput GetLastPressed()
    {
        return this.buttonInputs[this.lastPressedIndex];
    }

    public void AddButtonInput(IButtonInput buttonInput)
    {
        if (this.buttonInputs == null)
        {
            this.buttonInputs = new IButtonInput[1];
            this.buttonInputs[0] = buttonInput;
        }
        else
        {
            System.Array.Resize(ref this.buttonInputs, this.buttonInputs.Length + 1);
            this.buttonInputs[this.buttonInputs.Length - 1] = buttonInput;
        }
    }

    public void ClearButtonInputs()
    {
        this.buttonInputs = null;
    }
}