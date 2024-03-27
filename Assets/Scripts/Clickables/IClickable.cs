using System;

namespace Clickables
{
    public interface IClickable
    {
        public event Action<IClickable> Clicked;

        public void Click();
    }
}