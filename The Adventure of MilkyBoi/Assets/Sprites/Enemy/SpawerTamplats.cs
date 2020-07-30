using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawerTamplats : MonoBehaviour
{
    public GameObject[] bot_Rooms, top_Rooms, left_Rooms, right_Rooms;
    public GameObject lblock, tblock, bblock, rblock;
    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    

    private void Update()
    {
        if(waitTime <= 0 && !spawnedBoss)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

}
