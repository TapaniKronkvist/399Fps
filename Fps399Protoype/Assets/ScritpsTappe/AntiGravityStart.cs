using UnityEngine;

//This class in not complete!
public class AntiGravityStart : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private bool contact;
    [SerializeField] private float xRotation;

    
    
    public FpsInput getPlayerGravity;
    [SerializeField] private float playerNormalGravity;

    void Start()
    {
        contact = false;
        xRotation = this.transform.rotation.x;
    }

    private void Update()
    {
        if (contact)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            contact = true;
            player = other.gameObject;
            player.transform.rotation = Quaternion.Euler(xRotation, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
            playerNormalGravity = getPlayerGravity.gravity;
            getPlayerGravity.gravity = 0;
            Debug.Log(player.transform.rotation);
            print("Player entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            player.transform.rotation = Quaternion.Euler(0, player.transform.eulerAngles.y, 0);
            contact = false;
            getPlayerGravity.gravity = playerNormalGravity;
            player = null;
            print("Player exit");
        }
    }
}
