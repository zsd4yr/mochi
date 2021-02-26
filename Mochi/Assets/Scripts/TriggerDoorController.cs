using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    public GameObject door;
    bool openTrigger = false;
    public float speed = 10f;
    public float scale = 0.1f;
    public float growthRate = 0.1f;
    float minSize = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Robot" || other.gameObject.CompareTag("Robot"))
        {
            openTrigger = true;
        }
    }

    private void Update()
    {
        if (door != null)
        {
            if (openTrigger)
            {
                scale = growthRate * Time.deltaTime;
                //door.transform.Translate(Vector3.down * Time.deltaTime * speed);
                door.transform.localScale = new Vector3(0, 1f, 0) * scale;
                if (scale <= minSize) Destroy(door);
            }
        }
    }

}
