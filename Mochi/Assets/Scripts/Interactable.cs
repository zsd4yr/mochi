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

    [ReadOnly]
    public float AnimationProgressTime;

    [ReadOnly]
    public float AnimationPercentage;

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
            //StartCoroutine(LurePlayerWithinBounds());
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        this.robot = GameObject.FindGameObjectWithTag(RobotController.RobotTag);
        this.CommandRangeMaterial = this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0];
        StartCoroutine(LurePlayerWithinBounds(this.AnimationTime));
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && isWithinBounds == true)
        {

        }


    }

    IEnumerator LurePlayerWithinBounds(float animationTime)
    {
        while (!this.isWithinBounds)
        {
            this.AnimationProgressTime = 0;
            var halfAnimation = animationTime / 2;
            while (this.AnimationProgressTime < animationTime)
            {
                this.AnimationProgressTime += Time.deltaTime;

                this.AnimationPercentage = Mathf.Clamp01(this.AnimationProgressTime / animationTime);

                float transparency = 0.0f;
                // expanding
                if (this.AnimationPercentage <= 0.5f)
                {
                    transparency = Mathf.Lerp(0.0f, this.MaximumTransparency, Mathf.Clamp01(this.AnimationPercentage / 0.5f));
                }
                //contracting
                else
                {
                    transparency = Mathf.Lerp(0.0f, this.MaximumTransparency, Mathf.Clamp01((this.AnimationPercentage - 0.5f) / 0.5f));
                }

                this.CommandRangeMaterial.SetFloat(this.ShaderTransparencyPropertyName, transparency);

                yield return null;
            }
        }

        yield return null;
    }
}
