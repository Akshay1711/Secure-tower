using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveGameData 
{
    public static void SavePlayerData(MainMenu menu)
    {
        string path = Application.persistentDataPath + "/gameLog.xuv";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Create);
        GameLog log = new GameLog(menu);
        formatter.Serialize(fs, log);
        fs.Close();
    }

    public static GameLog LoadPlayerDetails()
    {
        string path = Application.persistentDataPath + "/gameLog.xuv";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            GameLog log = formatter.Deserialize(fs) as GameLog;
            fs.Close();
            return log;
        } else
        {
            Debug.LogError("File not found" + path);
            return null;
        }
    }
}
