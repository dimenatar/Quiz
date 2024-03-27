using Cells;
using Cells.Clickers;
using Global;
using Resetters;
using UI;
using UnityEngine;
using Updaters;
using Zenject;

namespace Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform _cellParent;
        [SerializeField] private Updater _updater;
        [SerializeField] private Hint _hint;

        private GameplayFlow _gameplayFlow;

        [Inject]
        private void Construct(CellSpawner cellSpawner, CellClicker cellClicker, GameplayFlow gameplayFlow, Resetter resetter)
        {
            _updater.Initialise();
            _updater.AddTickable(cellClicker);

            cellClicker.SetCamera(Camera.main);
            cellSpawner.SetCellParent(_cellParent);

            resetter.AddResettable(_hint);

            _gameplayFlow = gameplayFlow;
        }

        public override void InstallBindings()
        {
            _gameplayFlow.StartGameplayFlow();
        }
    }
}