using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DisposeObject))]
public class DisposeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DisposeObject Target = (DisposeObject)target;

        var isPressButton = GUILayout.Button("Удалить объекты", EditorStyles.miniButton);

        if (isPressButton)
        {
            Target.DisposeTagObject();
        }
    }
}
