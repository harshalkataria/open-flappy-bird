using System;

public interface IInputProvider
{
    event Action OnFlapAction;
    void CheckInput();
} 