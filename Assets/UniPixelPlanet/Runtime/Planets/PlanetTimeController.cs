using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetTimeController : PlanetMaterialController
    {
        public float timeScale = 1;
        
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