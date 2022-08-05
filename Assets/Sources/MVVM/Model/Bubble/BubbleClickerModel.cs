using System.Collections;
using Sources.Core.Generation;
using Sources.Core.ObjectBubble;
using Sources.Core.Utils;
using UnityEngine;

namespace Sources.MVVM.Model.Bubble
{
    public class BubbleClickerModel : BaseModel
    {
        public Vector3 BubbleScale { get; private set; }

        private readonly ICreatedBubble _createdBubble;
        private readonly SampleBubble _bubble;

        private IEnumerator _playedAnimation;
        
        private bool _isDestroy;

        public BubbleClickerModel(SampleBubble bubble, ICreatedBubble createdBubble)
        {
            BubbleScale = Vector3.one;
            _bubble = bubble;
            _createdBubble = createdBubble;
        }

        public IEnumerator Change()
        {
            if (_playedAnimation != null)
            {
                return new MyEmptyEnumerator();
            }
            _playedAnimation = RemoveSizeAnimation();
            return _playedAnimation;
        }

        #region ANIMATIONS

        /// <summary>
        /// Анимация исчезновения и последующего удаления пузыря
        /// </summary>
        /// <returns></returns>
        private IEnumerator RemoveSizeAnimation()
        {
            var newScale = Vector3.zero;
            while (true)
            {
                BubbleScale = Vector3.Lerp(BubbleScale, newScale, 10f * Time.deltaTime);
                ModelChanged();
                yield return null;

                var difference = Vector3.Distance(BubbleScale, newScale);
                if (difference <= 0.1f)
                {
                    break;
                }
            }
            _createdBubble.Unsubscribe(_bubble);
            _playedAnimation = null;
            Object.Destroy(_bubble.gameObject);
        }
        #endregion
    }
}