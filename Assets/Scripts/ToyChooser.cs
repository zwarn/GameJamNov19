﻿using System.Collections;
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

    void Start()
    {
        ReinitAvailableIndices();
    }
    
    public List<GameObject> toys;
    List<int> availableIndices = new List<int>();   //  Declare list

    public GameObject getRandomToy()
    {
        int index = Random.Range(0, availableIndices.Count);    //  Pick random element from the list
        int i = availableIndices[index];    //  i = the number that was randomly picked
        availableIndices.RemoveAt(index);   //  Remove chosen element

        return toys[i];
    }

    public void ReinitAvailableIndices()
    {
        availableIndices = new List<int>();

        for (int i = 0; i < toys.Count; i++)
        {
            availableIndices.Add(i);
        }
    }
    
}
