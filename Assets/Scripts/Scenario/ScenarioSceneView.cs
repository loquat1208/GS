using UnityEngine;
using UnityEngine.UI;

namespace GS.Scenario
{
    public class ScenarioSceneView : MonoBehaviour
    {
        [SerializeField] private Text Name;
        [SerializeField] private Text Line;
        [SerializeField] private Image Bg;
        
        public bool IsTouch { get { return Input.GetMouseButtonDown(0); } }

        public void Draw(ScenarioSceneModel[ ] scenes, int num)
        {
            Name.text = scenes[num].Name;
            Line.text = scenes[num].Line;
            Bg.sprite = scenes[num].Bg;
        }
    }
}