using Geekbrains.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LabirintGenerate))]
public class labirintGenerateEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LabirintGenerate Target = (LabirintGenerate)target;

        var isPressButton = GUILayout.Button("Сгенирировать лабирин", EditorStyles.miniButton);

        if (isPressButton)
        {
            Target.ObjGenerate(Target.Prefub,Target.sizeRows,Target.sizeColumns);
        }
    }
}
