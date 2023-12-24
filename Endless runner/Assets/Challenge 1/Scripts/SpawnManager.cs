using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject speedPrefab;
    public GameObject bombPrefab;
    public GameObject moneyPrefab;
    public GameObject woodPrefab;
    private Vector3 spawnPos, spawnPos1,spawnPos2,spawnPos3;
    public Rigidbody playerRb;

    private float startDelay = 2;
    private float coinRepeatRate = 2;
    private float bombRepeatRate = 5;
     private float woodRepeatRate = 10;
       private float speedRepeatRate = 20;
    private float timer=0f;




    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("SpawnCoin", startDelay, coinRepeatRate);
       InvokeRepeating("SpawnBomb", startDelay, bombRepeatRate);
       InvokeRepeating("SpawnWood", startDelay, woodRepeatRate);
        InvokeRepeating("SpawnSpeed", startDelay, speedRepeatRate);


    }

    // Update is called once per frame
    void Update()
    {
        spawnPos = new Vector3(Random.Range(415, 430), 0, playerRb.position.z + 100);
        spawnPos1 = new Vector3(Random.Range(415, 430), 1, playerRb.position.z + 115);
        spawnPos2 = new Vector3(422.3f, 0.27f, playerRb.position.z + 115);
        spawnPos3 = new Vector3(Random.Range(415, 430), 1, playerRb.position.z + 80);
        //int index = Random.Range(0, objectPrefabs.Length);
        timer += Time.deltaTime;

        if (timer > 20f) {

            CancelInvoke("SpawnBomb");
            bombRepeatRate = bombRepeatRate/2;
            timer = 0f;

            InvokeRepeating("SpawnBomb", startDelay, bombRepeatRate);

        }

        
    }

    void SpawnCoin () {
        GameObject test = Instantiate(moneyPrefab, spawnPos, moneyPrefab.transform.rotation);
        test.AddComponent<BoxCollider>();
    }
    
    void SpawnBomb () {
        GameObject test2 = Instantiate(bombPrefab, spawnPos1, bombPrefab.transform.rotation);
        test2.AddComponent<BoxCollider>();
    }

    void SpawnWood() {
        GameObject test3 = Instantiate(woodPrefab, spawnPos2, Quaternion.identity);
        test3.AddComponent<BoxCollider>();
    }

     void SpawnSpeed() {
        GameObject test4 = Instantiate(speedPrefab, spawnPos3, Quaternion.identity);
        test4.AddComponent<BoxCollider>();
    }

}
