using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.Game
{
    public class GameResourceLoader : MonoBehaviour
    {
        //Запрос у save repository асинхронно загрузить статы
        private void Start()
        {
            LoadScene();
        }
        
        private async void LoadScene()
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
}