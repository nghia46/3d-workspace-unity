using UnityEngine;
using TMPro;
using Tools;

public class UpdatePoint : MonoBehaviour
{
    [SerializeField] private int collectableId;
    private int _score;
    private TextMeshProUGUI _txtScore;
    private enum ScoreType
    {
        Increase,
        Decrease,
        X4
    }
    private void Start()
    {
        _txtScore = GetComponent<TextMeshProUGUI>();
        EventManager.Instance.CollectableEvent += UpdateScore;
    }
    
    private void UpdateScore(int triggerId)
    {
        switch (triggerId)
        {
            case (int)ScoreType.Increase: _score += 1;
                break;
            case (int)ScoreType.Decrease: _score -= 1;
                break;
            case (int)ScoreType.X4: _score *= 4;
                break;
            default:
                CustomTools.Log($"Unexpected triggerId: {triggerId}", CustomTools.LogColor.Red);
                break;
        }

        CustomTools.Log(_score,CustomTools.LogColor.Yellow);
        _txtScore.text = _score.ToString();
    }

    private void OnDisable()
    {
        EventManager.Instance.CollectableEvent -= UpdateScore;
    }
}