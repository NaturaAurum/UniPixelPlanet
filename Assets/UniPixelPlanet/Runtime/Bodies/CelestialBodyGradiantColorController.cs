using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies
{
    public class CelestialBodyGradiantColorController : CelestialBodyMaterialController
    {
        public float[] colorTimes;
        public Color[] colors;

        public void UpdateColor()
        {
            UpdateColor(UniPixelPlanetShaderProps.KeyGradientTex, colors, colorTimes);
        }
    }
}