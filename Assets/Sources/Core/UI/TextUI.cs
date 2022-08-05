﻿using Sources.Core.AssetBundles;
using Sources.Dependence.MyText;
using Sources.MVVM.Model.MyText;
using UnityEngine;

namespace Sources.Core.UI
{
    public class TextUI: MonoBehaviour
    {
        [SerializeField] private AssetBundleObject _bundleFont;

        private ITextRouter _router;
        private LoaderAssistant _loader;
        
        private void Awake()
        {
            _loader = FindObjectOfType<LoaderAssistant>();
        }

        private void Start()
        {
            var model = new TextModel();
            // Загрузка шрифтов в модель
            _loader.LoadFont(_bundleFont.NameBundle, _bundleFont.AssetsName[0], model.LoadFont);
            _router = new TextRouter(gameObject, model);
            _router.CreateText();
        }

    }
}