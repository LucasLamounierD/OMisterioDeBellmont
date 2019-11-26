﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public struct CrosshairSize
{
    public Vector2 small;
    public Vector2 medium;
    public Vector2 big;
}


public class Crosshair : MonoBehaviour {

    //Sprites
    [Header("Icons")]
    [SerializeField] private Sprite pickUp;
    [SerializeField] private Sprite note;
    [SerializeField] private Sprite crosshair;
    //crossHair image
    private Image img;
    public CrosshairSize crosshairSize = new CrosshairSize();
    [SerializeField] private InteractionRayCaster _raycaster;

    private bool canPick = false;

    public GameObject Panel;

    public GameObject player;

    public GameObject obj; 

    public GameObject camera;

    // Use this for initialization
    void Start() {
        _raycaster = Camera.main.GetComponent<InteractionRayCaster>();

        _raycaster.onTargetChange += ChangeCrosshair;
        _raycaster.onNoTarget += ChangeCrosshair;

        img = gameObject.GetComponent<Image>();

    }

    private void OnDisable()
    {
        _raycaster.onTargetChange -= ChangeCrosshair;
        _raycaster.onNoTarget -= ChangeCrosshair;
    }

    void Update() {
        if (canPick == true && _raycaster.Hit.collider.tag == "pickUp")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (Panel != null)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    Panel.SetActive(true);

                    //GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
                    ////Create the PointerEventData with null for the EventSystem
                    //PointerEventData ped = new PointerEventData(null);
                    ////Set required parameters, in this case, mouse position
                    //ped.position = Input.mousePosition;
                    ////Create list to receive all results
                    //List<RaycastResult> results = new List<RaycastResult>();
                    ////Raycast it
                    //gr.Raycast(ped, results);

                    camera.GetComponent<CameraController>().enabled = false;
                    Panel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = _raycaster.Hit.collider.gameObject.GetComponent<IInventoryItem>().Image;
                    player.GetComponent<Player>().currentObject = _raycaster.Hit.collider.gameObject;
                }
            }
        }
    }

    void ChangeCrosshair()
    {
        if(_raycaster.Hit.collider != null)
        {
            switch (_raycaster.Hit.collider.tag)
            {
                case "pickUp":
                    SetIcon(pickUp);
                    canPick = true;
                    SetSize(crosshairSize.medium);
                    break;
                case "note":
                    SetIcon(note);
                    canPick = false;
                    SetSize(crosshairSize.medium);
                    break;
                default:
                    SetIcon(crosshair);
                    canPick = false;
                    SetSize(crosshairSize.small);
                    break;
            }
        }
        else
        {
            SetIcon(crosshair);
            canPick = false;
            SetSize(crosshairSize.small);
            return;
        }
    }

    void SetIcon(Sprite icon)
    {
        img.sprite = icon;
    }

    void SetSize(Vector2 size)
    {
        img.GetComponent<RectTransform>().sizeDelta = size;
    }

}
