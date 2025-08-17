using System.Linq;
using UniPixelPlanet.Runtime.Data;
using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetGradiantColorController : PlanetMaterialController
    {
        [SerializeField]
        private PlanetGradientColorData gradientColorData;

        public override void Perform()
        {
            foreach (var gradientGroup in gradientColorData.Gradients)
            {
                var colors = gradientGroup.colors.Select(c => c.color).ToArray();
                var times = gradientGroup.colors.Select(c => c.colorTime).ToArray();
                UpdateColor(gradientGroup.propName, colors, times);
            }
        }
    }
}