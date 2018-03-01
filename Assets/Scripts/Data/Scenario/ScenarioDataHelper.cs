using System.IO;
using UnityEngine;
using GS.Scenario;

namespace GS.Data
{
    public class ScenarioDataHelper : IDataHelper
    {
        public IData[ ] Data { get; private set; }

        public void Load()
        {
            string jsonString = File.ReadAllText(Application.dataPath + ScenarioDataModel.Path);
            Data = JsonHelper.FromJson<ScenarioModel>(jsonString);
        }
    }
}