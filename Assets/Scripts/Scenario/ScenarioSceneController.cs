using UnityEngine;

namespace GS.Scenario
{
    public class ScenarioSceneController : MonoBehaviour
    {
        [SerializeField] private ScenarioSceneView view;

        private ScenarioSceneModel model = new ScenarioSceneModel();

        private void Start()
        {
            model.CurrentNum = 0;
            view.Draw(model.CurrentNum);
        }

        private void Update()
        {
            if (view.IsTouch)
            {
                // TODO: 나중에 시나리오가 끝나면 엔딩화면으로 넘어가도록 수정
                if (model.CurrentNum < ScenarioSceneHelper.LastSceneNum)
                    model.CurrentNum++;

                view.Draw(model.CurrentNum);
            }
        }
    }
}
