using System;
using System.Xml;
using UnityEngine;

[Serializable]
public class DialogueSnippet 
{
    public string Speaker { get; private set; }

    public string Message { get; private set; }

    public DialogueSnippet()
    {
        this.Speaker = "[nemo]";
        this.Message = "[ispum lorem]";
    }

    public void ReadXML(XmlNode node)
    {
        Debug.Assert(node != null, "Node may not be null");

        this.Speaker = node?.Attributes[nameof(this.Speaker)]?.Value ?? "[nemo]";
        this.Message = node?.InnerText ?? "[ispum lorem]";
    }
}

