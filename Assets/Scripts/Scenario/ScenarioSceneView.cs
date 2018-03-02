using UnityEngine;
using UnityEngine.UI;

namespace GS.Scenario
{
    public class ScenarioSceneView : MonoBehaviour
    {
        [SerializeField] private Text Name;
        [SerializeField] private Text Line;

        public bool IsTouch { get { return Input.GetMouseButtonDown(0); } }

        public void Draw(int num)
        {
            Name.text = ScenarioSceneHelper.Scenes[num].Name;
            Line.text = ScenarioSceneHelper.Scenes[num].Line;
        }
    }
}