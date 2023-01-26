using UnityEngine.InputSystem;

public class GamepadInputProvider : IInputProvider
{
    public bool InputAhead()
    {
        return Gamepad.current.dpad.up.isPressed;
    }

    public bool InputLeft()
    {
        return Gamepad.current.dpad.left.isPressed;
    }

    public bool InputRight()
    {
        return Gamepad.current.dpad.right.isPressed;
    }
    
    public bool InputBack()
    {
        return Gamepad.current.dpad.down.isPressed;
    }

    public bool InputJump()
    {
        return Gamepad.current.bButton.isPressed;
    }
}