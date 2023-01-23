using UnityEngine;

public class KeyInputProvider : IInputProvider
{
    public bool InputLeft()
    {
        return Input.GetKeyDown(KeyCode.A);
    }

    public bool InputRight()
    {
        return Input.GetKeyDown(KeyCode.D);
    }
    
    public bool InputAhead()
    {
        return Input.GetKeyDown(KeyCode.W);
    }

    public bool InputBack()
    {
        return Input.GetKeyDown(KeyCode.S);
    }

    public bool InputJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
