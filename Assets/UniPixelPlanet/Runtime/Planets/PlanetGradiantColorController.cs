using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetGradiantColorController : PlanetMaterialController
    {
        [SerializeField]
        private float[] colorTimes;
        [SerializeField]
        private Color[] colors;

        public override void Perform()
        {
            UpdateColor(UniPixelPlanetShaderProps.KeyGradientTex, colors, colorTimes);
        }
    }
}