using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GS.Data;

namespace GS.Editor
{
    public class ScenarioEditor : EditorWindow
    {
        private ScenarioEditorHelper helper = new ScenarioEditorHelper();
        private List<ScenarioSceneDataModel> editScenes = new List<ScenarioSceneDataModel>();
        private ScenarioSceneDataModel editScene = new ScenarioSceneDataModel();
        private string message = string.Empty;
        private int currentSceneNum;
        private Object bg;

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
            int maxScene = editScenes.Count > 0 ? editScenes.Count - 1 : 0;
            currentSceneNum = EditorGUILayout.IntSlider(currentSceneNum, 0, maxScene);
            if (GUILayout.Button("Load")) Load();

            GUILayout.Label("Scene Control", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Scene Edit")) Edit();
            if (GUILayout.Button("Scene Add")) Add();
            if (GUILayout.Button("Scene Delete")) Delete();
            GUILayout.EndHorizontal();

            GUILayout.Label("Scene Setting", EditorStyles.boldLabel);
            editScene.Name = EditorGUILayout.TextField("Name", editScene.Name);
            EditorGUILayout.PrefixLabel("Line");
            editScene.Line = EditorGUILayout.TextArea(editScene.Line, GUILayout.MinHeight(50));
            bg = EditorGUILayout.ObjectField("Background", bg, typeof(Sprite), true);
            editScene.BgPath = (bg != null) ? helper.GetObjectResourcesPath(bg) : string.Empty;

            GUILayout.EndScrollView();
        }

        private void Load()
        {
            editScenes = helper.LoadScenes();
            editScene = editScenes[currentSceneNum];
            bg = Resources.Load<Sprite>(editScene.BgPath);
            message = "장면 불러오기를 완료했습니다.";
        }

        private void Edit()
        {
            editScenes[currentSceneNum] = editScene;
            helper.SaveScenes(editScenes);
            message = "장면을 수정했습니다.";
        }

        private void Add()
        {
            ScenarioSceneDataModel scene = new ScenarioSceneDataModel();
            scene = editScene;
            helper.AddScene(editScenes, scene).SaveScenes(editScenes);
            message = "장면을 추가했습니다.";
        }

        private void Delete()
        {
            helper.DeleteScene(editScenes, currentSceneNum).SaveScenes(editScenes);
            message = "장면을 삭제했습니다.";
        }
    }
}
