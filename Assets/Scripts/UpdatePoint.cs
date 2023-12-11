using UnityEngine;
using TMPro;

public class UpdatePoint : MonoBehaviour
{
    
    private int _score;
    private TextMeshProUGUI _txtScore;
    private void Start()
    {
        _txtScore = GetComponent<TextMeshProUGUI>();
        EventManager.Instance.CollectableEvent += UpdateScore;
    }

    private void UpdateScore(bool isDecreaseTrigger)
    {
        if (!isDecreaseTrigger)
        {
            _score += 1;
            _txtScore.text = _score.ToString();
        }
        else
        {
            _score -= 1;
            _txtScore.text = _score.ToString();
        }
    }

    private void OnDisable()
    {
        EventManager.Instance.CollectableEvent -= UpdateScore;
    }
}