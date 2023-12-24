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

        spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
        
    }

    void OnTriggerEnter(Collider other) {
        //Destroy(gameObject);
        Instantiate(explosionParticle, spawnPos, Quaternion.identity);
        explosionParticle.Play();
     }

}
