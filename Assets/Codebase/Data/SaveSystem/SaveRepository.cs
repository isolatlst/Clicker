using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Codebase.Data.SaveSystem
{
    public class SaveRepository : MonoBehaviour
    {
        private Dictionary<string, object> _dataForSave;
        private ISaveSystem _saveSystem;

        private string GetKey<T>() => typeof(T).Name;

        private void Awake()
        {
            _saveSystem = new FileSaveSystem();
            _dataForSave = new Dictionary<string, object>();
            _dataForSave = _saveSystem.Load(_dataForSave);
        }

        public void Save<T>(T dataToSave)
        {
            _dataForSave[GetKey<T>()] = dataToSave;
        }

        public T Load<T>(T dataByDefault)
        {
            if (_dataForSave.TryGetValue(GetKey<T>(), out var savedData))
            {
                if (savedData is T data)
                    return data;

                if (savedData is JObject jObject)
                    return jObject.ToObject<T>();
            }
            
            return dataByDefault;
        }
        
        //TODO поменять перед билдом
        private void OnDestroy()
        {
            _saveSystem.Save(_dataForSave);
        }
        // private void OnApplicationPause(bool isPaused) 
        // {
        //     if (isPaused)   
        //         _saveSystem.Save(_dataForSave);
        // }
    }
}