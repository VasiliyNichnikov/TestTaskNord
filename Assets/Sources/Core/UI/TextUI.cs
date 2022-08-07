using Sources.Core.AssetBundles;
using Sources.Factory;
using Sources.MVVM.Model.MyText;
using Sources.Routers.MyText;
using UnityEngine;
using Network = Sources.Core.AssetBundles.Network;

namespace Sources.Core.UI
{
    public class TextUI: MonoBehaviour
    {
        [SerializeField] private AssetBundleObject _bundleFont;

        private ITextRouter _router;

        private void Start()
        {
            var model = new TextModel();
            // Загрузка шрифтов в модель
            // todo перенести логику загрузки в отдельную модель
            ExternalResourceManager.LoadFont(_bundleFont.NameBundle, _bundleFont.AssetsName[0], null, model.LoadFont);
            
            _router = new TextRouter(new GuiFactory(gameObject), model);
            _router.CreateText();
        }

    }
}