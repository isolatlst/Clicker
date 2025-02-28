using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.Boot
{
    public class GameResourceLoader : MonoBehaviour
    {
        //Запрос у save repository асинхронно загрузить статы
        private void Start()
        {
            LoadScene();
        }
        
        private void LoadScene()
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
}