using System;
using UnityEngine.InputSystem;

public class KeyboardInputProvider : IInputProvider
{
    public event Action OnFlapAction;
    
    public void CheckInput()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            OnFlapAction?.Invoke();
        }
    }
} 