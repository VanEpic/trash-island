using UnityEngine.Events;

namespace Scene_Game.Scripts.DialogScripts
{
    public class NPC : GameEventListener
    {
        public UnityEvent GameStartEvent;
        public UnityEvent DialogEvent;
        
        void Start()
        {
            GameStartEvent.Invoke();
        }

        public void ActivateNpcDialogue()
        {
            DialogEvent.Invoke();
        }
    }
}
