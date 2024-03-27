using Cells;
using Cells.Clickers;
using Clickables;
using Data;
using Scriptables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Global
{
    public class GameplayFlow
    {
        private CellClicker _cellClicker;
        private CellSpawner _cellSpawner;
        private CellAnswerDecider _cellAnswerDecider;
        private CellParticles _cellParticles;
        private List<CellBundle> _cellBundles;

        private int _currentStageIndex;
        private List<StageData> _stageDatas;

        public event Action CompeltedAllStages;

        public GameplayFlow(StagesConfig stagesConfig, CellClicker cellClicker, CellSpawner cellSpawner, CellAnswerDecider cellAnswerDecider, List<CellBundle> cellBundles, CellParticles cellParticles)
        {
            _cellClicker = cellClicker;
            _cellSpawner = cellSpawner;
            _cellAnswerDecider = cellAnswerDecider;
            _cellBundles = cellBundles;

            _cellParticles = cellParticles;
            _stageDatas = stagesConfig.StageDatas;

            _cellClicker.Clicked += OnClicked;
        }

        private void OnClicked(IClickable clickable)
        {
            if (clickable is CellView cellView)
            {
                cellView.PlayBounceAnimation();
                if (_cellAnswerDecider.IsRightAsnwer(cellView.CellData))
                {
                    _cellParticles.PlayCorrectParticles(cellView);

                    if (++_currentStageIndex < _stageDatas.Count)
                    {
                        _cellSpawner.DestroyCells();
                        StartStage(_currentStageIndex);
                    }
                    else
                    {
                        CompeltedAllStages?.Invoke();
                    }
                }
            }
        }

        public void StartGameplayFlow()
        {
            _cellClicker.SetEnabledState(true);
            _currentStageIndex = 0;
            StartStage(_currentStageIndex);
        }

        private void StartStage(int stageIndex)
        {
            var stageData = _stageDatas[stageIndex % _stageDatas.Count];
            CellBundle pickedBundle = PickBundle();

            var cellDatas = pickedBundle.CellDatas;
            var rightAnswer = _cellAnswerDecider.PickRightAnswer(cellDatas);


            var randomCells = cellDatas.TakeRandom(stageData.ColumnCount.Sum() - 1).ToList();
            if (randomCells.Contains(rightAnswer))
            {
                randomCells.Add(cellDatas.GetRandom(cellData => !randomCells.Contains(cellData)));
            }
            else
            {
                randomCells.Add(rightAnswer);
            }

            var cellViews = _cellSpawner.CreateCells(stageData, randomCells);
        }

        private CellBundle PickBundle()
        {
            CellBundle pickedBundle = null;

            List<CellBundle> availableCellBundles = new List<CellBundle>(_cellBundles);
            bool isPickedBundle = false;

            while (availableCellBundles.Count > 0)
            {
                var randomBundle = availableCellBundles.GetRandom();
                if (_cellAnswerDecider.IsPossibleToPickAnswer(randomBundle.CellDatas))
                {
                    pickedBundle = randomBundle;
                    isPickedBundle = true;
                    break;
                }
                availableCellBundles.Remove(randomBundle);
            }

            if (!isPickedBundle)
            {
                this.PrintWarning($"No data bundles are available. Clearing recorded right answers");
                _cellAnswerDecider.ClearRightAnswers();
                pickedBundle = _cellBundles.GetRandom();
            }

            return pickedBundle;
        }
    }
}