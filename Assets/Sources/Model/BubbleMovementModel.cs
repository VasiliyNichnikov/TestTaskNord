using UnityEngine;


namespace Sources.Model
{
    public class BubbleMovementModel : BaseModel
    {
        public Vector3 BubblePosition { get; private set; }

        private readonly Vector3 _startPosition;
        private readonly Vector3 _endPosition;

        private readonly float _speed;

        private float _distanceToEndPosition;

        public BubbleMovementModel(Vector3 startPosition, Vector3 endPosition, float speed)
        {
            BubblePosition = startPosition;
            _startPosition = startPosition;
            _endPosition = endPosition;
            _speed = speed;
        }

        public override void Change()
        {
            Move();
            base.Change();
        }

        private void Move()
        {
            var step = _speed * Time.deltaTime;
            _distanceToEndPosition = Vector3.Distance(BubblePosition, _endPosition);
            BubblePosition = Vector3.MoveTowards(BubblePosition, _endPosition, step);
        }
        
        public void Reset()
        {
            BubblePosition = _startPosition;
        }
    }
}