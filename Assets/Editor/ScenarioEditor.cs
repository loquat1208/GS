using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GS.Data;

namespace Gs.Editor
{
    public class ScenarioEditor : EditorWindow
    {
        private const string ResourcesPath = "Assets/Resources/";

        private List<ScenarioSceneDataModel> scenes = new List<ScenarioSceneDataModel>();
        private string message;
        private int num;
        private string charaName;
        private string line;
        private Object bg;
        private string bgPath;

        private bool isAutoSave = false;
        private Vector2 editorScrollPos;

        [MenuItem("Scenario/Scenario Editor")]
        static void Init()
        {
            ScenarioEditor window = (ScenarioEditor)GetWindow(typeof(ScenarioEditor));
            window.Show();
        }

        // TODO: 코드 리펙토링
        private void OnGUI()
        {
            editorScrollPos = EditorGUILayout.BeginScrollView(editorScrollPos);

            GUILayout.Label("Debug", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox(message, MessageType.Info);

            GUILayout.Label("Scene Number", EditorStyles.boldLabel);
            int maxScene = scenes.Count > 0 ? scenes.Count - 1 : 0;
            num = EditorGUILayout.IntSlider(num, 0, maxScene);

            GUILayout.Label("Scene Setting", EditorStyles.boldLabel);
            charaName = EditorGUILayout.TextField("Name", charaName);
            EditorGUILayout.PrefixLabel("Line");
            line = EditorGUILayout.TextArea(line, GUILayout.MinHeight(50));
            bg = EditorGUILayout.ObjectField("Background", bg, typeof(Sprite), true);

            GUILayout.Label("Scene Control", EditorStyles.boldLabel);
            isAutoSave = EditorGUILayout.Toggle("Auto Save", isAutoSave);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Scene Edit")) Edit();
            if (GUILayout.Button("Scene Add")) Add();
            if (GUILayout.Button("Scene Delete")) Delete();
            GUILayout.EndHorizontal();

            GUILayout.Label("Data Control", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Save")) Save();
            if (GUILayout.Button("Load")) Load();
            GUILayout.EndHorizontal();

            GUILayout.EndScrollView();
        }

        // TODO: Helper를 만들자!
        private string GetObjectResourcesPath(Object ob)
        {
            string basePath = AssetDatabase.GetAssetPath(ob);
            string folderPath = string.Format("{0}/", Path.GetDirectoryName(basePath).Replace(ResourcesPath, string.Empty));
            string fileTitle = Path.GetFileNameWithoutExtension(basePath);

            return folderPath + fileTitle;
        }

        private void WriteScene(ScenarioSceneDataModel scene)
        {
            scene.Name = charaName;
            scene.Line = line;
            bgPath = GetObjectResourcesPath(bg);
            scene.BgPath = bgPath;
        }

        private void ReadScene(ScenarioSceneDataModel scene)
        {
            charaName = scene.Name;
            line = scene.Line;
            bgPath = scene.BgPath;
            bg = Resources.Load<Sprite>(bgPath);
        }

        private void Edit()
        {
            WriteScene(scenes[num]);

            if (isAutoSave)
                Save();

            message = "장면을 수정하였습니다.";
        }

        private void Add()
        {
            ScenarioSceneDataModel scene = new ScenarioSceneDataModel();
            WriteScene(scene);

            scenes.Add(scene);

            if (isAutoSave)
                Save();

            message = "장면을 추가했습니다.";
        }

        private void Delete()
        {
            scenes.RemoveAt(num);

            message = "장면을 삭제했습니다.";
        }

        private void Save()
        {
            string toJson = JsonHelper.ToJson(scenes.ToArray(), prettyPrint: true);
            File.WriteAllText(Application.dataPath + ScenarioDataModel.Path, toJson);

            message = "저장을 완료하였습니다.";
        }

        private void Load()
        {
            string jsonString = File.ReadAllText(Application.dataPath + ScenarioDataModel.Path);
            List<ScenarioSceneDataModel> data = new List<ScenarioSceneDataModel>();
            data.AddRange(JsonHelper.FromJson<ScenarioSceneDataModel>(jsonString));

            scenes = data;
            ReadScene(scenes[num]);

            message = "장면 불러오기를 완료하였습니다.";
        }
    }
}
