using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class DataSaving
{
    public long money;
    public int level;
    public int levelskill1;
    public int levelskill2;
}
public class DataManager : MonoSingleton<DataManager>
{
    public DataSaving saving = new DataSaving();

    public void SaveData()
    {
        ES3.Save<DataSaving>("data", saving);
    }
    public DataSaving LoadData()
    {
        return ES3.Load<DataSaving>("data");
        
    }
    private void Awake()
    {
        //Callme();
        saving = LoadData();
    }
    private void Callme()
    {
        saving.level = 1;
        saving.money = 100;
        saving.levelskill1 = 1;
        saving.levelskill2 = 1;
        SaveData();
    }
    [ContextMenu("DeleteData")]
    public void DeleteData()
    {
        saving.level = 1;
        saving.money = 100;
        saving.levelskill1 = 1;
        saving.levelskill2 = 1;
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
