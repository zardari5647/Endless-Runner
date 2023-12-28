using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    //Destroys objects after 10 seconds after passing it, frees space
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
