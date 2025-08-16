using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetPixelController : PlanetMaterialController
    {
        [SerializeField]
        private float pixel = 100;
        
        public override void Perform()
        {
            UpdateFloat(UniPixelPlanetShaderProps.KeyPixels, pixel);
        }
    }
}