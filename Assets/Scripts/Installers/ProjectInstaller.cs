using Cells;
using Cells.Clickers;
using Global;
using Resetters;
using Scriptables;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private List<CellBundle> _cellBundles;
        [SerializeField] private StagesConfig _stagesConfig;
        [SerializeField] private CellView _cellView;

        [SerializeField] private ParticleSystem _rightAnswerParticles;

        [SerializeField] private float _delayToResetStage = 0.5f;
        [SerializeField] private float _spacing = 0f;

        public override void InstallBindings()
        {


#if UNITY_ANDROID && !UNITY_EDITOR
        CellClicker cellClicker = new MobileCellClicker();
#elif UNITY_EDITOR
            CellClicker cellClicker = new MouseCellClicker();
#endif
            CellAnswerDecider cellAnswerDecider = new CellAnswerDecider();
            CellSpawner cellSpawner = new CellSpawner(_cellView, _spacing);
            CellParticles cellParticles = new CellParticles(_rightAnswerParticles);

            GameplayFlow gameplayFlow = new GameplayFlow(_stagesConfig, cellClicker, cellSpawner, cellAnswerDecider, _cellBundles, cellParticles);
            Resetter resetter = new Resetter(gameplayFlow, cellSpawner, cellClicker, _delayToResetStage);

            resetter.AddResettable(cellSpawner);

            Container.Bind<CellClicker>().FromInstance(cellClicker).AsSingle();
            Container.Bind<CellAnswerDecider>().FromInstance(cellAnswerDecider).AsSingle();
            Container.Bind<CellSpawner>().FromInstance(cellSpawner).AsSingle();
            Container.Bind<CellParticles>().FromInstance(cellParticles).AsSingle();
            Container.Bind<GameplayFlow>().FromInstance(gameplayFlow).AsSingle();
            Container.Bind<Resetter>().FromInstance(resetter).AsSingle();
        }
    }
}