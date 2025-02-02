namespace Codebase.Data.SaveSystem
{
    public interface ISaveSystem
    {
        public void Save<T>(string key, T dataToSave);
        public T Load<T>(string key);
    }
}