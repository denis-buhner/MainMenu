using System;

public interface ICanChangeButton
{
    public event Action<bool> ButtonState;
}
