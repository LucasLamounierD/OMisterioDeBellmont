using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject player;

    public GameObject camera;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
            Resume();
            }else{
                Pause();
            }
        }
    }

    void Resume(){
        pauseMenuUI.SetActive(false);
        //player.GetComponent<MouseLook>().enabled = true;
        //camera.GetComponent<MouseLook>().enabled = true;
        Time.timeScale =1f;
        GameIsPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        //player.GetComponent<MouseLook>().enabled = false;
        //camera.GetComponent<MouseLook>().enabled = false;
        Time.timeScale =0f;
        GameIsPaused = true;
    }

    void Quit(){
        Application.Quit();
    }
}
