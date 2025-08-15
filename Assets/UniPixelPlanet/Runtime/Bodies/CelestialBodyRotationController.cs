namespace UniPixelPlanet.Runtime.Bodies
{
    public class CelestialBodyRotationController : CelestialBodyMaterialController
    {
        public float rotation;
        
        public void UpdateRotation()
        {
            UpdateFloat(UniPixelPlanetShaderProps.KeyRotation, rotation);
        }
    }
}