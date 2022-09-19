using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyprefab;
    public Transform spawnPoint;
    public float timebetweenwaves = 5f;
    public Text WaveCountdownText;
    public Text WaveCounter;

    [SerializeField] private float countdown = 3f;
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
        countdown -= Time.deltaTime;
        WaveCountdownText.text = Mathf.Round(countdown).ToString();
        WaveCounter.text = Mathf.Floor(waveNumber).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
        
    }
    void spawnEnemy()
    {
        Instantiate(enemyprefab, spawnPoint.position, spawnPoint.rotation);
    }
}
