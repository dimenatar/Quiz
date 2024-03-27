using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private GameplayFlow _gameplayFlow;
    private Resetter _resetter;

    [Inject]
    private void Construct(GameplayFlow gameplayFlow, Resetter resetter)
    {
        _gameplayFlow = gameplayFlow;
        _resetter = resetter;
    }

    private void Awake()
    {
        _gameplayFlow.CompeltedAllStages += OnCompletedAllStages;
        _button.onClick.AddListener(ButtonClick);
    }

    private void Start()
    {
        gameObject.Disable();
    }

    private void OnDestroy()
    {
        _gameplayFlow.CompeltedAllStages -= OnCompletedAllStages;
    }

    private void ButtonClick()
    {
        gameObject.Disable();
        _resetter.Reset();
    }

    private void OnCompletedAllStages()
    {
        transform.ScaleIn();
    }
}
