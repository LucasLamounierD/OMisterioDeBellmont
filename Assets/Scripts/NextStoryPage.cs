using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStoryPage : MonoBehaviour
{
    public string cena;
    public void nextStory(){
        SceneManager.LoadScene(cena);
    }
}
