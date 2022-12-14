using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public bool wavefree = true;
    public float startmoney;

    [SerializeField] private float countdown = 10f;
    [SerializeField] public int waveNumber = 0;

    void Start()
    {
        
    }
    public void Wavefree()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            wavefree = true;
        }
        else
        {
            wavefree = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Wavefree();
        if(countdown <= 0f && wavefree == true)
        {
            StartCoroutine(SpawnWave());
            countdown = timebetweenwaves;
            wavefree = false;
        }
        else if(waveNumber == 10 && GameObject.FindGameObjectWithTag("Enemy")==null)
        {
            SceneManager.LoadScene(2);
        }
        countdown -= Time.deltaTime;
        WaveCountdownText.text = Mathf.Round(countdown).ToString();
        WaveCounter.text = Mathf.Floor(waveNumber).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveinfo[waveNumber].enemyTypes.Count; i++)
        {
            spawnEnemy(i);
            yield return new WaitForSeconds(1f);
        }
        

    }
    void spawnEnemy(int type)
    {
        GameObject Enemy = enemies[(int)waveinfo[waveNumber].enemyTypes[type]];
        enemy = (GameObject)Instantiate(Enemy);
        enemy.transform.position = spawnPoint.transform.position;
        enemy.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }
}
