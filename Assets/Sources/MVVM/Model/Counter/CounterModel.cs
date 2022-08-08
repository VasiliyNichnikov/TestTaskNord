namespace Sources.MVVM.Model.Counter
{
    public class CounterModel: BaseModel
    {
       public int Counter { get; private set; }

       public void UpdateCounter(int plus)
       {
           // Изменяем модель
           Counter += plus;
           // Сообщаем о том, что модель была изменена
           ModelChanged();
       }
       
    }
}