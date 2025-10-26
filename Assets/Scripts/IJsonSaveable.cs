

public interface IJsonSaveable
{
    string SaveID { get; }
    string SaveData();
    void LoadData(string data);
}
