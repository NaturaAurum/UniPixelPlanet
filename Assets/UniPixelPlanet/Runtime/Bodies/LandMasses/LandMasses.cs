using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies.LandMasses
{
    public class LandMasses : CelestialBody {

        [SerializeField] private Color colorLand1 = ColorUtil.FromRGB("#C8D45D");
        [SerializeField] private Color colorLand2 = ColorUtil.FromRGB("#63AB3F");
        [SerializeField] private Color colorLand3 = ColorUtil.FromRGB("#2F5753");
        [SerializeField] private Color colorLand4 = ColorUtil.FromRGB("#283540");

        [SerializeField] private Color colorWater1 = ColorUtil.FromRGB("#92E8C0");
        [SerializeField] private Color colorWater2 = ColorUtil.FromRGB("#4FA4B8");
        [SerializeField] private Color colorWater3 = ColorUtil.FromRGB("#2C354D");

        [SerializeField] private Color colorCloud1 = ColorUtil.FromRGB("#DFE0E8");
        [SerializeField] private Color colorCloud2 = ColorUtil.FromRGB("#A3A7C2");
        [SerializeField] private Color colorCloud3 = ColorUtil.FromRGB("#686F99");
        [SerializeField] private Color colorCloud4 = ColorUtil.FromRGB("#404973");

        [SerializeField] private GameObject water;
        [SerializeField] private GameObject land;
        [SerializeField] private GameObject cloud;
        private Material _waterMat;
        private Material _landMat;
        private Material _cloudsMat;

        private void Start()
        {
            _waterMat = water.GetComponent<SpriteRenderer>().material;
            _landMat = land.GetComponent<SpriteRenderer>().material;
            _cloudsMat = cloud.GetComponent<SpriteRenderer>().material;
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
            // Random.Range(0.35f, 0.6f)
            SetCloudCover(((float)rng.NextDouble() * 0.25f) + 0.35f);
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
            _waterMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
            _cloudsMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
        }

        public void SetLight(Vector2 pos)
        {
            _waterMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
            _landMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
            _cloudsMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
        }

        public void SetCloudCover(float cover)
        {
            _cloudsMat.SetFloat(UniPixelPlanetShaderProps.KeyCloudCover, cover);
        }

        public void SetSeed(float seed)
        {
            _waterMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _cloudsMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
        }

        public void SetRotate(float r)
        {
            _waterMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _cloudsMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
        }

        public void UpdateTime(float time)
        {
            _cloudsMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time * 0.5f);
            _waterMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time );
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time);
        }
    
        public void UpdateColor()
        {
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, colorLand1);
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColor2, colorLand2);
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColor3, colorLand3);
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColor4, colorLand4);

            _waterMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, colorWater1);
            _waterMat.SetColor(UniPixelPlanetShaderProps.KeyColor2, colorWater2);
            _waterMat.SetColor(UniPixelPlanetShaderProps.KeyColor3, colorWater3);

            _cloudsMat.SetColor(UniPixelPlanetShaderProps.KeyBaseColor, colorCloud1);
            _cloudsMat.SetColor(UniPixelPlanetShaderProps.KeyOutlineColor, colorCloud2);
            _cloudsMat.SetColor(UniPixelPlanetShaderProps.KeyShadowBaseColor, colorCloud3);
            _cloudsMat.SetColor(UniPixelPlanetShaderProps.KeyShadowOutlineColor, colorCloud4);
        }

        public override void Perform()
        {
            Initialize();
        }
    }
}
