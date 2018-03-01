public interface IDataHelper : IData
{
    IData[ ] Data { get; }

    void Load();
}