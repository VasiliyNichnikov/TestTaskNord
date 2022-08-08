using Sources.MVVM.Model.MyText;
using UnityEngine;

namespace Sources.Routers.MyText
{
    public interface ITextRouter
    {
        Font Font { get; set; }

        void LoadResourcesInText(LoaderTextModel loaderModel);
    }
}