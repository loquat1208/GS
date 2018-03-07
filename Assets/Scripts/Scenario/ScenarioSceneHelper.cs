using UnityEngine;
using GS.GameSystem;
using GS.Data;

namespace GS.Scenario
{
    public class ScenarioSceneHelper
    {
        public ScenarioSceneModel[ ] Scenes { get { return scenes; } }
        public int LastSceneNum { get { return Scenes.Length - 1; } }
        public int CurrentNum { get; set; }

        private ScenarioSceneModel[ ] scenes;

        public ScenarioSceneHelper()
        {
            CurrentNum = 0;
            CreateSceneModel();
        }

        private void CreateSceneModel()
        {
            ScenarioService service = Service.Instance.Services[Service.Type.Scenario] as ScenarioService;
            ScenarioSceneDataModel[ ] data = service.LoadScenesData();
            scenes = new ScenarioSceneModel[data.Length];

            for (int i = 0; i < scenes.Length; i++)
            {
                ScenarioSceneModel scene = new ScenarioSceneModel();
                scene.Name = data[i].Name;
                scene.Line = data[i].Line;
                scene.Bg = Resources.Load<Sprite>(data[i].BgPath);
                scenes[i] = scene;
            }
        }
    }
}