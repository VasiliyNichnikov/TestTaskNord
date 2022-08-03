using System;
using UnityEngine;


namespace Sources.Model
{
    // Model
    /// <summary>
    /// Хранит данные о пузырях
    /// Кроме этого имеет логику
    /// Например: вычитания значение и уничтожения
    /// Если значения меняеются, они передаются MV
    /// </summary>
    public class BubbleModel
    {
        public Action Changed;

        public Sprite Sprite { get; set; }
        public float Speed { get; set; }
        public float Size { get; set; }
    }
}