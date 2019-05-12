using UnityEngine;

//Door opening mechanic. Not yet finished. Door is currently destroyed on open.
public class DoorMechanics : MonoBehaviour
{
    [SerializeField] bool unlocked;
    
    public void Open()
    {

            Destroy(gameObject);
            Debug.Log("Door opened");
    }
}
