using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{


    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        // Debug.Log("Wsg" + GameManager.instance.CharIndex);
        // this is how we can transfer data from one scene to another scene.

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (!player)
            return; 
        // this will check for when the player object is destroyed, it will exit the update function once it detects this.

        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;


        transform.position = tempPos;
        
    }
}
