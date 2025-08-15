namespace UniPixelPlanet.Runtime.Bodies
{
    public class PlanetRotationController : PlanetMaterialController
    {
        public float rotation;
        
        public void UpdateRotation()
        {
            UpdateFloat(UniPixelPlanetShaderProps.KeyRotation, rotation);
        }
    }
}