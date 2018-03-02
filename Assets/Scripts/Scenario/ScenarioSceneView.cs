using UnityEngine;
using UnityEngine.UI;
using GS.GameSystem;

namespace GS.Scenario
{
    public class ScenarioSceneView : MonoBehaviour
    {
        [SerializeField] private Text Name;
        [SerializeField] private Text Line;

        private ScenarioSceneModel[ ] Scenes { get { return Service.Instance.ScenarioService.Scenes; } }

        private void Start()
        {
            Name.text = Scenes[0].Name;
            Line.text = Scenes[0].Line;
        }
    }
}