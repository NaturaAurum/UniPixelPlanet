using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetTimeController : PlanetMaterialController
    {
        [SerializeField]
        private float timeScale = 1;
        
        private void UpdateTime()
        {
            UpdateFloat(UniPixelPlanetShaderProps.KeyTime, Time.time * timeScale);
        }

        public void Update()
        {
            UpdateTime();
        }
    }
}