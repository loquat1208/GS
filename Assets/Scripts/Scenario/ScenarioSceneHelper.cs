using GS.GameSystem;
using GS.Data;

namespace GS.Scenario
{
    public class ScenarioSceneHelper
    {
        public static ScenarioSceneDataModel[ ] Scenes { get { return Service.Instance.ScenarioService.Scenes; } }
        public static int LastSceneNum { get { return Scenes.Length - 1; } }
    }
}