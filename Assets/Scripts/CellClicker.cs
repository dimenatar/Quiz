using System;
using UnityEngine;

public abstract class CellClicker : ITickable
{
    protected Camera _camera;

    protected CellClicker()
    {
        _camera = Camera.main;
    }

    public event Action<IClickable> Clicked;

    public abstract void Tick();

    protected void ManageClick(Vector3 screenMousePosition)
    {
        var ray = _camera.ScreenPointToRay(screenMousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent(out IClickable clickable))
            {
                Clicked?.Invoke(clickable);
            }
        }
    }
}
