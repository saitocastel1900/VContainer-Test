using UnityEngine.InputSystem;

public class KeyInputProvider : IInputProvider
{
    public bool InputAhead()
    {
        return Keyboard.current.wKey.isPressed;
    }

    public bool InputLeft()
    {
        return Keyboard.current.aKey.isPressed;
    }

    public bool InputRight()
    {
        return Keyboard.current.dKey.isPressed;
    }

    public bool InputBack()
    {
        return Keyboard.current.sKey.isPressed;
    }

    public bool InputJump()
    {
        return Keyboard.current.spaceKey.isPressed;
    }
}
