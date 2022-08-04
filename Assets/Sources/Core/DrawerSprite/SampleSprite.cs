using UnityEngine;

namespace Sources.Core.DrawerSprite
{
    [ExecuteInEditMode]
    [AddComponentMenu("Sprites/SampleTexture")]
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class SampleSprite : MonoBehaviour
    {
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
#endif

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
        private MeshRenderer _renderer;
        private Camera _camera;

        
#if UNITY_EDITOR
        public void UpdateMesh()
        {
            InitializeMesh();
        }
#endif

        private void Awake()
        {
            _filter = GetComponent<MeshFilter>();
            _renderer = GetComponent<MeshRenderer>();
            _camera = Camera.main;
        }

        private void Start()
        {
            InitializeMesh();
        }

        private void InitializeMesh()
        {
            if (_pixelCorrect)
            {
                var ratio = _camera.pixelHeight / (2 * _camera.orthographicSize);
                var nonNormalizedTextureCoords = NonNormalizedTextureCoords;
                _size.x = nonNormalizedTextureCoords.width * ratio;
                _size.y = nonNormalizedTextureCoords.height * ratio;
            }
            
            _filter.mesh = CreateMesh(_size, _zero, _textureCoords);
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

        // todo вынести в отдельны класс
        private Mesh CreateMesh(Vector2 size, Vector2 zero, Rect textureCoords)
        {
            var vertices = new[]
            {
                new Vector3(0, 0, 0),
                new Vector3(0, size.y, 0),
                new Vector3(size.x, size.y, 0),
                new Vector3(size.x, 0, 0)
            };

            var shift = Vector3.Scale(zero, size);
            for (var i = 0; i < vertices.Length; i++)
            {
                vertices[i] -= shift;
            }

            var uv = new[]
            {
                new Vector2(textureCoords.xMin, 1 - textureCoords.yMax),
                new Vector2(textureCoords.xMin, 1 - textureCoords.yMin),
                new Vector2(textureCoords.xMax, 1 - textureCoords.yMin),
                new Vector2(textureCoords.xMax, 1 - textureCoords.yMax)
            };

            var triangles = new[]
            {
                0, 1, 2,
                0, 2, 3
            };

            return new Mesh { vertices = vertices, uv = uv, triangles = triangles };
        }
    }
}