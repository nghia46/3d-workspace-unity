using UnityEngine;
using TMPro;

public class UpdatePoint : MonoBehaviour
{
    [SerializeField] private int collectableId;
    private int _score;
    private TextMeshProUGUI _txtScore;
    private enum scoreType
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
            case (int)scoreType.Increase: _score += 1;
                break;
            case (int)scoreType.Decrease: _score -= 1;
                break;
            case (int)scoreType.X4: _score *= 10;
                break;
        }

        _txtScore.text = _score.ToString();
    }

    private void OnDisable()
    {
        EventManager.Instance.CollectableEvent -= UpdateScore;
    }
}