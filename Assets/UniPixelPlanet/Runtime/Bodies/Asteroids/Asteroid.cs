using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies.Asteroids
{
    public class Asteroid : CelestialBody {
    
        [SerializeField] private Color color1 = ColorUtil.FromRGB("#a3a7c2");
        [SerializeField] private Color color2 = ColorUtil.FromRGB("#4c6885");
        [SerializeField] private Color color3 = ColorUtil.FromRGB("#3a3f5e");


        [SerializeField] private GameObject asteroidSprite;

        private Material _asteroidMat;
    
        private string[] _initColors = {"#a3a7c2", "#4c6885", "#3a3f5e"};

        private void Start()
        {
            _asteroidMat = asteroidSprite.GetComponent<SpriteRenderer>().material;

            Initialize();
        }

        public override void Initialize()
        {
            SetPixel(pixel);

            var seedInt = seed.GetHashCode();
            var rng = new System.Random(seedInt);

            var val = rng.NextDouble();
            val = val < 0.1f ? val + 1 : val * 10;
            calcSeed = (float)val;

            SetSeed((float)val);

            if (generateColors)
            {
                // maybe later
            }

            UpdateColor();
        }

        public void SetPixel(float amount)
        {
            _asteroidMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
        }

        public void SetLight(Vector2 pos)
        {
            _asteroidMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
        }

        public void SetSeed(float seed)
        {
            _asteroidMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
        }

        public void SetRotate(float r)
        {
            _asteroidMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
        }

        public void UpdateTime(float time)
        {
            return;
        }

        public void UpdateColor()
        {
            _asteroidMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, color1);
            _asteroidMat.SetColor(UniPixelPlanetShaderProps.KeyColor2, color2);
            _asteroidMat.SetColor(UniPixelPlanetShaderProps.KeyColor3, color3);
        }

        public override void Perform()
        {
            Initialize();
        }

    }
}
