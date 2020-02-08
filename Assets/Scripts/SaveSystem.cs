using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavingSystem
{
#region GameManagerOrign
#region OrginData1
    public static void OrignSave1 (GameManagerOrign gameManagerOrign){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Orign1.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        OrignSave1 data = new OrignSave1(gameManagerOrign);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static OrignSave1 OrignLoad1(){
        string path = Application.persistentDataPath + "/Orign1.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            OrignSave1 data = formatter.Deserialize(stream) as OrignSave1;
            stream.Close();
            return data;
        }
        else{
            Debug.Log("Save File Cannot be found in " + path);
            return null;
        }
    }
#endregion

#region OrignData2
    public static void OrignSave2 (GameManagerOrign gameManagerOrign){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Orign2.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        OrignSave2 data = new OrignSave2(gameManagerOrign);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static OrignSave2 OrignLoad2(){
        string path = Application.persistentDataPath + "/Orign2.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            OrignSave2 data = formatter.Deserialize(stream) as OrignSave2;
            stream.Close();
            return data;
        }
        else{
            Debug.Log("Save File Cannot be found in " + path);
            return null;
        }
    }
#endregion

#region OrignDataExit
    public static void OrignExitData (GameManagerOrign gameManagerOrign){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/OrignExit.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        OrignExitData data = new OrignExitData(gameManagerOrign);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static OrignExitData OrignExitLoad(){
        string path = Application.persistentDataPath + "/OrignExit.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            OrignExitData data = formatter.Deserialize(stream) as OrignExitData;
            stream.Close();
            return data;
        }
        else{
            Debug.Log("Save File Cannot be found in " + path);
            return null;
        }
    }

#endregion
#endregion

#region GameManager4x4
#region SaveData1
    public static void SaveGame1 (GameManager4x4 gameManager4x4){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game1.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavedData1 data = new SavedData1(gameManager4x4);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavedData1 LoadGame1(){
        string path = Application.persistentDataPath + "/Game1.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData1 data = formatter.Deserialize(stream) as SavedData1;
            stream.Close();
            return data;
        }
        else{
            Debug.Log("Save File Cannot be found in " + path);
            return null;
        }
    }
#endregion

#region SaveData2
    public static void SaveGame2 (GameManager4x4 gameManager4x4){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game2.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavedData2 data = new SavedData2(gameManager4x4);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavedData2 LoadGame2(){
        string path = Application.persistentDataPath + "/Game2.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedData2 data = formatter.Deserialize(stream) as SavedData2;
            stream.Close();
            return data;
        }
        else{
            Debug.Log("Save File Cannot be found in " + path);
            return null;
        }
    }
#endregion

#region ExitSaveData
    public static void ExitGameSave (GameManager4x4 gameManager4x4){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Exit.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        ExitData data = new ExitData(gameManager4x4);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ExitData ExitGameLoad(){
        string path = Application.persistentDataPath + "/Exit.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ExitData data = formatter.Deserialize(stream) as ExitData;
            stream.Close();
            return data;
        }
        else{
            Debug.Log("Save File Cannot be found in " + path);
            return null;
        }
    }

#endregion
#endregion

#region GameManager3x3
#region SaveData1
    public static void Save3x3Game1 (GameManager3x3 gameManager3x3){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game1_3x3.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        Saved3x3Data1 data = new Saved3x3Data1(gameManager3x3);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Saved3x3Data1 Load3x3Game1(){
        string path = Application.persistentDataPath + "/Game1_3x3.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Saved3x3Data1 data = formatter.Deserialize(stream) as Saved3x3Data1;
            stream.Close();
            return data;
        }
        else{
            Debug.Log("Save File Cannot be found in " + path);
            return null;
        }
    }
#endregion

#region SaveData2
    public static void Save3x3Game2 (GameManager3x3 gameManager3x3){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game2_3x3.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        Saved3x3Data2 data = new Saved3x3Data2(gameManager3x3);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Saved3x3Data2 Load3x3Game2(){
        string path = Application.persistentDataPath + "/Game2_3x3.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Saved3x3Data2 data = formatter.Deserialize(stream) as Saved3x3Data2;
            stream.Close();
            return data;
        }
        else{
            Debug.Log("Save File Cannot be found in " + path);
            return null;
        }
    }
#endregion

#region ExitSaveData
    public static void ExitGameSave3x3 (GameManager3x3 gameManager3x3){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Exit3x3.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        ExitData3x3 data = new ExitData3x3(gameManager3x3);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ExitData3x3 ExitGameLoad3x3(){
        string path = Application.persistentDataPath + "/Exit3x3.data";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ExitData3x3 data = formatter.Deserialize(stream) as ExitData3x3;
            stream.Close();
            return data;
        }
        else{
            Debug.Log("Save File Cannot be found in " + path);
            return null;
        }
    }

#endregion
#endregion
}
