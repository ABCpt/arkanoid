using Core.Level.Model;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Views
{
    public class LevelNumberView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelNumber;

        private LevelModel _levelModel;

        [Inject]
        public void Construct(LevelModel levelModel)
        {
            _levelModel = levelModel;
            _levelModel.UpdateLevel += OnUpdateLevel;
            OnUpdateLevel();
        }

        private void OnUpdateLevel()
        {
            _levelNumber.text = (_levelModel.LevelNumber + 1).ToString();
        }

        private void OnDestroy()
        {
            _levelModel.UpdateLevel -= OnUpdateLevel;
        }
    }
}