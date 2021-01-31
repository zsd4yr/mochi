using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
public class ShowOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
    {
        string valueStr;

        switch (prop.propertyType)
        {
            case SerializedPropertyType.Integer:
                valueStr = prop.intValue.ToString();
                break;
            case SerializedPropertyType.Boolean:
                valueStr = prop.boolValue.ToString();
                break;
            case SerializedPropertyType.Float:
                valueStr = prop.floatValue.ToString("0.00000");
                break;
            case SerializedPropertyType.String:
                valueStr = prop.stringValue;
                break;
            case SerializedPropertyType.ObjectReference:
                valueStr = $"{prop.displayName} [{prop.type}]";
                break;
            case SerializedPropertyType.Generic:
                valueStr = $"{prop.displayName} [{prop.type}]";
                break;
            case SerializedPropertyType.Color:
                valueStr = prop.colorValue.ToString();
                break;
            case SerializedPropertyType.LayerMask:
                valueStr = prop.intValue.ToString();
                break;
            case SerializedPropertyType.Enum:
                valueStr = prop.enumValueIndex.ToString();
                break;
            case SerializedPropertyType.Vector2:
                valueStr = prop.vector2Value.ToString();
                break;
            case SerializedPropertyType.Vector3:
                valueStr = prop.vector3Value.ToString();
                break;
            case SerializedPropertyType.Vector4:
                valueStr = prop.vector4Value.ToString();
                break;
            case SerializedPropertyType.Rect:
                valueStr = prop.rectValue.ToString();
                break;
            case SerializedPropertyType.ArraySize:
                valueStr = prop.intValue.ToString();
                break;
            case SerializedPropertyType.Character:
                valueStr = prop.intValue.ToString();
                break;
            case SerializedPropertyType.AnimationCurve:
                valueStr = prop.animationCurveValue.ToString();
                break;
            case SerializedPropertyType.Bounds:
                valueStr = prop.boundsValue.ToString();
                break;
            case SerializedPropertyType.Quaternion:
                valueStr = prop.vector4Value.ToString();
                break;
            case SerializedPropertyType.ExposedReference:
                valueStr = prop.objectReferenceValue.ToString();
                break;
            case SerializedPropertyType.FixedBufferSize:
                valueStr = prop.intValue.ToString();
                break;
            case SerializedPropertyType.Vector2Int:
                valueStr = prop.vector2IntValue.ToString();
                break;
            case SerializedPropertyType.Vector3Int:
                valueStr = prop.vector3IntValue.ToString();
                break;
            case SerializedPropertyType.RectInt:
                valueStr = prop.rectIntValue.ToString();
                break;
            case SerializedPropertyType.BoundsInt:
                valueStr = prop.boundsIntValue.ToString();
                break;
            case SerializedPropertyType.ManagedReference:
                valueStr = prop.objectReferenceValue.ToString();
                break;
            default:
                valueStr = "[unknown type]";
                break;
        }

        EditorGUI.LabelField(position, label.text, valueStr);
    }
}