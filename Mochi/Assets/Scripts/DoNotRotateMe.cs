using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotRotateMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.eulerAngles = Vector3.zero;
        this.gameObject.transform.localEulerAngles = Vector3.zero;
    }
}
