using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private float bearHeight;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameFinishedScreen;
    [SerializeField] private GameObject bearPrefab;
    [SerializeField] private GameObject bearPlayerInstance;
    [SerializeField] private Transform bearSpawnTransform;
    public float playTime;
    


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
        playTime += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerDies();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameFinished();
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
        Text toyCount = gameFinishedScreen.transform.Find("Toy counts Text").GetComponent<Text>();
        Text time = gameFinishedScreen.transform.Find("Time").GetComponent<Text>();

        toyCount.text = "Toy count: " + ObstacleSpawner.toyCount;
        time.text = "Time: " + playTime;
    }

    public static GameManager Instance { get => instance; }
}
