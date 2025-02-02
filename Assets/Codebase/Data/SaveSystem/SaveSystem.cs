using Newtonsoft.Json;
using UnityEngine;

namespace Codebase.Data.SaveSystem
{
    public class SaveSystem : ISaveSystem
    {
        public void Save<T>(string key, T dataToSave)
        {
            var json = JsonConvert.SerializeObject(dataToSave);
            Debug.Log(json);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }

        public T Load<T>(string key)
        {
            if (PlayerPrefs.HasKey(key))
            {
                var json = PlayerPrefs.GetString(key);
                Debug.Log(json);
                return JsonConvert.DeserializeObject<T>(json);
            }
            
            return default(T);
        }
    }
}