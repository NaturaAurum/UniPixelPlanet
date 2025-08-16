using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    public class PlanetMaterialController : MonoBehaviour
    {
        public Renderer targetRenderer;
        protected MaterialPropertyBlock PropertyBlock;

        private void Awake()
        {
            PropertyBlock = new MaterialPropertyBlock();
        }

        protected void Get()
        {
            targetRenderer.GetPropertyBlock(PropertyBlock);
        }

        protected void Set()
        {
            targetRenderer.SetPropertyBlock(PropertyBlock);
        }

        protected void UpdateFloat(string key, float value)
        {
            Get();
            PropertyBlock.SetFloat(key, value);
            Set();
        }

        protected void UpdateColor(string key, Color color)
        {
            Get();
            PropertyBlock.SetColor(key, color);
            Set();
        }

        protected void UpdateVector(string key, Vector2 vector)
        {
            Get();
            PropertyBlock.SetVector(key, vector);
            Set();
        }

        protected void UpdateColor(string key, Color[] colors, float[] times)
        {
            Get();
            PropertyBlock.SetTexture(key, GradientUtil.GenerateShaderTex(colors, times));
            Set();
        }

        public virtual void Perform()
        {
            
        }
    }
}