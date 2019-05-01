using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravityMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private bool contact;
    [SerializeField] private float xRotation;
    public FpsInput getPlayerGravity;
    [SerializeField] private float playerNormalGravity;
    // Start is called before the first frame update
    void Start()
    {
        playerNormalGravity = getPlayerGravity.gravity;
        contact = false;
        //xRotation = GetComponent<Transform>().rotation.x; 
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            contact = true;
            player = other.transform;
            float y = player.transform.rotation.y;
            float z = player.transform.rotation.z;
            player.transform.localRotation = Quaternion.Euler(new Vector3(xRotation, player.transform.eulerAngles.y, player.transform.eulerAngles.z));
            //player.transform.rotation = Quaternion.Euler(xRotation, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
            getPlayerGravity.gravity = 0;
            Debug.Log(player.transform.rotation);
            print("Player entered");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            contact = false;
            player.transform.rotation = Quaternion.Euler(0, player.transform.eulerAngles.y, 0);
            //getPlayerGravity.gravity = playerNormalGravity;
            //player = null;
            print("Player exit");
        }
    }
}
