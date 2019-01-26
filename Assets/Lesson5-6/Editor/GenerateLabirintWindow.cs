using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;
namespace Geekbrains.Editor
{
  //  [RequireComponent(typeof(LabirintGenerate))]
    public class GenerateLabirintWindow : EditorWindow
    {

        public GameObject ObjectInstantiate;
        private LabirintGenerate Generator;
        string _nameObject = "Wall";

        int _countRaws = 1;
        int _countColumns = 1;

        [MenuItem("Geekbrains/Labirint generate")]
        public static void ShowWindow()
        {
            // Отобразить существующий экземпляр окна. Если его нет, создаем
            EditorWindow.GetWindow(typeof(GenerateLabirintWindow));
        }
        void OnGUI()
        {
            Generator = FindObjectOfType<LabirintGenerate>();
            GUILayout.Label("Настройки для генерации лабиринта", EditorStyles.boldLabel);
            ObjectInstantiate =
                EditorGUILayout.ObjectField("Префаб для элемента стены", ObjectInstantiate, typeof(GameObject), true)
                    as GameObject;
            _countRaws = EditorGUILayout.IntSlider("Количество объектов", _countRaws, 1, 100);
            _countColumns = EditorGUILayout.IntSlider("Количество объектов", _countColumns, 1, 100);
            if (GUILayout.Button("Создать объекты"))
            {
                Generator.ObjGenerate(ObjectInstantiate, _countRaws, _countColumns);
            }
        }
    }
}
