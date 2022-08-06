using Sources.Core.Utils;
using UnityEngine;

namespace Sources.Core.Bubble
{
    [ExecuteInEditMode]
    [AddComponentMenu("Sprites/SampleTexture")]
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(MeshRenderer))]
    public class SampleBubble : MonoBehaviour
    {
        #region UNITY_EDITOR

#if UNITY_EDITOR
        public Vector2 Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public Vector2 Zero
        {
            get { return Vector2.Scale(_zero, _size); }
            set
            {
                if (_size != Vector2.zero)
                    _zero = new Vector2(value.x / _size.x, value.y / _size.y);
            }
        }

        public Rect TextureCoords
        {
            get { return NonNormalizedTextureCoords; }
            set
            {
                _textureCoords = value;
                var textureSize = GetTextureSize();
                if (textureSize != Vector2.one)
                {
                    _textureCoords.xMin /= textureSize.x;
                    _textureCoords.xMax /= textureSize.x;
                    _textureCoords.yMin /= textureSize.y;
                    _textureCoords.yMax /= textureSize.y;
                }
            }
        }

        public bool PixelCorrect
        {
            get { return _pixelCorrect; }
            set { _pixelCorrect = value; }
        }
        
        public void UpdateMesh()
        {
            if (_filter == null)
                _filter = GetComponent<MeshFilter>();
            if (_renderer == null)
                _renderer = GetComponent<MeshRenderer>();
            
            InitializeMesh();
        }
#endif

        #endregion
        
        private Rect NonNormalizedTextureCoords
        {
            get
            {
                var coords = _textureCoords;
                var textureSize = GetTextureSize();

                if (textureSize != Vector2.zero)
                {
                    coords.xMin *= textureSize.x;
                    coords.xMax *= textureSize.x;
                    coords.yMin *= textureSize.y;
                    coords.yMax *= textureSize.y;
                }

                return coords;
            }
        }

        [SerializeField] private Vector2 _size = Vector2.one;
        [SerializeField] private Vector2 _zero = Vector2.one;
        [SerializeField] private Rect _textureCoords = Rect.MinMaxRect(0, 0, 1, 1);
        [SerializeField] private bool _pixelCorrect = true;

        private MeshFilter _filter;
        private CircleCollider2D _circleCollider;
        private MeshRenderer _renderer;
        private UnityEngine.Camera _camera;

        public Vector2 GetSize()
        {
            return _size;
        }
        
        public void ChangeSize(int sizeSide)
        {
            _size = new Vector2(sizeSide, sizeSide);
            InitializeMesh();
        }

        public void ChangeMaterial(Material newMaterial)
        {
            _renderer.material = newMaterial;
        }
        
        private void Awake()
        {
            _filter = GetComponent<MeshFilter>();
            _renderer = GetComponent<MeshRenderer>();
            _circleCollider = GetComponent<CircleCollider2D>();
            _camera = UnityEngine.Camera.main;
        }
        
        private void Start()
        {
            InitializeMesh();
        }

        #region MAIN_LOGIC

        private void InitializeMesh()
        {
            if (_pixelCorrect)
            {
                var ratio = _camera.pixelHeight / (2 * _camera.orthographicSize);
                var nonNormalizedTextureCoords = NonNormalizedTextureCoords;
                _size.x = nonNormalizedTextureCoords.width * ratio;
                _size.y = nonNormalizedTextureCoords.height * ratio;
            }
            
            _filter.mesh = MeshCreator.Create(_size, _zero, _textureCoords);

            RecalculateCollider();
        }

        private Vector2 GetTextureSize()
        {
            if (_renderer == null)
                return Vector2.zero;

            var material = _renderer.sharedMaterial;
            if (material == null)
                return Vector2.zero;

            var texture = material.mainTexture;
            return texture == null ? Vector2.zero : new Vector2(texture.width, texture.height);
        }

        private void RecalculateCollider()
        {
            var radius = _size.x / 2;
            _circleCollider.offset = Vector2.zero;
            _circleCollider.radius = radius;
        }
        
        #endregion
    }
}