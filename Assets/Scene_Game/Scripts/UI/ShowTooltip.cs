using UnityEngine;

namespace Scene_Game.Scripts.UI
{
    public class ShowTooltip : GameEventListener
    {
        [SerializeField] private GameObject tooltip;
        private bool tooltipActiveState;
        
        // Start is called before the first frame update
        void Start()
        {
            tooltip.SetActive(false);
            
            EventManager.AddOnPickupEventListener(HideTooltip);
        }
        
        private void HideTooltip(CollectibleTrigger target)
        {
            tooltip.SetActive(false);
            tooltipActiveState = false;
        }

        public void SwitchActive()
        {
            tooltip.SetActive(!tooltipActiveState);
            tooltipActiveState = !tooltipActiveState;
        }
    }
}
