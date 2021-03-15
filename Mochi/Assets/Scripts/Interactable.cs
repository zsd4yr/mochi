﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    GameControls controls;
    RespawnManager m_RespawnManager;
    //public Camera cam;
    [ShowOnly]
    public GameObject RobotGO;

    [ShowOnly]
    public bool isWithinBounds = false;

    [ShowOnly]
    public Material CommandRangeMaterialChildComponent;

    [ShowOnly]
    public Material HighlightMaterial;

    [ShowOnly]
    public Material[] StartingMaterials;

    private MeshRenderer MeshRendererComponent;

    [ShowOnly]
    public GameObject RobotInputScreenGO;
    private Canvas RobotInputScreen;

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

    private bool isEkeyPressed = false;

    //Respawner number. -1 or less means it won't be called or detected.
    public GameObject MyRespawnObject;
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

            var mats = new List<Material>();
            mats.Add(this.HighlightMaterial);
            mats.AddRange(this.StartingMaterials);
            this.MeshRendererComponent.materials = mats.ToArray();

            this.DesiredCurrentTransparency = 0.0f;
            this.DesiredCurrentCircleSize = 0.0f;
            this.CommandRangeMaterialChildComponent.SetFloat(this.ShaderTransparencyPropertyName, this.DesiredCurrentTransparency);
            this.CommandRangeMaterialChildComponent.SetFloat(this.ShaderColorSizePropertyName, this.DesiredCurrentCircleSize);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerController.PlayerTag))
        {
            this.isWithinBounds = false;

            this.MeshRendererComponent.materials = this.StartingMaterials;
            this.RobotInputScreen.enabled = false;

            CameraController.Instance().ShowIsometricView();

            StartCoroutine(LurePlayerWithinBounds(this.AnimationTime));
        }
    }

    private void Awake()
    {
        m_RespawnManager = FindObjectOfType<RespawnManager>().GetComponent<RespawnManager>();
        if (m_RespawnManager == null)
            Debug.LogError("Respawn Manager not properly found or assigned");
        controls = new GameControls();
        controls.GameController.Interact.performed += ctx => wasEkeyPressedThisFrame();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        this.RobotInputScreenGO = GameObject.FindGameObjectWithTag(RobotInputScreenController.RobotInputScreenTag);
        this.RobotInputScreen = this.RobotInputScreenGO.GetComponent<Canvas>();

        this.MeshRendererComponent = this.gameObject.GetComponent<MeshRenderer>();
        this.RobotGO = GameObject.FindGameObjectWithTag(RobotController.RobotTag);
        this.CommandRangeMaterialChildComponent = this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0];
        this.HighlightMaterial = Resources.Load(@"Materials/highlightMaterial") as Material;
        this.StartingMaterials = this.MeshRendererComponent.materials;
        StartCoroutine(LurePlayerWithinBounds(this.AnimationTime));
    }

    void wasEkeyPressedThisFrame()
    {
        isEkeyPressed = true;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Keyboard.current.eKey.wasPressedThisFrame && isWithinBounds == true)
        if (isWithinBounds && (isEkeyPressed || Keyboard.current.eKey.wasPressedThisFrame))
        {
            //Debug.Log("I have been interacted with!");
            this.RobotInputScreen.enabled = true;
            CameraController.Instance().ShowTopDownView();
            m_RespawnManager.SwitchCurrentPlatformTo(MyRespawnObject);
            isEkeyPressed = false;
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

                this.CommandRangeMaterialChildComponent.SetFloat(this.ShaderTransparencyPropertyName, this.DesiredCurrentTransparency);
                this.CommandRangeMaterialChildComponent.SetFloat(this.ShaderColorSizePropertyName, this.DesiredCurrentCircleSize);

                yield return null;
            }
        }

        yield return null;
    }
}
