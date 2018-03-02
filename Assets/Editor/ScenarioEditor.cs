﻿using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GS.Data;
using GS.Scenario;

namespace Gs.Editor
{
    public class ScenarioEditor : EditorWindow
    {
        private List<ScenarioSceneModel> scenes = new List<ScenarioSceneModel>();
        private string message;
        private int num;
        private string charaName;
        private string line;

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
            EditorGUILayout.LabelField(message);

            GUILayout.Label("Scene Number", EditorStyles.boldLabel);
            int maxScene = scenes.Count > 0 ? scenes.Count - 1 : 0;
            num = EditorGUILayout.IntSlider(num, 0, maxScene);

            GUILayout.Label("Scene Setting", EditorStyles.boldLabel);
            charaName = EditorGUILayout.TextField("Name", charaName);
            line = EditorGUILayout.TextField("Line", line);

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

        private void WriteScene(ScenarioSceneModel scene)
        {
            scene.Name = charaName;
            scene.Line = line;
        }

        private void ReadScene(ScenarioSceneModel scene)
        {
            charaName = scene.Name;
            line = scene.Line;
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
            ScenarioSceneModel scene = new ScenarioSceneModel();
            WriteScene(scene);

            scenes.Add(scene);

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
            List<ScenarioSceneModel> data = new List<ScenarioSceneModel>();
            data.AddRange(JsonHelper.FromJson<ScenarioSceneModel>(jsonString));

            scenes = data;
            ReadScene(scenes[num]);

            message = "장면 불러오기를 완료하였습니다.";
        }
    }
}
