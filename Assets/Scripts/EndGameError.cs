using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameError : MonoBehaviour
{
    // Start is called before the first frame update
   public void openPanelEnd()
    {
        //Debug.Log("aos meninus");
        //if (value.Equals("Fernando Inácio"))
        //{
        //    endGame = "Parabéns Você Descobriu Quem Cometeu os crimes";
        //}

        SceneManager.LoadScene("ErrorChoice");
    }
}
