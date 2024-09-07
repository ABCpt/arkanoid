using Core.Bricks.Services;
using UnityEngine;
using Zenject;

namespace Core.Bricks.View
{
    public class EnemySpawnPointView : MonoBehaviour
    {
        [Inject]
        public void Construct(BricksService bricksService)
        {
            bricksService.AddSpawnPoint(this.transform.position);
            gameObject.SetActive(false);
        }
    }
}
