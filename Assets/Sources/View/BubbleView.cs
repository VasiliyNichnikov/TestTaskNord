using Sources.Infrastructure;
using Sources.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class BubbleView : UnityView<BubbleViewModel>
	{
		private SpriteRenderer _renderer;
		
        protected override void OnInitialize()
        {
            base.OnInitialize();
            Binder.Add<Sprite>("Sprite", OnChangeSprite);
        }
        
        
        private void Awake()
        {
	        _renderer = GetComponent<SpriteRenderer>();
        }
        
        /// <summary>
        /// Нажатие на кружок
        /// </summary>
        private void OnMouseDown()
        {
	        
        }

		private void OnChangeSprite(Sprite oldValue, Sprite newValue)
		{
			print("Изменить значение спрайта на новое");
			_renderer.sprite = newValue;
		}
	}
}
