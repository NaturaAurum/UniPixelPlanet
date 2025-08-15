namespace UniPixelPlanet.Runtime.Planets
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