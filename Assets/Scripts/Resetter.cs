using System;
using System.Collections.Generic;

public class Resetter
{
    private GameplayFlow _gameplayFlow;
    private CellSpawner _cellSpawner;
    private CellClicker _cellClicker;
    private float _delayToResetStage;

    private List<IResettable> _resettables;

    public event Action Resetted;

    public Resetter(GameplayFlow gameplayFlow, CellSpawner cellSpawner, CellClicker cellClicker, float delayToResetStage)
    {
        _gameplayFlow = gameplayFlow;
        _delayToResetStage = delayToResetStage;
        _cellSpawner = cellSpawner;
        _cellClicker = cellClicker;
        _resettables = new List<IResettable>();
    }

    public void AddResettable(IResettable resettable)
    {
        _resettables.Add(resettable);
    }

    public void Reset()
    {
        _cellClicker.SetEnabledState(false);
        for (int i = 0; i < _resettables.Count; i++)
        {
            if (_resettables[i] == null)
            {
                _resettables.RemoveAt(i);
                i--;
            }
            _resettables[i].Reset();
        }
        _cellSpawner.DestroyCells();
        Resetted?.Invoke();
        MonobehaviourExtensions.DODelayed(() =>
        {
            _gameplayFlow.StartGameplayFlow();
        }, _delayToResetStage);
    }
}
