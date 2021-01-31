using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Text dialogueBox;
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
        float elapsedSpeaker = 0.0f;
        float elapsedCharacter = 0.0f;

        if (displayDialogue != null)
        {

            for (int i = 0; i < displayDialogue.Dialogues.Count; i++)
            {
                while (elapsedSpeaker < duration)
                {
                    dialogueBox.text = displayDialogue.Dialogues[i].Speaker + Environment.NewLine;
                    while (elapsedCharacter < characterDelay)
                    {
                        for (int j = 0; j < displayDialogue.Dialogues[i].Message.Length; j++)
                        {
                            //if (displayDialogue != null)
                            //{
                            dialogueBox.text += displayDialogue.Dialogues[i].Message[j];
                            elapsedCharacter = 0.0f;
                            //diologueBox.text += displayDialogue.Dialogues[i].Message;
                            //}
                            //else
                            //{
                            //    dialogueBox.text = "";
                            //}
                            elapsedSpeaker += Time.deltaTime;
                            elapsedCharacter += Time.deltaTime;
                            yield return null;
                        }
                        elapsedSpeaker = 0.0f;
                    }
                }

                dialogueBox.text = "";
                yield return null;
            }
        }
    }

}
