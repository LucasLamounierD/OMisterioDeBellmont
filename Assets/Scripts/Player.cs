using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    public Inventory inventory;
    public ArrayList pistas = new ArrayList();
    public GameObject currentObject; 

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.5f;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) && speed < 5)
            speed += 0.1f;
        else if(!Input.GetKey(KeyCode.LeftShift) && speed > 2.5)
            speed -= 0.1f;


        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, 0, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, 0, -speed * Time.deltaTime);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        //if (item != null)
        //{
        //    inventory.AddItem(item);
        //}
    }

}
