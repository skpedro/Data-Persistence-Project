using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static Save Instance;

    [Serializable]
    public class Data
    {
        public int score;
        public string playerName;
    }

    [Serializable]
    public class Lead
    {
        public List<Data> leaders = new List<Data>();
    }

    public void Savelid(int _score, string _name)
    {
        Lead lead = LoadLead();
        lead.leaders.Add(new Data { playerName = _name, score = _score });
        string json = JsonUtility.ToJson(lead);
        File.WriteAllText(Application.persistentDataPath + "/lead.json", json);
    }

    public void SaveData(string name)
    {
        Data data = new Data();
        data.playerName = name;
        data.score = MainManager.bScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public Lead LoadLead()
    {
        string path = Application.persistentDataPath + "/lead.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Lead newlead = JsonUtility.FromJson<Lead>(json);
            return newlead;
        }
        return new Lead();
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);
            MainManager.name = data.playerName;
            MainManager.bScore = data.score;
        }
    }

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
}

