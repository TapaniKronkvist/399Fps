using UnityEngine;

//This is a hit effect done by a weapon. Instaciate on hit with raycast. Not complete
public class hitEffect : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1);
    } //Only destroy this game object.
}
