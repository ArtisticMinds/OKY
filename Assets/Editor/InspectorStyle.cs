using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InspectorStyle : EditorWindow
{

	// Use this for initialization
	void Start () {

    }

    void OnGUI()
    { EditorGUILayout.LabelField("Inspector", EditorStyles.boldLabel);
        GUIStyle myFoldoutStyle = new GUIStyle(EditorStyles.foldout);
        Color myStyleColor = Color.blue;
        myFoldoutStyle.fontStyle = FontStyle.Bold;
        myFoldoutStyle.normal.textColor = myStyleColor;
        myFoldoutStyle.onNormal.textColor = myStyleColor;
        myFoldoutStyle.hover.textColor = myStyleColor;
        myFoldoutStyle.onHover.textColor = myStyleColor;
        myFoldoutStyle.focused.textColor = myStyleColor;
        myFoldoutStyle.onFocused.textColor = myStyleColor;
        myFoldoutStyle.active.textColor = myStyleColor;
        myFoldoutStyle.onActive.textColor = myStyleColor;
    }
}
