﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public void openPanelEnd()
    {
        //Debug.Log("aos meninus");
        //if (value.Equals("Fernando Inácio"))
        //{
        //    endGame = "Parabéns Você Descobriu Quem Cometeu os crimes";
        //}

        SceneManager.LoadScene("SuccessChoice");
    }
}
