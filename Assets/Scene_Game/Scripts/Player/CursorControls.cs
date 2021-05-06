using UnityEngine;

namespace Scene_Game.Scripts.Player
{
    public class CursorControls : MonoBehaviour
    {
        private Player _player;
        
        // Start is called before the first frame update
        void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;

            _player = GetComponent<Player>();
        }
        
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("escape") || _player.InDialog)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Cursor.lockState != CursorLockMode.Locked && Input.GetMouseButtonUp(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
