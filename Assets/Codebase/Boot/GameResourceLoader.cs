using System.Threading.Tasks;
using Codebase.Infrastructure.Services;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Codebase.Boot
{
    public class GameResourceLoader : MonoBehaviour
    {
        private SavecheckService _savecheckService;
        
        [Inject]
        public void Construct(SavecheckService savecheckService)
        {
            _savecheckService = savecheckService;
        }
        
        private async void Start()
        {
            await LoadSceneAndLoadData(1);
        }
        
        private async Task LoadSceneAndLoadData(int id)
        {
            await LoadSceneAsync(id);
            
            LoadData();
        }

        private Task LoadSceneAsync(int id)
        {
            var tcs = new TaskCompletionSource<bool>();

            var asyncOperation = SceneManager.LoadSceneAsync(id);
            asyncOperation.completed += _ => tcs.SetResult(true);

            return tcs.Task;
        }

        private void LoadData()
        {
          _savecheckService.InitializeData();
        }
    }
}