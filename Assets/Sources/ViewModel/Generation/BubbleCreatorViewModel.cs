using Sources.Infrastructure;
using Sources.Model.Generation;
using UnityEngine;

namespace Sources.ViewModel.Generation
{
    public class BubbleCreatorViewModel: BaseViewModel<BubbleCreatorModel>, IVMUpdate
    {
        public BubbleCreatorViewModel(BubbleCreatorModel model) : base(model)
        {
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Model.Change();
            }
        }

        protected override void OnChanged()
        {
        }
    }
}