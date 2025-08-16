using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetRotationController : PlanetMaterialController
    {
        [SerializeField]
        private float rotation;
        
        public override void Perform()
        {
            UpdateFloat(UniPixelPlanetShaderProps.KeyRotation, rotation);
        }
    }
}