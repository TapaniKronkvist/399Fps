using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{

    [SerializeField] List <GameObject> roomOnline;
    [SerializeField] List <GameObject> roomOffline;

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            for (int i = 0; i < roomOnline.Count; i++)
            {
                roomOnline[i].SetActive(true);
            }
            for (int i = 0; i < roomOffline.Count; i++)
            {
                roomOffline[i].SetActive(false);
            }
        }
    }

}
