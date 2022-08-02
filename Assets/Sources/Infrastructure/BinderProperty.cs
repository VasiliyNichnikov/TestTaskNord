using System;
using System.Reflection; 
using System.Collections.Generic;

namespace Sources.Infrastructure
{
    public class BinderProperty<T> where T : ViewModelBase {
        private delegate void BindHandler(T viewModel);
        private delegate void UnBindHandler(T viewModel);

        private readonly List<BindHandler> _binders = new List<BindHandler>();
        private readonly List<UnBindHandler> _unBinders = new List<UnBindHandler>();


		/// <summary>
		/// Добавление методов, которы содержат обновление View в списки
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="valueChanged">Value changed.</param>
		/// <typeparam name="TProperty">The 1st type parameter.</typeparam>
        public void Add<TProperty>(string name, BindableProperty<TProperty>.ValueChangedHandler valueChanged)
        {
            var fieldInfo = typeof(T).GetField(name, BindingFlags.Instance | BindingFlags.Public);
            if(fieldInfo == null)
            {
				throw new Exception(string.Format("Unable to find bindableProperty field {0}.{1}", typeof(T).Name, name));
            }

            BindHandler bind = viewModel => GetPropertyValue<TProperty>(name, viewModel, fieldInfo).OnValueChanged += valueChanged;
            UnBindHandler unBind = viewModel => GetPropertyValue<TProperty>(name, viewModel, fieldInfo).OnValueChanged -= valueChanged;

            _binders.Add(bind);
            _unBinders.Add(unBind);
        }


        /// <summary>
        /// Вызывает все методы, которые подписаны на BindHandler
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(T viewModel)
        {
            if(viewModel != null)
            {
                for (int i = 0; i < _binders.Count; i++) 
                {
                    _binders[i](viewModel);
                }
            }
        }

        /// <summary>
        /// Вызывает все методы, которые подписаны на UnBindHandler
        /// </summary>
        /// <param name="viewModel"></param>
        public void Unbind(T viewModel)
        {
            if(viewModel != null)
            {
                for(int i = 0; i < _unBinders.Count; i++)
                {
                    _unBinders[i](viewModel);
                }
            }
        }

        /// <summary>
        /// Возвращает значение BindalbeProperty через fieldInfo и GetValue
        /// </summary>
        /// <typeparam name="TProperty">Тип поля</typeparam>
        /// <param name="name">Имя поля</param>
        /// <param name="viewModel">Представление модели</param>
        /// <param name="fieldInfo">Информация о поле</param>
        /// <returns></returns>
        private BindableProperty<TProperty> GetPropertyValue<TProperty>(string name, T viewModel, FieldInfo fieldInfo)
        {
            var value = fieldInfo.GetValue(viewModel);
            var bindableProperty = value as BindableProperty<TProperty>;
            if(bindableProperty == null)
            {
				throw new Exception(string.Format("Illegal bindableProperty field {0}.{1}", typeof(T).Name, name));
            }
            return bindableProperty;
        }
    }
}