using System;

public class CompoundInputProvider : IInputProvider
{
    private IInputProvider[] inputProviders;

    private CompoundButtonInput triggerButtonInput;
    private CompoundButtonInput button1Input;
    private CompoundButtonInput button2Input;

    public CompoundInputProvider()
        : this(null)
    { }

    public CompoundInputProvider(params IInputProvider[] inputProviders)
    {
        this.triggerButtonInput = new CompoundButtonInput();
        this.button1Input = new CompoundButtonInput();
        this.button2Input = new CompoundButtonInput();

        if (inputProviders != null)
        {
            for (int i = 0; i < inputProviders.Length; i++)
            {
                this.AddInputProvider(inputProviders[i]);
            }
        }
    }

    public virtual IButtonInput TriggerButtonInput
    {
        get
        {
            return this.triggerButtonInput;
        }
    }

    public virtual IButtonInput Button1Input
    {
        get
        {
            return this.button1Input;
        }
    }

    public virtual IButtonInput Button2Input
    {
        get
        {
            return this.button2Input;
        }
    }

    public void AddInputProvider(IInputProvider inputProvider)
    {
        if (this.inputProviders == null)
        {
            this.inputProviders = new IInputProvider[1];
            this.inputProviders[0] = inputProvider;
        }
        else
        {
            Array.Resize(ref this.inputProviders, this.inputProviders.Length + 1);
            this.inputProviders[this.inputProviders.Length - 1] = inputProvider;
        }

        this.triggerButtonInput.AddButtonInput(inputProvider.TriggerButtonInput);
        this.button1Input.AddButtonInput(inputProvider.Button1Input);
        this.button2Input.AddButtonInput(inputProvider.Button2Input);

    }

    public void ClearInputProviders()
    {
        this.inputProviders = null;

        this.triggerButtonInput.ClearButtonInputs();
        this.button1Input.ClearButtonInputs();
        this.button2Input.ClearButtonInputs();

    }
}