using UnityEngine;
using GS.Data;

namespace GS.GameSystem
{
    public class Service : MonoBehaviour
    {
        private static GameObject container;
        private static Service instance;
        private ScenarioService scenarioService;

        public static Service Instance
        {
            get
            {
                if (!container)
                {
                    container = new GameObject();
                    container.name = "GameSystem";
                    instance = container.AddComponent(typeof(Service)) as Service;
                }
                return instance;
            }
        }

        public ScenarioService ScenarioService
        {
            get
            {
                if (scenarioService == null)
                    scenarioService = new ScenarioService(new ScenarioDataHelper());

                return scenarioService;
            }
        }
    }
}