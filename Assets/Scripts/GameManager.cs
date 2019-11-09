﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float bearHeight;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject bearPrefab;
    [SerializeField] private GameObject bearPlayerInstance;
    [SerializeField] private Transform bearSpawnTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerDies();
        }
    }

    void PlayerDies()
    {
        Destroy(bearPlayerInstance);
        gameOverScreen.SetActive(true);
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2.0f);
        gameOverScreen.SetActive(false);
        bearPlayerInstance = Instantiate(bearPrefab, bearSpawnTransform.position, Quaternion.identity);
    }
}