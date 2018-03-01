using UnityEngine;
using UnityEngine.UI;
using GS.GameSystem;

namespace GS.Scenario
{
    public class ScenarioView : MonoBehaviour
    {
        [SerializeField] private Text Name;

        private ScenarioModel[ ] Scenario { get { return Service.Instance.ScenarioService.Scenario; } }

        private void Start()
        {
            Name.text = Scenario[0].Name;
        }
    }
}