using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOverShoulder : MonoBehaviour
{
    public GameObject player;
    Vector3 offset = new Vector3() { x = 0, y = 1, z = -2 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
