using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private static CameraController s_Instance;

    public Camera IsometricCamera;
    public Camera TopDownCamera;

    [ReadOnly]
    public Camera CurrentActiveCamera;

    void Awake()
    {
        if (s_Instance != null && s_Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            s_Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.ShowIsometricView();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.vKey.wasReleasedThisFrame)
        {
            if (this.CurrentActiveCamera == IsometricCamera)
            {
                ShowTopDownView();
            }
            else
            {
                ShowIsometricView();
            }
        }
    }

    public static CameraController Instance()
        => s_Instance;

    public Camera GetCurrentCamera()
        => this.CurrentActiveCamera;

    public void ShowIsometricView()
    {
        SwitchViewsFrom(this.TopDownCamera, this.IsometricCamera);
        this.CurrentActiveCamera = this.IsometricCamera;
    }

    public void ShowTopDownView()
    {
        SwitchViewsFrom(this.IsometricCamera, this.TopDownCamera);
        this.CurrentActiveCamera = this.TopDownCamera;
    }

    private static void SwitchViewsFrom(Camera toTurnOff, Camera toTurnOn)
    {
        Debug.Assert(toTurnOff != null, $"Camera {nameof(toTurnOff)} cannot be null");
        Debug.Assert(toTurnOn != null, $"Camera {nameof(toTurnOn)} cannot be null");
        Debug.Assert(!toTurnOff.Equals(toTurnOn) && toTurnOff != toTurnOn, $"Cameras to toggle must differ. Given both as {toTurnOn?.name ?? toTurnOn.ToString()}");

        toTurnOff.enabled = false;
        toTurnOn.enabled = true;
    }
}
