using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetLightController : PlanetMaterialController
    {
        [SerializeField]
        private Vector2 lightOrigin;
        
        public override void Perform()
        {
            UpdateVector(UniPixelPlanetShaderProps.KeyLightOrigin, lightOrigin);
        }
    }
}