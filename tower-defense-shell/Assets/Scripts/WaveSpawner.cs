using UnityEngine;
public class WaveSpawner : MonoBehaviour {
    //wavespawner is basic, use instantiate command pretty excessivly 
    public Transform enemyPrefab; //this one single enemy that weve made

    public float timeBetweenWaves = 7.5f;
    private float countdown = 2f; //two seconds for first wave


    void Update()
    {
        if (countdown <= 0)
        {
            SpawnWave();
            countdown = timeBetweenWaves;  //time before spawn of wave
        }
        countdown -= Time.deltaTime; //decrease our countdown by one each second
    }

    void SpawnWave()
    {
        Debug.Log("Wave incoming");

    }

}
