using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public Canvas RobotInputScreen;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(this.RobotInputScreen != null, $"{nameof(this.RobotInputScreen)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.digit1Key.wasReleasedThisFrame)
        {
            this.RobotInputScreen.enabled = !this.RobotInputScreen.enabled;
        }
    }
}
