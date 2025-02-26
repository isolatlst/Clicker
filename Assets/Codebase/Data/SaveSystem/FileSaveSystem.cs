using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Codebase.Data.SaveSystem
{
    public class FileSaveSystem
    {
        private readonly string _savesPath;

        public FileSaveSystem()
        {
            var directory = Application.persistentDataPath + "/Saves";
            if (!Directory.Exists(directory)) 
                Directory.CreateDirectory(directory);
            _savesPath = directory + "/Save.save";
        }

        public void Save<T>(T dataToSave)
        {
            var json = JsonConvert.SerializeObject(dataToSave);
            using (var writer = new StreamWriter(_savesPath))
            {
                writer.WriteLine(json);
            }
        }

        public T Load<T>(T dataByDefault)
        {
            if (!File.Exists(_savesPath))
                return dataByDefault;
            
            var json = File.ReadAllText(_savesPath);
            
            if(string.IsNullOrEmpty(json))
                return dataByDefault;
            
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}