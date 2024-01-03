using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerControllerX : MonoBehaviour
{

    Rigidbody playerRb;
    public float jumpforce = 10f;
    float horizontalInput;
    public ParticleSystem explosionParticle;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public int coinScore;
    public bool isGameActive;
    public AudioSource coinSound;
    public AudioSource bombSound;
    public AudioSource backgroundMusic;
    public int lives;
    public float speed;
    private float timer = 0f;
    private Animator animator;



    public Image[] hearts;
    public Sprite fullHeart; //image
    public Sprite emptyHeart; //image
    void Start()
    {
        speed = 0.2f;
        lives=3;
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
        isGameActive = true;
        gameOverText.gameObject.SetActive(false);
        backgroundMusic.Play();
        animator=GetComponent<Animator>();
    }

    void Update()
    {

        // Display heart health sprites
        foreach (Image img in hearts){
            img.sprite = emptyHeart;
        }
        for (int i=0; i<lives; i++){
            hearts[i].sprite=fullHeart;
        }

        //Move forward
        transform.Translate(0,0,speed);

        //jump space key
        if (Input.GetKeyDown(KeyCode.Space)){   
            if(transform.position.y<=0.01){ //when player on ground
               playerRb.AddForce(Vector3.up * 7f, ForceMode.Impulse);
               animator.SetBool("isJump",true);
               

            }            
           
        }
        //when player is in air 
        if(transform.position.y > 2.3){
            animator.SetBool("isJump",false);
        }

 
        //makes player move left and right
        horizontalInput = Input.GetAxis("Horizontal"); 
        Vector3 horizontalMovement = new Vector3(horizontalInput, 0f, 0f);
        playerRb.AddForce(horizontalMovement * 10f);
         
         //stops player from falling off edge
        if (transform.position.x < 411 )
        {
         transform.position = new Vector3(411, transform.position.y, transform.position.z);
        }
        
        if (transform.position.x > 431 )
        {
         transform.position = new Vector3(431, transform.position.y, transform.position.z);
        }

        timer += Time.deltaTime;

        //when speed boost runs out
        if(timer > 5f){
            speed = 0.2f;
        }


    } 

    
    private void OnCollisionEnter(Collision other)
    {
 


          //when player collides with coins 
        if (other.gameObject.CompareTag("Money"))
        {
            coinSound.Play();
            coinScore++; //add one to coin total
            coins.text = "Coins: " + coinScore;

        } 
        // when player collides with bomb, 
        if (other.gameObject.CompareTag("Bomb"))
        {

            bombSound.Play();
            Debug.Log(explosionParticle);
            explosionParticle.Play();
            lives--; //lose one live when collides with bomb
            livesText.text = "Lives: " + lives;
  
            //when all three lives are gone, loads game over screen
            if(lives==0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }



        }  

         //when player collides with log
        if(other.gameObject.CompareTag("Wood"))
        {

            lives--; 
            livesText.text = "Lives: " + lives;

            if(lives==0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        }

         //when player collects speed boost
        if(other.gameObject.CompareTag("Speed"))
        {

            timer = 0f; //start of timer for speed boost
            speed = 0.4f;
        }

    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }



    
   
        
}
