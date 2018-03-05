using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using GS.Data;

namespace GS.Editor
{
    public class ScenarioEditorHelper
    {
        private const string ResourcesPath = "Assets/Resources/";

        public ScenarioEditorHelper AddScene(List<ScenarioSceneDataModel> scenes, ScenarioSceneDataModel scene)
        {
            scenes.Add(scene);

            return this;
        }

        public ScenarioEditorHelper DeleteScene(List<ScenarioSceneDataModel> scenes, int sceneNum)
        {
            scenes.RemoveAt(sceneNum);

            return this;
        }

        public ScenarioEditorHelper SaveScenes(List<ScenarioSceneDataModel> scenes)
        {
            string toJson = JsonHelper.ToJson(scenes.ToArray(), prettyPrint: true);
            File.WriteAllText(Application.dataPath + ScenarioDataModel.Path, toJson);

            return this;
        }

        public List<ScenarioSceneDataModel> LoadScenes()
        {
            string jsonString = File.ReadAllText(Application.dataPath + ScenarioDataModel.Path);
            List<ScenarioSceneDataModel> data = new List<ScenarioSceneDataModel>();
            data.AddRange(JsonHelper.FromJson<ScenarioSceneDataModel>(jsonString));

            return data;
        }

        public string GetObjectResourcesPath(Object ob)
        {
            string basePath = AssetDatabase.GetAssetPath(ob);
            string folderPath = string.Format("{0}/", Path.GetDirectoryName(basePath).Replace(ResourcesPath, string.Empty));
            string fileTitle = Path.GetFileNameWithoutExtension(basePath);

            return folderPath + fileTitle;
        }
    }
}
