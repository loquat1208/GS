using System.IO;
using UnityEngine;

namespace GS.Data
{
    public class ScenarioDataHelper : IDataHelper
    {
        public IData[ ] Data { get; private set; }

        public void Load()
        {
            string jsonString = File.ReadAllText(Application.dataPath + ScenarioDataModel.Path);
            Data = JsonHelper.FromJson<ScenarioSceneDataModel>(jsonString);
        }
    }
}