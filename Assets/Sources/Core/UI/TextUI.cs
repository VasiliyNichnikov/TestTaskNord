using Sources.Core.AssetBundles;
using Sources.Factory;
using Sources.MVVM.Model.MyText;
using Sources.Routers.MyText;
using UnityEngine;

namespace Sources.Core.UI
{
    public class TextUI: MonoBehaviour
    {
        [SerializeField] private AssetBundleObject _bundleFont;

        private ITextRouter _textRouter;

        private void Start()
        {
            var textModel = new TextModel();

            _textRouter = new TextRouter(new GuiFactory(gameObject), textModel);

            var loaderModel = new LoaderTextModel(_textRouter, _bundleFont);
            _textRouter.LoadResourcesInText(loaderModel);
        }

    }
}