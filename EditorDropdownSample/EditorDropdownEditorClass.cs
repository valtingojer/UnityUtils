using UnityEditor;
using UnityEngine;
using System.Reflection;
using System.Linq;
using Newtonsoft.Json;

[CustomEditor(typeof(EditorDropdownMainClass), true)]

public class EditorDropdownEditorClass : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlayerPrefs.SetString("AssemblyTypes", JsonConvert.SerializeObject(Assembly.GetExecutingAssembly().GetTypes().ToList()));

        EditorDropdownMainClass script = (EditorDropdownMainClass)target;

        GUIContent NamespaceList = new GUIContent("Namespace");
        script.NamespaceIndex = EditorGUILayout.Popup(NamespaceList, script.NamespaceIndex, script.Namespaces.ToArray());

        GUIContent ClassList = new GUIContent("Class");
        script.ClassIndex = EditorGUILayout.Popup(ClassList, script.ClassIndex, script.Classes.ToArray());

        GUIContent MethodList = new GUIContent("Method");
        script.MethodIndex = EditorGUILayout.Popup(MethodList, script.MethodIndex, script.Methods.ToArray());
    }
}
