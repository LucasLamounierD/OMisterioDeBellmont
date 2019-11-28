using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionRayCaster))]
public class CursorController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        //Unlock Cursor
        if (Input.GetKey(KeyCode.I) && Cursor.visible == false)
        {
            Debug.Log(Cursor.visible);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
            if (Input.GetKey(KeyCode.I) && Cursor.visible == true)
        {
            Debug.Log(Cursor.visible);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        //else if (Input.GetButtonDown("Fire1") && Cursor.visible == true){
        //    print("cursor");
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //}
    }

    void ChangeCursor()
    {
        throw new NotImplementedException();
    }

    void HideCursor()
    {
        Cursor.visible = false;
    }

    public void ChangeCursorIcon(Texture2D texture)
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
