using UnityEngine;

namespace UniPixelPlanet.Runtime.Bodies.Blackhole
{
    public class Blackhole : CelestialBody
    {
        [SerializeField] private GameObject blackholeObj;
        [SerializeField] private GameObject blackholeRingObj;

        [SerializeField] private Color colorBlack = ColorUtil.FromRGB("#272736");
        [SerializeField] private Color colorHole1 = ColorUtil.FromRGB("#ffffeb");
        [SerializeField] private Color colorHole2 = ColorUtil.FromRGB("#ed7b39");

        [SerializeField] private Color colorRing1 = ColorUtil.FromRGB("#ffffeb");
        [SerializeField] private Color colorRing2 = ColorUtil.FromRGB("#fff540");
        [SerializeField] private Color colorRing3 = ColorUtil.FromRGB("#ffb84a");
        [SerializeField] private Color colorRing4 = ColorUtil.FromRGB("#ed7b39");
        [SerializeField] private Color colorRing5 = ColorUtil.FromRGB("#bd4035");


        [SerializeField] private Gradient gra;

        private readonly float[] _colorTimes = { 0, 1.0f };
        private readonly float[] _colorTimesRing = { 0, 0.25f, 0.5f, 0.75f, 1.0f };


        private Material _blackholeMat;
        private Material _blackholeRingMat;

        private void Start()
        {
            _blackholeMat = blackholeObj.GetComponent<SpriteRenderer>().material;
            _blackholeRingMat = blackholeRingObj.GetComponent<SpriteRenderer>().material;
            Initialize();
        }

        private void Update()
        {
            UpdateTime(Time.time);
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

        public void SetPixel(float amount)
        {
            _blackholeMat.SetFloat(UniPixelPlanetShaderProps.KeyPixels, amount);
        }

        public void SetSeed(float seed)
        {
            _blackholeRingMat.SetFloat(UniPixelPlanetShaderProps.KeySeed, seed);
        }

        public void SetRotate(float r)
        {
            _blackholeRingMat.SetFloat(UniPixelPlanetShaderProps.KeyRotation, r);
        }

        public void UpdateTime(float time)
        {
            _blackholeRingMat.SetFloat(UniPixelPlanetShaderProps.KeyTime, time * 0.5f);
        }

        public void UpdateColor()
        {
            _blackholeMat.SetColor(UniPixelPlanetShaderProps.KeyColorBlack, colorBlack);
            var tex1 = GradientUtil.GenerateShaderTex(new[] { colorHole1, colorHole2 }, _colorTimes);
        
            _blackholeMat.SetTexture(UniPixelPlanetShaderProps.KeyGradientTex, tex1);
            gra = GradientUtil.GetGradient(new[] { colorRing1, colorRing2, colorRing3, colorRing4, colorRing5 }, _colorTimesRing);


            var tex2 = GradientUtil.GenerateShaderTex(new[] { colorRing1, colorRing2, colorRing3, colorRing4, colorRing5 }, _colorTimesRing);

            _blackholeRingMat.SetTexture(UniPixelPlanetShaderProps.KeyGradientTex, tex2);
        }

        public override void Perform()
        {
            Initialize();
        }


 
    }
}
