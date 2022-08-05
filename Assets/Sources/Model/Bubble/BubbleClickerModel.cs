using System.Collections;
using Sources.Core.Generation;
using Sources.Core.ObjectBubble;
using Sources.Core.Utils;
using UnityEngine;

namespace Sources.Model.Bubble
{
    public class BubbleClickerModel : BaseModel
    {
        public Vector3 BubbleScale { get; private set; }

        private readonly ICreatedBubble _createdBubble;
        private readonly SampleBubble _bubble;
        private int _numberOfClicks;

        private IEnumerator _playedAnimation;
        
        private bool _isDestroy;

        public BubbleClickerModel(SampleBubble bubble, ICreatedBubble createdBubble, int numberOfClicks)
        {
            BubbleScale = Vector3.one;
            _bubble = bubble;
            _createdBubble = createdBubble;
            _numberOfClicks = numberOfClicks;
        }

        public IEnumerator Change()
        {
            Click();
            if (_playedAnimation != null)
            {
                return new MyEmptyEnumerator();
            }
            _playedAnimation = _isDestroy == false ? PingPongSizeAnimation() : RemoveSizeAnimation();
            return _playedAnimation;
        }
        
        /// <summary>
        /// Анимация пинг-понга, меняющая размер пузырька и возвращающая его на место
        /// </summary>
        /// <returns></returns>
        private IEnumerator PingPongSizeAnimation()
        {
            var refund = false;
            var oldScale = BubbleScale;
            var newScale = oldScale + new Vector3(0.35f, 0.35f, 0.35f);
            
            while (true)
            {
                BubbleScale = Vector3.Lerp(BubbleScale, newScale, 9.5f * Time.deltaTime);
                ModelChanged();
                yield return null;

                var difference = Vector3.Distance(BubbleScale, newScale);
                if (difference <= 0.1f && refund == false)
                {
                    refund = true;
                    newScale = oldScale;
                }
                else if (difference <= 0.1f && refund)
                    break;
            }

            _playedAnimation = null;
        }


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
        
        private void Click()
        {
            _numberOfClicks--;
            if (_numberOfClicks <= 0)
            {
                _isDestroy = true;
            }
        }
    }
}