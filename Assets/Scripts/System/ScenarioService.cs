using GS.Scenario;
using GS.Data;

namespace GS.GameSystem
{
    public class ScenarioService : IService
    {
        private readonly IDataHelper scenarioDataHelper;

        public ScenarioService(IDataHelper scenarioDataHelper)
        {
            if (scenarioDataHelper == null)
                throw new System.ArgumentNullException("scenarioDataHelper");

            this.scenarioDataHelper = scenarioDataHelper;
        }

        public ScenarioSceneModel[ ] Scenes
        {
            get
            {
                if (scenarioDataHelper.Data == null)
                    scenarioDataHelper.Load();

                return (ScenarioSceneModel[ ])scenarioDataHelper.Data;
            }
        }
    }
}
