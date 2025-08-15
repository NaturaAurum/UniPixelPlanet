using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetLightController : PlanetMaterialController
    {
        public Vector2 lightOrigin;
        
        public void UpdateLight()
        {
            UpdateVector(UniPixelPlanetShaderProps.KeyLightOrigin, lightOrigin);
        }
    }
}