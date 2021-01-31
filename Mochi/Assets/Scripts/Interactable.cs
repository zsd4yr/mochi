using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    //public Camera cam;
    [ShowOnly]
    public GameObject robot;

    [ShowOnly]
    public bool isWithinBounds = false;

    [ShowOnly]
    public Material CommandRangeMaterial;

    [ShowOnly]
    public Material HighlightMaterial;

    private MeshRenderer GOMeshRenderer;

    [ShowOnly]
    public string ShaderTransparencyPropertyName = "Vector1_E165039D";

    [ShowOnly]
    public string ShaderColorPropertyName = "Color_696C87FA";

    [ShowOnly]
    public string ShaderColorSizePropertyName = "Vector1_11CC1B9D";

    public float AnimationTime;

    [ShowOnly]
    public float AnimationProgressTime;

    [ShowOnly]
    public float AnimationPercentage;

    public float MaximumTransparency;

    public float MaximumCircleSize;

    [ShowOnly]
    public float DesiredCurrentTransparency;

    [ShowOnly]
    public float DesiredCurrentCircleSize;

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
            var mats = this.GOMeshRenderer.materials.ToList();
            mats.Add(this.HighlightMaterial);
            this.GOMeshRenderer.materials = mats.ToArray();


            this.DesiredCurrentTransparency = 0.0f;
            this.DesiredCurrentCircleSize = 0.0f;
            this.CommandRangeMaterial.SetFloat(this.ShaderTransparencyPropertyName, this.DesiredCurrentTransparency);
            this.CommandRangeMaterial.SetFloat(this.ShaderColorSizePropertyName, this.DesiredCurrentCircleSize);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerController.PlayerTag))
        {
            this.isWithinBounds = false;
            var mats = new[] { this.GOMeshRenderer.materials.First() };
            this.GOMeshRenderer.materials = mats;
            StartCoroutine(LurePlayerWithinBounds(this.AnimationTime));
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        this.GOMeshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        this.robot = GameObject.FindGameObjectWithTag(RobotController.RobotTag);
        this.CommandRangeMaterial = this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0];
        this.HighlightMaterial = Resources.Load(@"Materials/highlightMaterial") as Material;
        StartCoroutine(LurePlayerWithinBounds(this.AnimationTime));
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && isWithinBounds == true)
        {
            Debug.Log("I have been interacted with!");
        }
    }

    IEnumerator LurePlayerWithinBounds(float animationTime)
    {
        while (!this.isWithinBounds)
        {
            this.AnimationProgressTime = 0;
            var halfAnimation = animationTime / 2;
            while (this.AnimationProgressTime < animationTime && !this.isWithinBounds)
            {
                this.AnimationProgressTime += Time.deltaTime;

                this.AnimationPercentage = Mathf.Clamp01(this.AnimationProgressTime / animationTime);

                // expanding
                if (this.AnimationPercentage <= 0.5f)
                {
                    this.DesiredCurrentTransparency = Mathf.Lerp(0.0f, this.MaximumTransparency, Mathf.Clamp01(this.AnimationPercentage / 0.5f));
                    this.DesiredCurrentCircleSize = Mathf.Lerp(0.0f, this.MaximumCircleSize, Mathf.Clamp01(this.AnimationPercentage / 0.5f));
                }
                //contracting
                else
                {
                    this.DesiredCurrentTransparency = Mathf.Lerp(this.MaximumTransparency, 0.0f, Mathf.Clamp01((this.AnimationPercentage - 0.5f) / 0.5f));
                    this.DesiredCurrentCircleSize = Mathf.Lerp(this.MaximumCircleSize, 0.0f, Mathf.Clamp01((this.AnimationPercentage - 0.5f) / 0.5f));
                }

                this.CommandRangeMaterial.SetFloat(this.ShaderTransparencyPropertyName, this.DesiredCurrentTransparency);
                this.CommandRangeMaterial.SetFloat(this.ShaderColorSizePropertyName, this.DesiredCurrentCircleSize);

                yield return null;
            }
        }

        yield return null;
    }
}
