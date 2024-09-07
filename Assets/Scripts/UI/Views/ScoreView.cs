using Core.Level.Model;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Views
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score;

        private LevelModel _levelModel;

        [Inject]
        public void Construct(LevelModel levelModel)
        {
            _levelModel = levelModel;
            _levelModel.UpdateScore += OnUpdateScore;
            OnUpdateScore();
        }

        private void OnUpdateScore()
        {
            _score.text = _levelModel.Score.ToString();
        }

        private void OnDestroy()
        {
            _levelModel.UpdateScore -= OnUpdateScore;
        }
    }
}