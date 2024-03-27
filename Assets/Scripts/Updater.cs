using System.Collections.Generic;
using UnityEngine;

public abstract class Updater : MonoBehaviour
{
    private List<ITickable> _tickables;

    public void Initialise()
    {
        _tickables = new List<ITickable>();
    }

    public void AddTickable(ITickable tickable)
    {
        _tickables.Add(tickable);
    }

    public void AddTickables(IEnumerable<ITickable> tickables)
    {
        _tickables.AddRange(tickables);
    }

    protected void InvokeTickables()
    {
        _tickables.ForEach(tickable => tickable.Tick());
    }
}
