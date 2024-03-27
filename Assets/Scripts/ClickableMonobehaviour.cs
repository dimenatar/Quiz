using System;
using UnityEngine;

public abstract class ClickableMonobehaviour : MonoBehaviour, IClickable
{
    public event Action<IClickable> Clicked;

    public virtual void Click()
    {
        Clicked?.Invoke(this);
    }
}
