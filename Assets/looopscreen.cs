using UnityEngine;

public class looopscreen : MonoBehaviour
{
    public class scrollingBackground : MonoBehaviour
    {
        [SerializeField]
        private Renderer bgRenderer;
        public float speed = 2.0f;
        void Update()
        {
            bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
        }
    }
}
