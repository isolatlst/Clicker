using UnityEngine;

namespace Codebase.GameLoop
{
    public class GameLoop : MonoBehaviour
    {
        [SerializeField] private GameObject _playerTemplate;
        [SerializeField] private GameObject _saveSystemTemplate;
        [SerializeField] private Transform _gameRootSpawnPoint;

        private void Awake()
        {
        }
    }
}