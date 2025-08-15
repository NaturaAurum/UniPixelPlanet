namespace UniPixelPlanet.Runtime.Bodies
{
    public class PlanetPixelController : PlanetMaterialController
    {
        public float pixel = 100;
        
        public void UpdatePixel()
        {
            UpdateFloat(UniPixelPlanetShaderProps.KeyPixels, pixel);
        }
    }
}