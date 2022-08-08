using Sources.Core.AssetBundles;
using Sources.Routers.MyText;
using UnityEngine;

namespace Sources.MVVM.Model.MyText
{
    public class LoaderTextModel: BaseModel
    {
        private readonly ITextRouter _textRouter;
        
        public LoaderTextModel(ITextRouter router, AssetBundleObject bundleFont)
        {
            _textRouter = router;
            ExternalResourceManager.LoadFont(bundleFont.NameBundle, bundleFont.AssetsName[0], null, LoadFont);
        }
        
        private void LoadFont(Font font)
        {
            _textRouter.Font = font;
            ModelChanged();
        }
    }
}