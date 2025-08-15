using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies
{
    public class CelestialBodyLightController : CelestialBodyMaterialController
    {
        public Vector2 lightOrigin;
        
        public void UpdateLight()
        {
            UpdateVector(UniPixelPlanetShaderProps.KeyLightOrigin, lightOrigin);
        }
    }
}