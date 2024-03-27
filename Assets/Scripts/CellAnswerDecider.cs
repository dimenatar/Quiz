using System;
using System.Collections.Generic;

public class CellAnswerDecider
{
    private CellData _rightAnswer;
    private List<string> _pastRightAnswers;

    public string RightAnswerID => _rightAnswer.ID;

    public event Action<CellData> RightAnswerPicked;

    public CellAnswerDecider()
    {
        _pastRightAnswers = new List<string>();
    }

    public bool IsPossibleToPickAnswer(List<CellData> cellDatas)
    {
        bool isPossibleToPick = false;
        foreach (var cellData in cellDatas)
        {
            if (!_pastRightAnswers.Contains(cellData.ID))
            {
                isPossibleToPick = true;
            }
        }
        return isPossibleToPick;
    }

    public CellData PickRightAnswer(List<CellData> cellDatas)
    {
        _rightAnswer = cellDatas.GetRandom(cellData => !_pastRightAnswers.Contains(cellData.ID));
        if (_rightAnswer == null)
        {
            throw new System.Exception("Not possible to pick answer!");
        }
        _pastRightAnswers.Add(_rightAnswer.ID);

        this.Print($"picked right answer: {_rightAnswer.ID}");
        RightAnswerPicked?.Invoke(_rightAnswer);
        return _rightAnswer;
    }

    public bool IsRightAsnwer(CellData cellData)
    {
        return cellData.ID == _rightAnswer.ID;
    }

    public void ClearRightAnswers()
    {
        _pastRightAnswers.Clear();
    }
}
