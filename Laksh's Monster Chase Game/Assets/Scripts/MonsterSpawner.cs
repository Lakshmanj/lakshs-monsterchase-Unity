using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{


    [SerializeField]
    private GameObject[] monsterReference; // going to create copies of each of the enemies.

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;


    // This will determine the random sides that the monster will be spawned
    // and determine the index of the spawned monster
    private int randomIndex;
    private int randomSide;

    private void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    { // this is a coroutine

        while (true) // when the execution enters this loop, it will loop that code over and over
        {
            yield return new WaitForSeconds(Random.Range(1, 5)); // executes every 1-5 seconds
            /* 
             Typically, a while true loop executes code very quickly, but with the yield return function
            the monsters spawning will not be as frequent. Since a coroutine needs to wait, there won't be an
            issue of making the computer crash due to the while loop.
             */

            randomIndex = Random.Range(0, monsterReference.Length);
            // this will give us a random index between 0 and the array's length, minus 1.

            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            // the instantiate function will create a copy of a game object that we pass in here as a reference
            // it will then return 1,2, or 3 for the enemy game objects.


            // left side
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4,10);
            }
            else
            {
                //right side
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f,1f,1f);
                /* we need the value to be negative since we want the monsters spawning from the right side
                 * to go towards the left.*/
            }

        } // while true loop



    }
} // Class 
