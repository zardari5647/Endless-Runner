using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{

    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  

     //after clicking try again button
    public void LoadGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
