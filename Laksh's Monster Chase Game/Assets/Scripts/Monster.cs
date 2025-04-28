using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector] // we need this variable to be visible in other scripts, but we do not want it to be visible in the inspector tab
    public float speed;

    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        // default speed of the ghost
    }

    private void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }



} // class
