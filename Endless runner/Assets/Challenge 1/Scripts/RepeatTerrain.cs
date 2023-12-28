using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatTerrain : MonoBehaviour
{
    public Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

           //when player passes terrain, move current terrain after the third terrain   
          if(playerRb.position.z > transform.position.z + 97.5){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 292.5f); //three terrains
          }
        
    }
}
