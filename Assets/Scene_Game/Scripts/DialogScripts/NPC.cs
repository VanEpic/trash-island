using UnityEngine.Events;

namespace Scene_Game.Scripts.DialogScripts
{
    public class NPC : GameEventListener
    {
        public UnityEvent GameStartEvent;
        public UnityEvent DialogEvent;
        
        // public static NPC ActiveNPC { get; private set;  }

#pragma warning disable 0649
        // [SerializeField] private GameObject chatBubble;
        // [SerializeField] private string yarnStartNode;
#pragma warning restore 0649
        // public string YarnStartNode => yarnStartNode;
        // Start is called before the first frame update
        void Start()
        {
            // chatBubble.SetActive(false);
            // Event.UnregisterListener(this);
            GameStartEvent.Invoke();
        }

        public void ActivateNpcDialogue()
        {
            // ActiveNPC = this;
            Event.RegisterListener(this);
            DialogEvent.Invoke();
        }

        public void DeactivateNpcDialogue()
        {
            // Event.UnregisterListener(this);
        }

        public void OnDialogueEnd()
        {
            // Event.UnregisterListener(this);
        }

        private void OnDisable()
        {
            // Event.UnregisterListener(this);
        }
    }
}
