using UnityEngine;


namespace Sources.Model
{
    /// <summary>
    /// Хранит данные о пузырях
    /// Кроме этого имеет логику
    /// Например: вычитания значение и уничтожения
    /// Если значения меняеются, они передаются MV
    /// </summary>
    public class BubbleModel : BaseModel
    {
        public Sprite Sprite { get; set; }
        public float Speed { get; set; }
        public float Size { get; set; }
    }
}