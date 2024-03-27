using System;
using UnityEngine;

namespace Clickables
{
    public abstract class ClickableMonobehaviour : MonoBehaviour, IClickable
    {
        public event Action<IClickable> Clicked;

        public virtual void Click()
        {
            Clicked?.Invoke(this);
        }
    }
}