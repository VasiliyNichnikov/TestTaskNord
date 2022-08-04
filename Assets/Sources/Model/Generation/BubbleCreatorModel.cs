using Sources.Model.Bubble;
using Sources.View.Bubble;
using Sources.ViewModel.Bubble;
using UnityEngine;

namespace Sources.Model.Generation
{
    public class BubbleCreatorModel: BaseModel
    {
        private Sprite _firstStageBubble;
        private Sprite[] _stagesAfterClick;
        private GameObject _bubblePrefab;

        public BubbleCreatorModel(GameObject bubblePrefab, Sprite firstStageBubble, Sprite[] stagesAfterClick)
        {
            _firstStageBubble = firstStageBubble;
            _stagesAfterClick = stagesAfterClick;
            _bubblePrefab = bubblePrefab;
        }
        
        public override void Change()
        {
            // Изменение модели
            Create();
            // Отправка изменений всем подписанным на модель
            base.Change();
        }

        private void Create()
        {
            var step = 1.5f;
            var start = Vector3.zero;


            // todo тестирование
            for (int i = 0; i < 5; i++)
            {
                var newBubble = Object.Instantiate(_bubblePrefab, start, Quaternion.identity) as GameObject;
                
                // todo нужно разместить в фабрике
                var clickerModel = new BubbleClickerModel(_firstStageBubble, _stagesAfterClick);
                var end = start;
                end.y = -7;
                var movementModel = new BubbleMovementModel(start, end, 1.5f);

                var clickerViewModel = new BubbleClickerViewModel(clickerModel);
                var movementViewModel = new BubbleMovementViewModel(movementModel);

                var clickerView = newBubble.GetComponent<BubbleClickerView>();
                var movementView = newBubble.GetComponent<BubbleMovementView>();

                clickerView.Init(clickerViewModel);
                movementView.Init(movementViewModel);
                start.x += step;
            }    
        }
        
        // private int GetNumberOfBubbles()
        // {
        //     var horizontalScreen = Screen.width;
        //     _camera.Scre
        // }
    }
}