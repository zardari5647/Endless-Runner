using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsBomb : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         //spawns object at this position
        spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
        
    }


    //When player hits bomb, trigger explosion particle    
    void OnTriggerEnter(Collider other) {
        
        //explosionParticle at fixed position
        Instantiate(explosionParticle, spawnPos, Quaternion.identity);
        explosionParticle.Play();
     }

}
