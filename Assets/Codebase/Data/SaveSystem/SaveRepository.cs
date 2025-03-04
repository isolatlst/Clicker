using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Zenject;

namespace Codebase.Data.SaveSystem
{
    public class SaveRepository : IInitializable, IDisposable
    {
        private Dictionary<string, object> _dataForSave = new();
        private FileSaveSystem _saveSystem;

        public SaveRepository(FileSaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
        }

        private string GetKey<T>() => typeof(T).Name;

        public void Initialize()
        {
            _dataForSave = _saveSystem.Load(_dataForSave);
        }

        public void Save<T>(T dataForSave)
        {
            _dataForSave[GetKey<T>()] = dataForSave;
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

        public void Dispose()
        {
            _saveSystem.Save(_dataForSave);
        }
    }
}