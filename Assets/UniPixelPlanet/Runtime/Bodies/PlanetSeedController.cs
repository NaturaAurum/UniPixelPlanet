namespace UniPixelPlanet.Runtime.Bodies
{
    public class PlanetSeedController : PlanetMaterialController
    {
        public string seedString = "seed";

        public void UpdateSeed()
        {
            var seed = seedString.GetHashCode();
            var rng = new System.Random(seed);
            var val = rng.NextDouble();
            val = val < 0.1f ? val + 1 : val * 10;

            UpdateFloat(UniPixelPlanetShaderProps.KeySeed, (float)val);
        }
    }
}