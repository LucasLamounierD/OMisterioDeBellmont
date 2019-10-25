using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public ArrayList pistas = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {

        foreach( var p in pistas )
        {
            Debug.Log( p );
        }

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

}
