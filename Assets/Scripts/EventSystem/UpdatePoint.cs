using TMPro;
using Tools;
using UnityEngine;
namespace EventSystem
{
    public class UpdatePoint : MonoBehaviour
    {
        [SerializeField] private int collectableId;
        [SerializeField]public int Score { get;private set; }
        private TextMeshProUGUI _txtScore;
        private enum ScoreType
        {
            Increase,
            Decrease,
            X4
        }

        private void Awake()
        {
            _txtScore = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _txtScore.text = $"<color=Yellow>Score</color>: {Score}";
            EventManager.Instance.CollectableEvent += UpdateScore;
        }
    
        private void UpdateScore(int triggerId)
        {
            switch (triggerId)
            {
                case (int)ScoreType.Increase: Score += 1;
                    break;
                case (int)ScoreType.Decrease: Score -= 1;
                    break;
                case (int)ScoreType.X4: Score *= 4;
                    break;
                default:
                    CustomTools.Log($"Unexpected triggerId: {triggerId}", CustomTools.LogColor.Red);
                    break;
            }

            CustomTools.Log(Score,CustomTools.LogColor.Yellow);
            _txtScore.text = $"<color=Yellow>Score</color>: {Score}";
        }

        private void OnDisable()
        {
            EventManager.Instance.CollectableEvent -= UpdateScore;
        }
    }
}