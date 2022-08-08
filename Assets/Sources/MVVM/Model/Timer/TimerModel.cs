using UnityEngine;

namespace Sources.MVVM.Model.Timer
{
    public class TimerModel: BaseModel
    {
        public int ElapsedTimeInSeconds { get; private set; }
        
        public void Change()
        {
            ElapsedTimeInSeconds = (int)Time.realtimeSinceStartup;
            ModelChanged();
        }
    }
}