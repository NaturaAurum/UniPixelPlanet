using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies.GasPlanet
{
    public class GasPlanet : CelestialBody {
    
        [SerializeField] private Color colorCloud11 = ColorUtil.FromRGB("#3b2027");
        [SerializeField] private Color colorCloud12 = ColorUtil.FromRGB("#3b2027");
        [SerializeField] private Color colorCloud13 = ColorUtil.FromRGB("#21181b");
        [SerializeField] private Color colorCloud14 = ColorUtil.FromRGB("#21181b");

        [SerializeField] private Color colorCloud21 = ColorUtil.FromRGB("#f0b541");
        [SerializeField] private Color colorCloud22 = ColorUtil.FromRGB("#cf752b");
        [SerializeField] private Color colorCloud23 = ColorUtil.FromRGB("#ab5130");
        [SerializeField] private Color colorCloud24 = ColorUtil.FromRGB("#7d3833");


        [SerializeField] private GameObject cloud1;
        [SerializeField] private GameObject cloud2;
        private Material _cloud1Mat;
        private Material _cloud2Mat;

        private void Start()
        {
            _cloud1Mat = cloud1.GetComponent<SpriteRenderer>().material;
            _cloud2Mat = cloud2.GetComponent<SpriteRenderer>().material;
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
            SetCloudCoverCloud1(0f);
            // Random.Range(0.28f, 0.5f)
            SetCloudCoverCloud2(((float)rng.NextDouble() * 0.25f) + 0.3f);
        
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
            _cloud1Mat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
            _cloud2Mat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
        }

        public void SetLight(Vector2 pos)
        {
            _cloud1Mat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
            _cloud2Mat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
        }

        public void SetSeed(float seed)
        {
            _cloud1Mat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _cloud2Mat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
        }

        public void SetCloudCoverCloud1(float cover)
        {
            _cloud1Mat.SetFloat(UniPixelPlanetShaderProps.KeyCloudCover, cover);
        }
        public void SetCloudCoverCloud2(float cover)
        {
        
            _cloud2Mat.SetFloat(UniPixelPlanetShaderProps.KeyCloudCover, cover);
        }

        public void SetRotate(float r)
        {
            _cloud1Mat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _cloud2Mat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
        }

        public void UpdateTime(float time)
        {
            _cloud1Mat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time * 0.5f);
            _cloud2Mat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time  * 0.5f);
        }


        public void UpdateColor()
        {
            _cloud1Mat.SetColor(UniPixelPlanetShaderProps.KeyBaseColor, colorCloud11);
            _cloud1Mat.SetColor(UniPixelPlanetShaderProps.KeyOutlineColor, colorCloud12);
            _cloud1Mat.SetColor(UniPixelPlanetShaderProps.KeyShadowBaseColor, colorCloud13);
            _cloud1Mat.SetColor(UniPixelPlanetShaderProps.KeyShadowOutlineColor, colorCloud14);

            _cloud2Mat.SetColor(UniPixelPlanetShaderProps.KeyBaseColor, colorCloud21);
            _cloud2Mat.SetColor(UniPixelPlanetShaderProps.KeyOutlineColor, colorCloud22);
            _cloud2Mat.SetColor(UniPixelPlanetShaderProps.KeyShadowBaseColor, colorCloud23);
            _cloud2Mat.SetColor(UniPixelPlanetShaderProps.KeyShadowOutlineColor, colorCloud24);
        }

        public override void Perform()
        {
            Initialize();
        }
    }
}