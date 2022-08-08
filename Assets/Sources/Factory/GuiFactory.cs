using Sources.Core.Extensions;
using UnityEngine;

namespace Sources.Factory
{
    public class GuiFactory: IViewCreator
    {
        private readonly GameObject _gameObject;
        
        public GuiFactory(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public TView Instantiate<TView>() where TView : MonoBehaviour
        {
            var movementView = _gameObject.GetView<TView>();
            return movementView;
        }
    }
}