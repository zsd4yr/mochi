﻿using System;
using System.Collections.Generic;
using System.Xml;
using Unity.Collections;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static string DialogueManagerTag = "DialogueManager";

    public string ResourcesRelativeDialogueXMLFilePath;

    [ShowOnly]
    public List<string> AvailableTags;

    [SerializeField()]
    public DialogueTagToEncountersMap TagsToEncounters;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(!string.IsNullOrEmpty(this.ResourcesRelativeDialogueXMLFilePath), $"{nameof(this.ResourcesRelativeDialogueXMLFilePath)} cannot be null or empty. Please provide one.");
        this.AvailableTags = new List<string>();
        this.TagsToEncounters = new DialogueTagToEncountersMap();

        var text = (TextAsset)Resources.Load(this.ResourcesRelativeDialogueXMLFilePath);
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(text.text);

        var encounters = xmlDoc.SelectSingleNode($@"//{DialogueEncounter.DialougeEncountersTag}");

        foreach (XmlNode encounterXml in encounters.ChildNodes)
        {
            var encounter = new DialogueEncounter();
            encounter.ReadXML(encounterXml);

            Debug.Assert(!TagsToEncounters.TryGetValue(encounter.Tag, out _), $"All Tags must be unique. Tag {encounter.Tag} is already taken.");

            this.AvailableTags.Add(encounter.Tag);
            this.TagsToEncounters.Add(encounter.Tag, encounter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
