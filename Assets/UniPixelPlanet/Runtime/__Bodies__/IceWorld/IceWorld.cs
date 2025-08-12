using UnityEngine;

namespace UniPixelPlanet.Runtime.__Bodies__.IceWorld
{
    public class IceWorld : CelestialBody {

        [SerializeField] private Color colorLand1 = ColorUtil.FromRGB("#faffff");
        [SerializeField] private Color colorLand2 = ColorUtil.FromRGB("#c7d4e1");
        [SerializeField] private Color colorLand3 = ColorUtil.FromRGB("#928fb8");

        [SerializeField] private Color colorLakes1 = ColorUtil.FromRGB("#4fa4b8");
        [SerializeField] private Color colorLakes2 = ColorUtil.FromRGB("#4c6885");
        [SerializeField] private Color colorLakes3 = ColorUtil.FromRGB("#3a3f5e");

        [SerializeField] private Color colorCloud1 = ColorUtil.FromRGB("#e1f2ff");
        [SerializeField] private Color colorCloud2 = ColorUtil.FromRGB("#c0e3ff");
        [SerializeField] private Color colorCloud3 = ColorUtil.FromRGB("#5e70a5");
        [SerializeField] private Color colorCloud4 = ColorUtil.FromRGB("#404973");

        [SerializeField] private GameObject planetUnder;
        [SerializeField] private GameObject lakes;
        [SerializeField] private GameObject clouds;
        private Material _planetUnderMat;
        private Material _lakesMat;
        private Material _cloudsMat;

        private void Start()
        {
            _planetUnderMat = planetUnder.GetComponent<SpriteRenderer>().material;
            _lakesMat = lakes.GetComponent<SpriteRenderer>().material;
            _cloudsMat = clouds.GetComponent<SpriteRenderer>().material;
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
            SetCloudCover(((float)rng.NextDouble() * 0.25f) + 0.4f);
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
            _planetUnderMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
            _lakesMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
            _cloudsMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
        }

        public void SetLight(Vector2 pos)
        {
            _planetUnderMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
            _lakesMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
            _cloudsMat.SetVector(UniPixelPlanetShaderProps.KeyLightOrigin, pos);
        }

        private void SetCloudCover(float cover)
        {
            _cloudsMat.SetFloat(UniPixelPlanetShaderProps.KeyCloudCover, cover);
        }

        public void SetSeed(float seed)
        {
            _planetUnderMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _lakesMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _cloudsMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
        }

        public void SetRotate(float r)
        {
            _planetUnderMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _lakesMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _cloudsMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
        }

        public void UpdateTime(float time)
        {
        
            _cloudsMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time * 0.5f);
            _planetUnderMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time );
            _lakesMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time);
        }

        public void UpdateColor()
        {
            _planetUnderMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, colorLand1);
            _planetUnderMat.SetColor(UniPixelPlanetShaderProps.KeyColor2, colorLand2);
            _planetUnderMat.SetColor(UniPixelPlanetShaderProps.KeyColor3, colorLand3);

            _lakesMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, colorLakes1);
            _lakesMat.SetColor(UniPixelPlanetShaderProps.KeyColor2, colorLakes2);
            _lakesMat.SetColor(UniPixelPlanetShaderProps.KeyColor3, colorLakes3);

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
