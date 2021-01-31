using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogueController))]
class EditorDialogueTagGUIPopup : Editor
{
    public static string ResourcesRelativeDialogueXMLFilePath = "Dialogue";

    List<string> AvailableTags;

    public override void OnInspectorGUI()
    {
        Debug.Assert(!string.IsNullOrEmpty(ResourcesRelativeDialogueXMLFilePath), $"{nameof(ResourcesRelativeDialogueXMLFilePath)} cannot be null or empty. Please provide one.");
        this.AvailableTags = new List<string>();

        var text = (TextAsset)Resources.Load(ResourcesRelativeDialogueXMLFilePath);
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(text.text);

        var encounters = xmlDoc.SelectSingleNode($@"//{DialogueEncounter.DialougeEncountersTag}");

        foreach (XmlNode encounterXml in encounters.ChildNodes)
        {
            var encounter = new DialogueEncounter();
            encounter.ReadXML(encounterXml);

            this.AvailableTags.Add(encounter.Tag);
        }

        DialogueController controller = (DialogueController)target;

        controller.DialogueTag = this.AvailableTags[EditorGUILayout.Popup("Dialogue Tag", 
            this.AvailableTags.IndexOf(controller.DialogueTag), 
            this.AvailableTags.ToArray())]; 

        controller.TimeToDisplayEachSentenceSeconds = EditorGUILayout.FloatField(nameof(controller.TimeToDisplayEachSentenceSeconds), controller.TimeToDisplayEachSentenceSeconds);
        controller.TimeToDisplayEachCharSeconds = EditorGUILayout.FloatField(nameof(controller.TimeToDisplayEachCharSeconds), controller.TimeToDisplayEachCharSeconds);
        controller.TimeToDisplayEachTerminatingCharSeconds = EditorGUILayout.FloatField(nameof(controller.TimeToDisplayEachTerminatingCharSeconds), controller.TimeToDisplayEachTerminatingCharSeconds);

        EditorGUILayout.FloatField(nameof(controller.DefaultTimeToDisplayEachSentenceSeconds), controller.DefaultTimeToDisplayEachSentenceSeconds);

        EditorUtility.SetDirty(controller);
    }
}