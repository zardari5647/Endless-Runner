using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
  public void PlayGame ()
  {

    //goes to game
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

  }



}
