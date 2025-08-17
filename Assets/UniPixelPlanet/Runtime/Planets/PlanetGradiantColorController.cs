using UniPixelPlanet.Runtime.Attributes;
using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetGradiantColorController : PlanetMaterialController
    {
        public string PropName => propName;
        public float[] Times => colorTimes;
        public Color[] Colors => colors;
        
        [SerializeField]
        [ShaderProp]
        private string propName;
        [SerializeField]
        private float[] colorTimes;
        [SerializeField]
        private Color[] colors;

        public override void Perform()
        {
            UpdateColor(propName, colors, colorTimes);
        }
    }
}