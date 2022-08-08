using UnityEngine;

namespace Sources.Core.Utils
{
    public static class MeshCreator
    {
        public static Mesh Create(Vector2 size, Vector2 zero, Rect textureCoords)
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