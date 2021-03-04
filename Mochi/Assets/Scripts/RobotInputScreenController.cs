using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RobotInputScreenController : MonoBehaviour
{
    public static string RobotInputScreenTag = "RobotInputScreen";

    public Button DownButton;
    public Button LeftButton;
    public Button RightButton;
    public Button UpButton;
    public Button ExecuteButton;
    public Button ActionButton;
    public Button WaitButton;
    public Button RespawnButton;

    public TextMeshProUGUI InputFeedbackDisplay;

    [ShowOnly]
    public GameObject Robot;
    [ShowOnly]
    public RobotController RobotController;

    [ShowOnly]
    public GameObject Respawner;
    [ShowOnly]
    public RespawnManager RespawnManager;

    [ShowOnly]
    public List<string> FeedbackLines;

    [ShowOnly]
    private string MultiCommandLinePattern = "{0} x {1}";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(this.DownButton != null, $"{nameof(this.DownButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.LeftButton != null, $"{nameof(this.LeftButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.RightButton != null, $"{nameof(this.RightButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.UpButton != null, $"{nameof(this.UpButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.ExecuteButton != null, $"{nameof(this.ExecuteButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.ActionButton != null, $"{nameof(this.ActionButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        //Debug.Assert(this.WaitButton != null, $"{nameof(this.WaitButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.RespawnButton != null, $"{nameof(this.RespawnButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.InputFeedbackDisplay != null, $"{nameof(this.InputFeedbackDisplay)} cannot be null upon start. Please hook it up to {this.gameObject.name}");

        this.Robot = GameObject.FindGameObjectWithTag(RobotController.RobotTag).gameObject;
        this.RobotController = this.Robot.GetComponent<RobotController>();

        this.Respawner = GameObject.FindGameObjectWithTag(RespawnManager.RespawnManagerTag).gameObject;
        this.RespawnManager = this.Respawner.GetComponent<RespawnManager>();

        this.FeedbackLines = new List<string>();
    }

    public void OnDownButtonClicked()
        => OnDirectionButtonClicked(Vector3.back, "Down");

    public void OnLeftButtonClicked()
        => OnDirectionButtonClicked(Vector3.left, "Left");

    public void OnRightButtonClicked()
        => OnDirectionButtonClicked(Vector3.right, "Right");

    public void OnUpButtonClicked()
        => OnDirectionButtonClicked(Vector3.forward, "Up");

    public void OnExecuteButtonClicked()
    {

        RobotController.Agent.isStopped = false;
        this.RobotController.OnExecuteQueue();

        this.FeedbackLines = new List<string>();
        this.InputFeedbackDisplay.text = "Executing\nCommands...";

        this.gameObject.GetComponent<Canvas>().enabled = false;
        CameraController.Instance().ShowIsometricView();
    }

    public void OnActionButtonClicked()
    {
        Debug.Log("There are no actions yet.");
    }

    public void OnRespawnButtonClicked()
    {
        this.RespawnManager.RespawnRobot();
        //RobotController.Agent.SetDestination(RespawnManager.GetRespawnPlatform().position);
        RobotController.Agent.Warp(RespawnManager.GetRespawnPlatform().position);
        RobotController.Agent.ResetPath();
        RobotController.OnDestroyQueue();
        RobotController.Agent.isStopped = true;
        //note: set requested position to the respawn position
    }

    private void OnDirectionButtonClicked(Vector3 direction, string newText)
    {
        var newPosition = direction * this.RobotController.DirectionMagnitude;

        this.UpdateFeedbackText(newText);

        this.RobotController.EnqueueCommand(new RobotMoveCommand(newPosition));
        //this.RobotController.PlaceMarkerAtSpot(newPosition);
        //note spawn at center and figure out amt of Unity squares. +direction amt + direction amt units you're going. 
    }
    
    //private void OnWaitButtonClicked(string newText)
    //{
    //    this.UpdateFeedbackText(newText);

    //    this.RobotController.EnqueueCommand(new RobotMoveCommand(newPosition));
    //    //note spawn at center and figure out amt of Unity squares. +direction amt + direction amt units you're going. 
    //}

    private void UpdateFeedbackText(string newText)
    {
        if (!this.FeedbackLines.Any())
        {
            this.FeedbackLines.Add(newText);
        }
        else
        {
            var lastLine = this.FeedbackLines[this.FeedbackLines.Count - 1];
            var lastLineParts = lastLine.Split('x').Select(each => each.Trim()).ToArray();
            if (lastLineParts[0] == newText)
            {
                if (lastLineParts.Count() == 1)
                {
                    lastLine = string.Format(this.MultiCommandLinePattern, newText, "2");
                }
                else
                {
                    var lastCount = int.Parse(lastLineParts[1]);
                    lastLine = string.Format(this.MultiCommandLinePattern, newText, (lastCount + 1).ToString());
                }

                this.FeedbackLines[this.FeedbackLines.Count - 1] = lastLine;
            }
            else
            {
                this.FeedbackLines.Add(newText);
            }
        }

        this.InputFeedbackDisplay.text = string.Join("\n", this.FeedbackLines);
    }
}
