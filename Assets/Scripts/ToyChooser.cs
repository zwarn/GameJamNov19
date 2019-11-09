using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyChooser : MonoBehaviour
{
    private static ToyChooser _instance;

    public static ToyChooser GetInstance()
    {
        return _instance;
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogError("ToyChooser already present");
        }
    }
    
    public List<GameObject> toys;

    public GameObject getRandomToy()
    {
        int choice = Random.Range(0, toys.Count);
        return toys[choice];
    }
    
}
