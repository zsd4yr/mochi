using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Text diologueBox;
    public string dialogueTag;
    public float sentenceDelay = 1.5f;
    public float characterDelay = 0.1f;

    DialogueEncounter displayDialogue;

    private void OnTriggerEnter(Collider other)
    {
        var dialogueManager = GetComponent<DialogueManager>();
        if (dialogueManager.TagsToEncounters.ContainsKey(dialogueTag))
        {
            displayDialogue = dialogueManager.TagsToEncounters[dialogueTag];
            StartCoroutine(DelayedDialogue(sentenceDelay));
        }
        else
        {
            Debug.Log("Dialogue Resource does not contain given tag: " + dialogueTag);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        displayDialogue = null;
    }

    IEnumerator DelayedDialogue(float duration)
    {
        float elapsed = 0.0f;

        for (int i = 0; i < displayDialogue.Dialogues.Count; i++)
        {
            while (elapsed < duration)
            {
                if (displayDialogue != null)
                {
                    diologueBox.text = displayDialogue.Dialogues[i].Speaker + Environment.NewLine + displayDialogue.Dialogues[i].Message;
                }
                else
                {
                    diologueBox.text = "";
                }
                elapsed += Time.deltaTime;

                yield return null;
            }
            elapsed = 0.0f;
        }
        yield return null;
    }

}
