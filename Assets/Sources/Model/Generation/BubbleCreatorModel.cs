using Sources.Core.DrawerSprite;
using Sources.Core.Utils;
using UnityEngine;

namespace Sources.Model.Generation
{
    public class BubbleCreatorModel : BaseModel
    {
        private readonly Transform _bubblesParent;
        private readonly GameObject[] _bubblesPrefab;

        private readonly int _widthScreen;
        private readonly int _heightScreen;
        private readonly int _numberBubbles;
        
        private const int _spaceBetweenBubbles = 20;

        public BubbleCreatorModel(Transform bubblesParent, GameObject[] bubblesPrefab)
        {
            _bubblesParent = bubblesParent;
            _bubblesPrefab = bubblesPrefab;
            _numberBubbles = bubblesPrefab.Length;

            _widthScreen = Screen.width;
            _heightScreen = Screen.height;
        }

        public override void Change()
        {
            // Изменение модели
            CreateBubbles();

            // Отправка изменений всем подписанным на модель
            // base.Change();
        }

        private void CreateBubbles()
        {
            var usedSpace = _spaceBetweenBubbles;
            var startPosition = new Vector3(-_widthScreen / 2 + usedSpace, _heightScreen / 2, 0);

            while (usedSpace < _widthScreen)
            {
                var idBubbles = RandomInRealTime.GetSevenNumber(_numberBubbles);
                foreach (var idBubble in idBubbles)
                {
                    var bubblePrefab = _bubblesPrefab[idBubble];

                    var newBubble = CreateNewBubble(bubblePrefab, startPosition);
                    var characteristics = newBubble.GetComponent<SampleSprite>();

                    AddUsedSpace((int)characteristics.Size.x, ref startPosition, ref usedSpace);

                    if (usedSpace >= _widthScreen && usedSpace - _spaceBetweenBubbles > _widthScreen)
                    {
                        DestroyBubble(newBubble);
                        break;
                    }

                    if (usedSpace >= _widthScreen)
                    {
                        break;
                    }
                }
            }
        }

        private GameObject CreateNewBubble(GameObject prefab, Vector3 startPosition)
        {
            var bubble = Object.Instantiate(prefab, startPosition, Quaternion.identity) as GameObject;
            bubble.transform.SetParent(_bubblesParent);
            return bubble;
        }

        private void DestroyBubble(GameObject bubble)
        {
            Object.Destroy(bubble);
        }

        private void AddUsedSpace(int sizeBubbleX, ref Vector3 startPosition, ref int usedSpace)
        {
            var newUsedSpace = sizeBubbleX + _spaceBetweenBubbles;
            startPosition.x += newUsedSpace;
            usedSpace += newUsedSpace;
        }
    }
}