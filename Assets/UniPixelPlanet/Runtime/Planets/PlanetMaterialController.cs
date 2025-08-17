using UnityEngine;

namespace UniPixelPlanet.Runtime.Planets
{
    [RequireComponent(typeof(Renderer))]
    public class PlanetMaterialController : MonoBehaviour
    {
        private Renderer _targetRenderer;
        protected MaterialPropertyBlock PropertyBlock;

        private void Awake()
        {
            PropertyBlock = new MaterialPropertyBlock();
            _targetRenderer = GetComponent<Renderer>();
        }

        protected void Get()
        {
            _targetRenderer.GetPropertyBlock(PropertyBlock);
        }

        protected void Set()
        {
            _targetRenderer.SetPropertyBlock(PropertyBlock);
            PropertyBlock.Clear();
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