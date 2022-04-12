using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CoinsCountSave : MonoBehaviour
{
    [SerializeField] private Inventory inventory = null;

    private void Start()
    {
        Load();
    }
    void Update()
    {
        if (inventory.isSave == true)
        {
            Save();
        }
    }

    void Save()
    {
        string saveString = inventory.coinsCount.ToString();
        File.WriteAllText(Application.dataPath + "/data.txt", saveString);
        Debug.Log("Donnée sauvegarder");


    }

    public void Load()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/data.txt");
        inventory.coinsCount = int.Parse(saveString);
        Debug.Log("Chargement effectué");
    }


}
