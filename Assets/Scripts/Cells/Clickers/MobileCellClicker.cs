using UnityEngine;

namespace Cells.Clickers
{
    public class MobileCellClicker : CellClicker
    {
        public override void Tick()
        {
            foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    ManageClick(touch.position);
                }
            }
        }
    }
}