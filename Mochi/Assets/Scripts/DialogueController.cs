using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Text diologueBox;
    public string dialogueTag;

    DialogueEncounter displayDialogue;

    private void OnTriggerEnter(Collider other)
    {
        
        displayDialogue = GetComponent<DialogueManager>().TagsToEncounters[dialogueTag];
    }

    private void OnTriggerExit(Collider other)
    {
        displayDialogue = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (displayDialogue != null)
        {
            foreach (var t in displayDialogue.Dialogues)
            {
                diologueBox.text += t.Message;
            }
        }
        else
        {
            diologueBox.text = "";
        }
    }
}
