using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public static string DialougeScreenTag = "DialogueScreen";

    public string DialogueTag;

    public float DefaultTimeToDisplayEachSentenceSeconds = 2;
    public float DefaultTimeToDisplayEachCharSeconds = 0.05f;
    public float DefaultTimeToDisplayEachTerminatingCharSeconds = 0.2f;

    public float TimeToDisplayEachSentenceSeconds;
    public float TimeToDisplayEachCharSeconds;
    public float TimeToDisplayEachTerminatingCharSeconds;

    [ShowOnly]
    public GameObject DialogueManagerGO;

    [ShowOnly]
    public DialogueManager DialogueManager;

    [ShowOnly]
    public GameObject DialogueBoxGO;

    [ShowOnly]
    public TextMeshProUGUI DialogueBox;

    private readonly char[] TerminatingChars = new[]
    {
        '.',
        ',',
        '?',
        '!'
    };

    void Start()
    {
        this.DialogueManagerGO = GameObject.FindGameObjectWithTag(DialogueManager.DialogueManagerTag);
        this.DialogueManager = DialogueManagerGO.GetComponent<DialogueManager>();

        this.DialogueBoxGO = GameObject.FindGameObjectWithTag(DialogueController.DialougeScreenTag);
        this.DialogueBox = DialogueBoxGO.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        if (this.TimeToDisplayEachSentenceSeconds == 0)
        {
            this.TimeToDisplayEachSentenceSeconds = DefaultTimeToDisplayEachSentenceSeconds;
        }

        if (this.TimeToDisplayEachCharSeconds == 0)
        {
            this.TimeToDisplayEachCharSeconds = DefaultTimeToDisplayEachCharSeconds;
        }

        if (this.TimeToDisplayEachTerminatingCharSeconds == 0)
        {
            this.TimeToDisplayEachTerminatingCharSeconds = DefaultTimeToDisplayEachTerminatingCharSeconds;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.DialogueManager.TagsToEncounters.TryGetValue(this.DialogueTag, out var encounter))
        {
            StartCoroutine(DelayedDialogue(encounter, TimeToDisplayEachSentenceSeconds));
        }
        else
        {
            Debug.Log("Dialogue Resource does not contain given tag: " + DialogueTag);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (this.DialogueManager.TagsToEncounters.TryGetValue(this.DialogueTag, out var encounter))
            {
                StartCoroutine(DelayedDialogue(encounter, TimeToDisplayEachSentenceSeconds));
            }
        }
    }

    IEnumerator DelayedDialogue(DialogueEncounter encounter, float delayPerSnippet)
    {
        float elapsedSpeaker = 0.0f;
        int snippetsDisplayed = 0;

        if (encounter != null)
        {
            while (snippetsDisplayed < encounter.Dialogues.Count)
            {
                if (elapsedSpeaker >= delayPerSnippet)
                {
                    this.DialogueBox.text = encounter.Dialogues[snippetsDisplayed].Speaker + Environment.NewLine;
                    yield return StartCoroutine(DelayedCharacters(
                        encounter.Dialogues[snippetsDisplayed], 
                        this.TimeToDisplayEachCharSeconds, 
                        this.TimeToDisplayEachTerminatingCharSeconds));
                    snippetsDisplayed++;
                    elapsedSpeaker = 0.0f;
                }

                elapsedSpeaker += Time.deltaTime;

                yield return null;
            }
        }
    }

    IEnumerator DelayedCharacters(DialogueSnippet snippet, float delayPerChar, float delayPerTerminatingChar)
    {
        float elapsedCharacter = 0.0f;
        int charsDisplayed = 0;

        if (snippet != null)
        {
            while (charsDisplayed < snippet.Message.Length)
            {
                var previousChar = charsDisplayed > 0 ? snippet.Message[charsDisplayed-1] : snippet.Message[charsDisplayed];
                var nextChar = snippet.Message[charsDisplayed];

                var delay = this.TerminatingChars.ToList().Contains(previousChar) && nextChar != '\"' && nextChar != '”'
                    ? delayPerTerminatingChar
                    : delayPerChar;

                if (elapsedCharacter >= delay)
                {
                    this.DialogueBox.text += snippet.Message[charsDisplayed];
                    charsDisplayed++;
                    elapsedCharacter = 0.0f;
                }

                elapsedCharacter += Time.deltaTime;
                yield return null;
            }
        }
    }

}
