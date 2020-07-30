using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int opeingDir;
    private SpawerTamplats roomSpawner;
    private bool spawned = false;

    private float waitTime = 4f;
    private void Start()
    {
        Destroy(gameObject, waitTime);
        roomSpawner = GameObject.FindGameObjectWithTag("Rooms").GetComponent<SpawerTamplats>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn()
    {
        if (!spawned)
        {
            if (opeingDir == 1)
            {
                //spawn a Room with bot door
                int rand = Random.Range(1, roomSpawner.bot_Rooms.Length);
                Instantiate(roomSpawner.bot_Rooms[rand], transform.position, roomSpawner.bot_Rooms[rand].transform.rotation);
            }
            else if (opeingDir == 2)
            {
                //spawn a Room with left door 
                int rand = Random.Range(1, roomSpawner.left_Rooms.Length);
                Instantiate(roomSpawner.left_Rooms[rand], transform.position, roomSpawner.left_Rooms[rand].transform.rotation);
            }
            else if (opeingDir == 3)
            {
                //Spawn a Room with right door
                int rand = Random.Range(1, roomSpawner.right_Rooms.Length);
                Instantiate(roomSpawner.right_Rooms[rand], transform.position, roomSpawner.right_Rooms[rand].transform.rotation);
            }
            else if (opeingDir == 4)
            {
                //Spawn a Room with top door
                int rand = Random.Range(1, roomSpawner.top_Rooms.Length);
                Instantiate(roomSpawner.top_Rooms[rand], transform.position, roomSpawner.top_Rooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    void SpawnBlock()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spawnPoint"))
        {
            /*if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(roomSpawner.closedRoom, transform.position, Quaternion.identity);

            }*/

            Destroy(gameObject);
            spawned = true;
        }
    }
}
