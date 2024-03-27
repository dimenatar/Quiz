using UnityEngine;
using Zenject;

namespace Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform _cellParent;
        [SerializeField] private Updater _updater;

        private GameplayFlow _gameplayFlow;

        [Inject]
        private void Construct(CellSpawner cellSpawner, CellClicker cellClicker, GameplayFlow gameplayFlow)
        {
            _updater.Initialise();
            _updater.AddTickable(cellClicker);

            cellSpawner.SetCellParent(_cellParent);

            _gameplayFlow = gameplayFlow;
        }

        public override void InstallBindings()
        {
            _gameplayFlow.StartGameplayFlow();
        }
    }
}