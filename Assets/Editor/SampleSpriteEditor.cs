using Sources.Core.DrawerSprite;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(SampleSprite))]
    public class SampleSpriteEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var sampleSprite = target as SampleSprite;

            sampleSprite.Size = EditorGUILayout.Vector2Field("Size", sampleSprite.Size);
            sampleSprite.Zero = EditorGUILayout.Vector2Field("Zero point", sampleSprite.Zero);
            sampleSprite.TextureCoords = EditorGUILayout.RectField("Texture coordinates", sampleSprite.TextureCoords);
            sampleSprite.PixelCorrect = EditorGUILayout.Toggle("Pixel correct", sampleSprite.PixelCorrect);

            if (GUI.changed)
            {
                sampleSprite.UpdateMesh();
                EditorUtility.SetDirty(target);
            }
        }

        [MenuItem("Sprites/Create/Sample")]
        private static void CreateSprite()
        {
            var gameObject = new GameObject("NewSampleSprite");
            gameObject.AddComponent<SampleSprite>();
            Selection.activeObject = gameObject;
        }
    }
}