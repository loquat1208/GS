using System.Collections.Generic;
using UnityEngine;
using GS.Data;

namespace GS.GameSystem
{
    public class Service : MonoBehaviour
    {
        public enum Type
        {
            Scenario,
        }

        private static GameObject container;
        private static Service instance;

        public IDictionary<Type, IService> Services { get; private set; }

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

        private Service()
        {
            Services = new Dictionary<Type, IService>();
            Services.Add(Type.Scenario, new ScenarioService(new ScenarioDataHelper()));
        }
    }
}