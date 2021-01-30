using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera IsometricCamera;
    public Camera TopDownCamera;

    // Start is called before the first frame update
    void Start()
    {
        SwitchViewsFrom(this.TopDownCamera, this.IsometricCamera);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            if (this.IsometricCamera.isActiveAndEnabled)
            {
                ShowTopDownView();
            }
            else
            {
                ShowIsometricView();
            }
        }
    }

    public void ShowIsometricView()
        => SwitchViewsFrom(this.TopDownCamera, this.IsometricCamera);

    public void ShowTopDownView()
        => SwitchViewsFrom(this.IsometricCamera, this.TopDownCamera);

    private static void SwitchViewsFrom(Camera toTurnOff, Camera toTurnOn)
    {
        Debug.Assert(toTurnOff == null, $"Camera {nameof(toTurnOff)} cannot be null");
        Debug.Assert(toTurnOn == null, $"Camera {nameof(toTurnOn)} cannot be null");
        Debug.Assert(toTurnOff.Equals(toTurnOn) || toTurnOff == toTurnOn, $"Cameras to toggle must differ. Given both as {toTurnOn?.name ?? toTurnOn.ToString()}");

        toTurnOff.enabled = false;
        toTurnOn.enabled = true;
    }
}
