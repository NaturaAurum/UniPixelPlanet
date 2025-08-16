using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetSeedController : PlanetMaterialController
    {
        [SerializeField]
        private string seedString = "seed";

        public override void Perform()
        {
            var seed = seedString.GetHashCode();
            var rng = new System.Random(seed);
            var val = rng.NextDouble();
            val = val < 0.1f ? val + 1 : val * 10;

            UpdateFloat(UniPixelPlanetShaderProps.KeySeed, (float)val);
        }
    }
}