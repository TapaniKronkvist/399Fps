using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    [SerializeField] bool unlocked;
    
    public void Open()
    {
        if (unlocked)
        {
            Debug.Log("Door opened");
        }
        else
        {
            Debug.Log("Door is locked");
        }
    }
}
