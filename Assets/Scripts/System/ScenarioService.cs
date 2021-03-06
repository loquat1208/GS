﻿using GS.Data;

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

        public ScenarioSceneDataModel[ ] LoadScenesData()
        {
            if (scenarioDataHelper.Data == null)
                scenarioDataHelper.Load();

            return scenarioDataHelper.Data as ScenarioSceneDataModel[ ];
        }
    }
}
