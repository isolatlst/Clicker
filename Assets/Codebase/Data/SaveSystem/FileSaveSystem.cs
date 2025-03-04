using System.IO;
using Codebase.Infrastructure.Utils;
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
            var encryptedJson = AesUtility.Encrypt(json);

            using (var writer = new StreamWriter(_savesPath))
            {
                writer.WriteLine(encryptedJson);
            }
        }

        public T Load<T>(T dataByDefault)
        {
            if (!File.Exists(_savesPath))
                return dataByDefault;

            var encryptedJson = File.ReadAllText(_savesPath);
            var json = AesUtility.Decrypt(encryptedJson);

            if (json.EnsureNotFreaked())
                return dataByDefault;

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}