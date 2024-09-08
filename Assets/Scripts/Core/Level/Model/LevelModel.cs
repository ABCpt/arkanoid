using System;
using Core.Bricks.Data;
using Core.Data;
using Core.Level.Data;
using Core.Level.Interface;

namespace Core.Level.Model
{
    public class LevelModel : ILevelStartable
    {
        public event Action LevelCompleted = delegate { };
        public event Action UpdateScore = delegate { };
        public event Action UpdateLevel = delegate { };
        
        private bool _isLevelCompleted => _destroyedBrickCount >= _maxBricks;
        public bool Pause { get; private set; }

        public LevelGrid LevelGrid;
        public float Score => _destroyedBrickCount * _levelConfig.BrickScore;
        public int LevelNumber;

        private readonly LevelConfig _levelConfig;

        private int _maxBricks;
        private int _destroyedBrickCount;

        public LevelModel(GameSettings gameSettings)
        {
            _levelConfig = gameSettings.LevelConfig;
        }

        public void DestroyBrick()
        {
            _destroyedBrickCount++;

            UpdateScore?.Invoke();
            
            if (_isLevelCompleted)
                LevelCompleted?.Invoke();
        }

        public void StartLevel()
        {
            SetPause(true);
            
            _destroyedBrickCount = 0;

            LevelGrid = _levelConfig.Levels[LevelNumber].GetLevelGrid();
            _maxBricks = 0;
            
            foreach (var bricksRow in LevelGrid.BricksArray)
            {
                foreach (var brickType in bricksRow)
                {
                    if (brickType != BrickType.Null)
                        _maxBricks++;
                }
            }
            
            UpdateLevel?.Invoke();
        }

        public void SetPause(bool pause)
        {
            Pause = pause;
        }
    }
}