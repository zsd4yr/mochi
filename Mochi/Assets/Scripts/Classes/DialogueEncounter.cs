using System;
using System.Collections.Generic;
using System.Xml;

public class DialogueEncounter 
{
    public static string DialougeEncountersTag = @"Encounters";
    
    public string Tag { get; private set; }

    public List<Tuple<string, string>> Dialogues { get; private set; }

    public int TimesRead { get; private set; }

    public DialogueEncounter()
    {
        this.Tag = "[none]";
        this.Dialogues = new List<Tuple<string, string>>();
        this.TimesRead = 0;
    }

    public void ReadXML(XmlNode node)
    {
        this.Tag = node.Attributes[nameof(this.Tag)].Value;

        foreach (var dialogueNodes in node.ChildNodes)
        {

        }
    }
}
