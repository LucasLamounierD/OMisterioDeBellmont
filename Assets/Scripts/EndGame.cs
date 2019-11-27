using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject finalGamePanel;
    public GameObject endGamePanel;
    public Dropdown dropDown;

    public void openPanelEnd()
    {
        //find your dropdown object
        //Dropdown dropdownMenu = (Dropdown)dropDown.GetComponent<Dropdown>();

        //get the selected index
        //        Text menuIndex = dropDown.GetComponent<Text>();

        //Debug.Log(dropDown);
        //get the string value of the selected index
        //string value = dropdownMenu.captionText.text;
        string value = "";
        string endGame = "Você apontou para a pessoa errada";
        //Debug.Log("aos meninus");
        //if (value.Equals("Fernando Inácio"))
        //{
        //    endGame = "Parabéns Você Descobriu Quem Cometeu os crimes";
        //}

        finalGamePanel.SetActive(true);
        endGamePanel.SetActive(false);
        //GameObject.Find("ResultEndGame").GetComponent<Text>().text = endGame;
    }
}
