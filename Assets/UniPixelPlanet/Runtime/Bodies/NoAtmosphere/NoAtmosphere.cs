using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies.NoAtmosphere
{
    public class NoAtmosphere : CelestialBody {
   
        [SerializeField] private Color colorLand1 = ColorUtil.FromRGB("#A3A7C2");
        [SerializeField] private Color colorLand2 = ColorUtil.FromRGB("#4C6885");
        [SerializeField] private Color colorLand3 = ColorUtil.FromRGB("#3A3F5E");

        [SerializeField] private Color colorCrater1 = ColorUtil.FromRGB("#4C6885");
        [SerializeField] private Color colorCrater2 = ColorUtil.FromRGB("#3A3F5E");
    

        [SerializeField] private GameObject land;
        [SerializeField] private GameObject craters;
        private Material _landMat;
        private Material _cratersMat;

        private void Start()
        {
            _landMat = land.GetComponent<SpriteRenderer>().material;
            _cratersMat = craters.GetComponent<SpriteRenderer>().material;
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
           
            }

            UpdateColor();
        }

        private void Update()
        {
            UpdateTime(Time.time);
        }
        public void SetPixel(float amount)
        {
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
            _cratersMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
        }

        public void SetLight(Vector2 pos)
        {
            _landMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
            _cratersMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
        }

        public void SetSeed(float seed)
        {
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _cratersMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
        }

        public void SetRotate(float r)
        {
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _cratersMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
        }

        public void UpdateTime(float time)
        {
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time  * 0.5f);
            _cratersMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time  * 0.5f);
        }


        public void UpdateColor()
        {
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, colorLand1);
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColor2, colorLand2);
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColor3, colorLand3);

            _cratersMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, colorCrater1);
            _cratersMat.SetColor(UniPixelPlanetShaderProps.KeyColor2, colorCrater2);
        }

        public override void Perform()
        {
            Initialize();
        }
    }
}