using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    SpawerTamplats roomTamplats;

    void Start()
    {
        roomTamplats = GameObject.FindGameObjectWithTag("Rooms").GetComponent<SpawerTamplats>();
        roomTamplats.rooms.Add(this.gameObject);
    }
}
