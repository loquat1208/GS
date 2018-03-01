using UnityEngine;
using GS.Scenario;

namespace GS.GameSystem
{
    public class ScenarioService : MonoBehaviour
    {
        private readonly IDataHelper scenarioDataHelper;

        public ScenarioService(IDataHelper scenarioDataHelper)
        {
            if (scenarioDataHelper == null)
                throw new System.ArgumentNullException("scenarioDataHelper");

            this.scenarioDataHelper = scenarioDataHelper;
        }

        public ScenarioModel[ ] Scenario
        {
            get
            {
                if (scenarioDataHelper.Data == null)
                    scenarioDataHelper.Load();

                return (ScenarioModel[ ])scenarioDataHelper.Data;
            }
        }
    }
}
