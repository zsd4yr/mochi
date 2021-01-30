using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

[Serializable]
public class DialogueEncounter 
{
    public static string DialougeEncountersTag = @"Encounters";
    
    public string Tag { get; private set; }

    public List<DialogueSnippet> Dialogues { get; private set; }

    public int TimesRead { get; private set; }

    public DialogueEncounter()
    {
        this.Tag = "[none]";
        this.Dialogues = new List<DialogueSnippet>();
        this.TimesRead = 0;
    }

    public void ReadXML(XmlNode node)
    {
        Debug.Assert(node != null, "Node may not be null");

        this.Tag = node.Attributes[nameof(this.Tag)].Value;

        foreach (XmlNode dialogueNode in node.ChildNodes)
        {
            var snippet = new DialogueSnippet();
            snippet.ReadXML(dialogueNode);
            this.Dialogues.Add(snippet);
        }
    }
}
