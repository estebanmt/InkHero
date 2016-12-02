using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    // Existe una sola instancia de esta clase
    // Se referencia con GameControl.algo

    public static GameControl control;

    public int money;
    
	void Awake () {

        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
	}

    public void AddMoney(int gainedMoney)
    {
        money += gainedMoney;
    }

    // autosave
    void OnEnable()
    {
        Load();
    }

    // autoload
    void OnDisable()
    {
        Save();
    }

    void Save ()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.money = this.money;

        bf.Serialize(file, data);
        file.Close();
    }

    void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            money = data.money;
        }
    }
	
}

[Serializable]
class PlayerData
{
    public int money;

}
