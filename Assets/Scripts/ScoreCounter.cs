using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    [SerializeField]
    private Text scoreText;


    [SerializeField]
    private FloatReference towerHeight;


    void Update()
    {
        scoreText.text = towerHeight.value.ToString("F1");
    }
}
