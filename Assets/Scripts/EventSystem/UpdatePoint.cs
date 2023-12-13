using TMPro;
using Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace EventSystem
{
    public class UpdatePoint : MonoBehaviour
    {
        [SerializeField] private int collectableId;
        [SerializeField]public int score;
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
                case (int)ScoreType.Increase: score += 1;
                    break;
                case (int)ScoreType.Decrease: score -= 1;
                    break;
                case (int)ScoreType.X4: score *= 4;
                    break;
                default:
                    CustomTools.Log($"Unexpected triggerId: {triggerId}", CustomTools.LogColor.Red);
                    break;
            }

            CustomTools.Log(score,CustomTools.LogColor.Yellow);
            _txtScore.text = score.ToString();
        }

        private void OnDisable()
        {
            EventManager.Instance.CollectableEvent -= UpdateScore;
        }
    }
}