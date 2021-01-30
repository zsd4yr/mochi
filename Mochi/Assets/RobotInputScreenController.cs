using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RobotInputScreenController : MonoBehaviour
{
    public Button DownButton;
    public Button LeftButton;
    public Button RightButton;
    public Button UpButton;
    public Button ExecuteButton;

    public TextMeshProUGUI InputFeedbackDisplay;

    private GameObject Robot;
    private RobotController RobotController;

    private List<string> FeedbackLines;
    private static readonly string MultiCommandLinePattern = "{0} x {1}";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(this.DownButton != null, $"{nameof(this.DownButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.LeftButton != null, $"{nameof(this.LeftButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.RightButton != null, $"{nameof(this.RightButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.UpButton != null, $"{nameof(this.UpButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.ExecuteButton != null, $"{nameof(this.ExecuteButton)} cannot be null upon start. Please hook it up to {this.gameObject.name}");
        Debug.Assert(this.InputFeedbackDisplay != null, $"{nameof(this.InputFeedbackDisplay)} cannot be null upon start. Please hook it up to {this.gameObject.name}");

        this.Robot = GameObject.FindGameObjectWithTag(RobotController.RobotTag).gameObject;
        this.RobotController = this.Robot.GetComponent<RobotController>();
        this.FeedbackLines = new List<string>();
    }

    public void OnDownButtonClicked()
        => OnDirectionButtonClicked(Vector3.down, "Down");

    public void OnLeftButtonClicked()
        => OnDirectionButtonClicked(Vector3.left, "Left");

    public void OnRightButtonClicked()
        => OnDirectionButtonClicked(Vector3.forward, "Right");

    public void OnUpButtonClicked()
        => OnDirectionButtonClicked(Vector3.up, "Up");

    public void OnExecuteButtonClicked()
    {
        this.RobotController.OnExecuteQueue();
    }

    private void OnDirectionButtonClicked(Vector3 direction, string newText)
    {
        var newPosition = this.Robot.transform.position + direction;

        UpdateFeedbackText(newText);

        this.RobotController.EnqueueCommand(new RobotMoveCommand(newPosition, Vector3.zero));
    }

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
                    lastLine = string.Format(MultiCommandLinePattern, newText, "2");
                }
                else
                {
                    var lastCount = int.Parse(lastLineParts[1]);
                    lastLine = string.Format(MultiCommandLinePattern, newText, (lastCount + 1).ToString());
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
