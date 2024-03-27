using System;
using UnityEngine;

public abstract class CellClicker : ITickable
{
    public bool IsEnabled { get; private set; }

    protected Camera _camera;

    protected CellClicker() { }

    public event Action<IClickable> Clicked;

    public abstract void Tick();

    public void SetCamera(Camera camera)
    {
        _camera = camera;
    }

    public void SetEnabledState(bool isEnabled)
    {
        IsEnabled = isEnabled;
    }

    protected void ManageClick(Vector3 screenPosition)
    {
        if (!IsEnabled) return;

        var ray = _camera.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent(out IClickable clickable))
            {
                this.Print(clickable);
                Clicked?.Invoke(clickable);
            }
        }
    }
}
