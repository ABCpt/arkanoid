using Core.Bricks.Data;
using Core.Bricks.Services;
using Core.Data;
using Core.Level.Data;
using Core.Level.Interface;
using Core.Level.Model;
using UnityEngine;

namespace Core.Bricks.Rules
{
    public class SpawnBricksRule : ILevelStartable
    {
        private readonly BricksService _bricksService;
        private readonly BricksConfig _bricksConfig;
        private readonly LevelConfig _levelConfig;
        private readonly LevelModel _levelModel;

        public SpawnBricksRule(BricksService bricksService, GameSettings gameSettings, LevelModel levelModel)
        {
            _bricksService = bricksService;
            _bricksConfig = gameSettings.BricksConfig;
            _levelConfig = gameSettings.LevelConfig;
            _levelModel = levelModel;
        }

        public void StartLevel()
        {
            for (var i = 0; i < _levelModel.LevelGrid.BricksArray.Length; i++)
            {
                var rowArray = _levelModel.LevelGrid.BricksArray[i];

                for (var column = 0; column < rowArray.Length; column++)
                {
                    if (rowArray[column] != BrickType.Null)
                        SpawnBrick(i, column, rowArray[column]);
                }
            }
        }
        
        private void SpawnBrick(int row, int column, BrickType brickType)
        {
            var position = GetBrickPosition(row, column);

            _bricksService.SpawnBrick(position, brickType, row);
        }

        private Vector2 GetBrickPosition(int row, int column)
        {
            var xOffset = _bricksConfig.BrickSize.x + _bricksConfig.BrickOffset.x;
            var yOffset = _bricksConfig.BrickSize.y + _bricksConfig.BrickOffset.y;
            
            var x = column * xOffset;
            var y = row * yOffset;

            x -= xOffset * _levelModel.LevelGrid.Width / 2f - _bricksConfig.BrickSize.x / 2f;
            y -= yOffset * _levelModel.LevelGrid.Height / 2f;

            y += _levelConfig.CameraSize * 0.5f;
            
            return new Vector2(x, y);
        }
        
    }
}
