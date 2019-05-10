using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaySound : MonoBehaviour
{
    AudioSource source;
private void Start()
    {
        source = GetComponent<AudioSource>();
        source.pitch = Random.Range(0.8f, 1.0f);
        Destroy(gameObject, 3);
    }
}
