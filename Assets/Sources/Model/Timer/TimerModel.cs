using UnityEngine;

namespace Sources.Model.Timer
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