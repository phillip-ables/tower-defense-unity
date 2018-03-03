using UnityEngine;
using System.Collections;
//wavespawner is basic, use instantiate command pretty excessivly 
public class WaveSpawner : MonoBehaviour {
    public Transform enemyPrefab; //this one single enemy that weve made
    public Transform spawnPoint;

    public float timeBetweenWaves = 7.5f;
    private float countdown = 2f; //two seconds for first wave

    private int waveNumber = 0;

    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;  //time before spawn of wave
        }
        countdown -= Time.deltaTime; //decrease our countdown by one each second
    }

    IEnumerator SpawnWave() // when we span a wave we want to span a group of enemies
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); //yield for IEnumerator
        }
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }

}
