using UnityEngine;

public class MouseCellClicker : CellClicker
{
    public override void Tick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ManageClick(Input.mousePosition);
        }
    }
}
