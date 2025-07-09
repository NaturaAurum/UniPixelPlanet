using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies.Rivers
{
    public class LandRivers : CelestialBody {
    

        [SerializeField] private Color colorLand1 = ColorUtil.FromRGB("#63AB3F");
        [SerializeField] private Color colorLand2 = ColorUtil.FromRGB("#3B7D4F");
        [SerializeField] private Color colorLand3 = ColorUtil.FromRGB("#2F5753");
        [SerializeField] private Color colorLand4 = ColorUtil.FromRGB("#283540");

        [SerializeField] private Color colorRiver = ColorUtil.FromRGB("#4FA4B8");
        [SerializeField] private Color colorRiverDark = ColorUtil.FromRGB("#404973");

        [SerializeField] private Color colorCloud1 = ColorUtil.FromRGB("#FFFFFF");
        [SerializeField] private Color colorCloud2 = ColorUtil.FromRGB("#DFE0E8");
        [SerializeField] private Color colorCloud3 = ColorUtil.FromRGB("#686F99");
        [SerializeField] private Color colorCloud4 = ColorUtil.FromRGB("#404973");

        [SerializeField] private GameObject land;
        [SerializeField] private GameObject cloud;

        private Material _landMat;
        private Material _cloudMat;

        private void Start()
        {
            _landMat = land.GetComponent<SpriteRenderer>().material;
            _cloudMat = cloud.GetComponent<SpriteRenderer>().material;
            Initialize();
        }

        public override void Initialize()
        {
            SetPixel(pixel);

            var seedInt = seed.GetHashCode();
            var rng = new System.Random(seedInt);

            var val = rng.NextDouble();
            val = val < 0.1f ? val + 1 : val * 10;
            calcSeed= (float)val;

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
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
            _cloudMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
        }

        public void SetLight(Vector2 pos)
        {
            _landMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
            _cloudMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
        }

        public void SetCloudCover(float cover)
        {
            _cloudMat.SetFloat(UniPixelPlanetShaderProps.KeyCloudCover, cover);
        }

        public void SetSeed(float seed)
        {
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _cloudMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
        }

        public void SetRotate(float r)
        {
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _cloudMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
        }

        public void UpdateTime(float time)
        {
            _landMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time * 0.25f);
            _cloudMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time * 0.5f);
        }

        public void UpdateColor()
        {
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, colorLand1);
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColor2, colorLand2);
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColor3, colorLand3);
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColor4, colorLand4);

            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColorRiver, colorRiver);
            _landMat.SetColor(UniPixelPlanetShaderProps.KeyColorRiverDark, colorRiverDark);

            _cloudMat.SetColor(UniPixelPlanetShaderProps.KeyBaseColor, colorCloud1);
            _cloudMat.SetColor(UniPixelPlanetShaderProps.KeyOutlineColor, colorCloud2);
            _cloudMat.SetColor(UniPixelPlanetShaderProps.KeyShadowBaseColor, colorCloud3);
            _cloudMat.SetColor(UniPixelPlanetShaderProps.KeyShadowOutlineColor, colorCloud4);

        }

        public override void Perform()
        {
            Initialize();
        }
    }
}
