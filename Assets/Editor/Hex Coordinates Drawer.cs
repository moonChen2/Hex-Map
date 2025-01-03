using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(HexCoordinates))]
public class HexCoordinatesDrawer : PropertyDrawer
{
    public override void OnGUI(
        Rect position, SerializedProperty property, GUIContent label)
    {
        HexCoordinates coordinates = new HexCoordinates(
            property.FindPropertyRelative("x").intValue,
            property.FindPropertyRelative("z").intValue);
        Debug.Log(label.ToString());
        //这里和教程不一样 unity 的api有所更新
        position = EditorGUI.PrefixLabel(position,GUIUtility.GetControlID(FocusType.Passive),label);
        
        GUI.Label(position,coordinates.ToString());
    }
}