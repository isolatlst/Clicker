namespace Codebase.Data.SaveSystem
{
    public interface ISaveSystem
    {
        public void Save<T>(T dataToSave);
        public T Load<T>(T dataByDefault);
    }
}