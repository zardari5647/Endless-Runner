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



    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    void Start()
    {
        speed = 0.1f;
        lives=3;
        playerRb = GetComponent<Rigidbody>();
        playerRb.freezeRotation = true;
        isGameActive = true;
        gameOverText.gameObject.SetActive(false);
        backgroundMusic.Play();
    }

    void Update()
    {

        foreach (Image img in hearts){
            img.sprite = emptyHeart;
        }
        for (int i=0; i<lives; i++){
            hearts[i].sprite=fullHeart;
        }

        transform.Translate(0,0,speed);
        
        if (Input.GetKeyDown(KeyCode.Space)){   
            if(transform.position.y<=0.01){
               playerRb.AddForce(Vector3.up * 7f, ForceMode.Impulse);
            }            
           
        }

        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = new Vector3(horizontalInput, 0f, 0f);
        playerRb.AddForce(horizontalMovement * 10f);

        if (transform.position.x < 411 )
        {
         transform.position = new Vector3(411, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 431 )
        {
         transform.position = new Vector3(431, transform.position.y, transform.position.z);
        }

        timer += Time.deltaTime;

        if(timer > 5f){
            speed = 0.1f;
        }


    }    

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Money"))
        {
            coinSound.Play();
            coinScore++;
            coins.text = "Coins: " + coinScore;

        } 
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {

            bombSound.Play();
            Debug.Log("hit bomb");
            explosionParticle.Play();
            lives--;
            livesText.text = "Lives: " + lives;

            if(lives==0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }



        }

        if(other.gameObject.CompareTag("Wood"))
        {

            lives--;
            livesText.text = "Lives: " + lives;

            if(lives==0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        }

        if(other.gameObject.CompareTag("Speed"))
        {

            timer = 0f;
            speed = 0.3f;
        }


        


    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }



    
   
        
}
