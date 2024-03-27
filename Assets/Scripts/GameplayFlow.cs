using Data;
using Scriptables;
using System.Collections.Generic;

public class GameplayFlow
{
    private CellClicker _cellEventsProvider;
    private CellSpawner _cellSpawner;
    private CellAnswerDecider _cellAnswerDecider;
    private List<CellBundle> _cellBundles;

    private int _currentStageIndex;
    private List<StageData> _stageDatas;

    public GameplayFlow(StagesConfig stagesConfig, CellClicker cellEventsProvider, CellSpawner cellSpawner, CellAnswerDecider cellAnswerDecider, List<CellBundle> cellBundles)
    {
        _cellEventsProvider = cellEventsProvider;
        _cellSpawner = cellSpawner;
        _cellAnswerDecider = cellAnswerDecider;
        _cellBundles = cellBundles;

        _stageDatas = stagesConfig.StageDatas;

        _cellEventsProvider.Clicked += OnClicked;
    }

    private void OnClicked(IClickable clickable)
    {
        if (clickable is CellView cellView)
        {
            if (_cellAnswerDecider.IsRightAsnwer(cellView.CellData))
            {
                StartStage(++_currentStageIndex);
            }
            else
            {
                //
            }
        }
    }

    public void StartGameplayFlow()
    {
        StartStage(_currentStageIndex);
    }

    private void StartStage(int stageIndex)
    {
        var stageData = _stageDatas[stageIndex % _stageDatas.Count];
        CellBundle pickedBundle = null;
        for (int i = 0; i < _cellBundles.Count; i++)
        {
            pickedBundle = _cellBundles[i];
            if (_cellAnswerDecider.IsPossibleToPickAnswer(pickedBundle.CellDatas))
            {
                break;
            }
            else if (i == _cellBundles.Count - 1)
            {
                throw new System.Exception("No bundle available");
            }
        }
        var cellData = pickedBundle.CellDatas;
        var cellViews = _cellSpawner.CreateCells(stageData, cellData);
        _cellAnswerDecider.PickRightAnswer(cellData);
    }
}