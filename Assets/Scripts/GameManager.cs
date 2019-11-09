using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private float bearHeight;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameFinishedScreen;
    [SerializeField] private GameObject bearPrefab;
    [SerializeField] private GameObject bearPlayerInstance;
    [SerializeField] private Transform bearSpawnTransform;
    private float playTime;
    


    [SerializeField]
    private FloatReference towerHeight;

    void Awake()
    {
        instance = this;
        towerHeight.Reset();
    }

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

    public void PlayerDies()
    {
        Destroy(bearPlayerInstance);
        gameOverScreen.SetActive(true);
        StartCoroutine(RespawnPlayer());
        towerHeight.Reset();
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2.0f);
        gameOverScreen.SetActive(false);
        bearPlayerInstance = Instantiate(bearPrefab, bearSpawnTransform.position, Quaternion.identity);
    }

    public void GameFinished()
    {
        gameFinishedScreen.SetActive(true);
    }

    public static GameManager Instance { get => instance; }
}
