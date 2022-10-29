using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UnityEditor.GameSceneController.Editor
{
    
    public class ScenesControllerEditor : EditorWindow
    {
        private readonly string parentDirect = "Assets/Scenes";
        [MenuItem("Window/Scenes Stage")]
        private static void ShowWindow()
        {
            var window = GetWindow<ScenesControllerEditor>();
            window.titleContent = new GUIContent("Scenes");
            window.Show();
        }

        private void OnGUI()
        {
            var skin = AssetDatabase.LoadAssetAtPath<GUISkin>(
                "Assets/Scripts/UnityEditor/GameSceneController/GUISkin.guiskin");
       
           GUILayout.Box("Assets/Scenes",skin.box);
            var filesName = Directory.GetFiles(parentDirect,"*.unity");
            for (int i = 0; i < filesName.Length; i++)
            {
                var f = new FileInfo(filesName[i]);
                if(GUILayout.Button(f.Name.Remove(f.Name.Length-6,6),skin.button))
                    LoadScene(filesName[i]);
            }
        }

        void LoadScene(string path)
        {
            var modified = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            if (modified)
                EditorSceneManager.OpenScene(path);

        }
    }
}