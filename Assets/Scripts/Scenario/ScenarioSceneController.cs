using UnityEngine;

namespace GS.Scenario
{
    public class ScenarioSceneController : MonoBehaviour
    {
        [SerializeField] private ScenarioSceneView view;

        private ScenarioSceneHelper helper;

        private void Start()
        {
            helper = new ScenarioSceneHelper();
            view.Draw(helper.Scenes, helper.CurrentNum);
        }

        private void Update()
        {
            if (view.IsTouch)
            {
                // TODO: 나중에 시나리오가 끝나면 엔딩화면으로 넘어가도록 수정
                if (helper.CurrentNum < helper.LastSceneNum)
                    helper.CurrentNum++;

                view.Draw(helper.Scenes, helper.CurrentNum);
            }
        }
    }
}
