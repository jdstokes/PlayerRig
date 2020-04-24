public static class PlayerInput
{
    public static IInputProvider InputProvider { get; set; }

    public static IButtonInput TriggerButtonInput
    {
        get
        {
            return InputProvider.TriggerButtonInput;
        }
    }

    public static IButtonInput Button1Input
    {
        get
        {
            return InputProvider.Button1Input;
        }
    }

    public static IButtonInput Button2Input
    {
        get
        {
            return InputProvider.Button2Input;
        }
    }
}
