using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetGradiantColorController : PlanetMaterialController
    {
        public float[] colorTimes;
        public Color[] colors;

        public void UpdateColor()
        {
            UpdateColor(UniPixelPlanetShaderProps.KeyGradientTex, colors, colorTimes);
        }
    }
}