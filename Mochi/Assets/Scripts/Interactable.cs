using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    //public Camera cam;
    [ReadOnly]
    public GameObject robot;

    [ReadOnly]
    public bool isWithinBounds = false;

    [ReadOnly]
    public Material CommandRangeMaterial;

    [ReadOnly]
    public readonly string ShaderTransparencyPropertyName = "Transparency";

    [ReadOnly]
    public readonly string ShaderColorPropertyName = "Color";

    [ReadOnly]
    public readonly string ShaderColorSizePropertyName = "ColorSize";

    public float AnimationTime;
    private float animationProgressTime;

    public float MaximumTransparency;

    public float MaximumCircleSize;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, GetComponent<CapsuleCollider>().radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerController.PlayerTag))
        {
            this.isWithinBounds = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerController.PlayerTag))
        {
            this.isWithinBounds = false;
            StartCoroutine(LurePlayerWithinBounds());
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        this.robot = GameObject.FindGameObjectWithTag(RobotController.RobotTag);
        this.CommandRangeMaterial = this.gameObject.GetComponent<MeshRenderer>().material;
        StartCoroutine(LurePlayerWithinBounds());
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && isWithinBounds == true)
        {

        }


    }

    IEnumerator LurePlayerWithinBounds()
    {
        while (!this.isWithinBounds)
        {
            this.animationProgressTime += Time.deltaTime;
            var halfAnimationTime = this.AnimationTime / 2;

            //expanding
            if (this.animationProgressTime >= halfAnimationTime)
            {
                var transValue = Mathf.Lerp(0, this.MaximumTransparency, this.animationProgressTime / halfAnimationTime);
                //this.CommandRangeMaterial.SetFloat(this.ShaderTransparencyPropertyName, transValue);
            }
            //contracting
            else
            {
                var transValue = Mathf.Lerp(this.MaximumTransparency, 0, (this.animationProgressTime - halfAnimationTime) / halfAnimationTime);
                //this.CommandRangeMaterial.SetFloat(this.ShaderTransparencyPropertyName, transValue);
            }
        }

        yield return null;
    }
}
