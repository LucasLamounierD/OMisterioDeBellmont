using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animation;

    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
            animation.SetBool("Front", true);
        else
            animation.SetBool("Front", false);

        if (Input.GetKey(KeyCode.S))
            animation.SetBool("Back", true);
        else
            animation.SetBool("Back", false);

        if (Input.GetKey(KeyCode.A))
            animation.SetBool("Left", true);
        else
            animation.SetBool("Left", false);

        if (Input.GetKey(KeyCode.D))
            animation.SetBool("Right", true);
        else
            animation.SetBool("Right", false);
    }
}
