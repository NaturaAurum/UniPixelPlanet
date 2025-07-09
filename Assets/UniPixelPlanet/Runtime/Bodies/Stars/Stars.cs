using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies.Stars
{
    public class Stars : CelestialBody
    {
        [SerializeField] private Color colorBackground = ColorUtil.FromRGB("#ffffe4");

        [SerializeField] private Color colorStar1 = ColorUtil.FromRGB("#f5ffe8");
        [SerializeField] private Color colorStar2 = ColorUtil.FromRGB("#77d6c1");
        [SerializeField] private Color colorStar3 = ColorUtil.FromRGB("#1c92a7");
        [SerializeField] private Color colorStar4 = ColorUtil.FromRGB("#033e5e");

        [SerializeField] private Color colorFlare1 = ColorUtil.FromRGB("#77d6c1");
        [SerializeField] private Color colorFlare2 = ColorUtil.FromRGB("#ffffe4");

        [SerializeField] private GameObject starBackground;
        [SerializeField] private GameObject star;
        [SerializeField] private GameObject starFlares;

        private Material _starBackgroundMat;
        private Material _starMat;
        private Material _starFlaresMat;

        // timing Gradient for the star
        private readonly float[] _colorTimesStar = { 0f, 0.33f, 0.66f, 1.0f };

        // timing Gradient for the star flares
        private readonly float[] _colorTimesStarFlares = { 0f, 1.0f };

        private readonly int[,] _colorRanges = { { 0, 30 }, { 50, 65 }, { 190, 230 }, { 335, 360 } };

        // Start is called before the first frame update
        private void Start()
        {
            _starBackgroundMat = starBackground.GetComponent<SpriteRenderer>().material;
            _starMat = star.GetComponent<SpriteRenderer>().material;
            _starFlaresMat = starFlares.GetComponent<SpriteRenderer>().material;

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
                var hue1 = ColorUtil.GetRandomHueColorByRanges(rng, _colorRanges);
                var hue2 = ColorUtil.GetRandomHueColorByRanges(rng, _colorRanges);

                var baseColor1 = Color.HSVToRGB(hue1, 0.5f, 0.85f);
                var baseColor2 = Color.HSVToRGB(hue2, 0.11f, 1f);

                colorBackground = baseColor2;

                colorStar1 = baseColor2;
                colorStar2 = baseColor1;
                colorStar3 = Color.HSVToRGB(hue1, 0.83f, 0.65f);
                colorStar4 = Color.HSVToRGB(hue1, 1f, 0.4f);

                colorFlare1 = baseColor1;
                colorFlare2 = baseColor2;
            }


            UpdateColor();
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateTime(Time.time);
        }

        public void UpdateTime(float time)
        {
            _starBackgroundMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time);
            _starMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time * 0.1f);
            _starFlaresMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time);
        }

        public void SetPixel(float amount)
        {
            _starBackgroundMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount * 2);
            _starMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
            _starFlaresMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount * 2);
        }

        public void SetLight(Vector2 pos)
        {
            return;
        }

        public void SetSeed(float seed)
        {
            _starBackgroundMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _starMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
            _starFlaresMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
        }

        public void SetRotate(float r)
        {
            _starBackgroundMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _starMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
            _starFlaresMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
        }


        public void UpdateColor()
        {
            _starBackgroundMat.SetColor(UniPixelPlanetShaderProps.KeyColor1, colorBackground);
            _starMat.SetTexture(UniPixelPlanetShaderProps.KeyGradientTex,
                GradientUtil.GenerateShaderTex(new Color[] { colorStar1, colorStar2, colorStar3, colorStar4 },
                    _colorTimesStar));
            _starFlaresMat.SetTexture(UniPixelPlanetShaderProps.KeyGradientTex,
                GradientUtil.GenerateShaderTex(new Color[] { colorFlare1, colorFlare2 }, _colorTimesStarFlares));
        }

        public override void Perform()
        {
            Initialize();
        }
    }
}