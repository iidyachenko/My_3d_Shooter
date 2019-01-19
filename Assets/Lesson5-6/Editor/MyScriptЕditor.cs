//using GeekBrains;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyScript))]
public class MyScriptЕditor : Editor
{
    bool _isPressButtonOk;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MyScript testTarget = (MyScript)target;

        var isPressButton = GUILayout.Button("Создание объектов по кнопке", EditorStyles.miniButton);

        if (isPressButton)
        {
            testTarget.CreateObj();
            _isPressButtonOk = true;
        }

        if (_isPressButtonOk)
        {
            EditorGUILayout.HelpBox("Вы нажали на кнопку", MessageType.Warning);
        }
    }
}
