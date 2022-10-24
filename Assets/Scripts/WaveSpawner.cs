using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public List<Wavegroups> waveinfo;
    public List<GameObject> enemies;

    public GameObject enemyprefab;
    private GameObject enemy;
    public Transform spawnPoint;
    public float timebetweenwaves;
    public Text WaveCountdownText;
    public Text WaveCounter;

    [SerializeField] private float countdown = 10f;
    [SerializeField] private int waveNumber = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timebetweenwaves;
        }
        if(waveNumber == 10)
        {
            countdown = 100f;
        }
        countdown -= Time.deltaTime;
        WaveCountdownText.text = Mathf.Round(countdown).ToString();
        WaveCounter.text = Mathf.Floor(waveNumber).ToString();
    }

    IEnumerator SpawnWave()
    {
        
        for (int i = 0; i < waveinfo[waveNumber].enemyTypes.Count; i++)
        {
            spawnEnemy(i);
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;

    }
    void spawnEnemy(int type)
    {
        GameObject Enemy = enemies[(int)waveinfo[waveNumber].enemyTypes[type]];
        enemy = (GameObject)Instantiate(Enemy);
        enemy.transform.position = spawnPoint.transform.position;
        enemy.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }
}
