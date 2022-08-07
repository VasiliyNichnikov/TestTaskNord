using System.Collections;
using Sources.Core.Bubble;
using Sources.Core.Generator;
using Sources.Core.Utils;
using UnityEngine;

namespace Sources.MVVM.Model.Bubble
{
    public class BubbleClickerModel : BaseModel
    {
        public Vector3 BubbleScale { get; private set; }

        private readonly IGenerator _generator;
        private readonly SampleBubble _bubble;
        private readonly int _numberScore;
        
        private IEnumerator _playedAnimation;
        
        private bool _isDestroy;

        public BubbleClickerModel(SampleBubble bubble, IGenerator generator, int numberScore)
        {
            BubbleScale = Vector3.one;
            _bubble = bubble;
            _generator = generator;
            _numberScore = numberScore;
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
            _generator.Unsubscribe(_bubble, _numberScore);
            _playedAnimation = null;
            Object.Destroy(_bubble.gameObject);
        }
        #endregion
    }
}