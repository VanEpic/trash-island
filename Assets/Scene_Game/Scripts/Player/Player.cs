using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scene_Game.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        // dialogue support
#pragma warning disable 0649
        [FormerlySerializedAs("NPCs")] 
        [SerializeField] private List<GameObject> _NPCs;
        [SerializeField] private GameEvent dialogEvent;
#pragma warning restore 0649
    
        public float dialogDist = 3;
        private bool _inDialog;
        public bool InDialog => _inDialog;
        private List<GameObject> _npcs;
    
        // get movement input support
        public float speed = 5;
        public float rotationSpeed = 360;
        public float jmpSpd = 2.0f;
        private Rigidbody _rgbd;
    
        // move relative to cam yaw support
        public Camera playerCam;
        private float _camYaw;
    
        // animation stuff
        private Animator _animator;

        // Start is called before the first frame update
        void Start()
        {
            _rgbd = GetComponent<Rigidbody>();
        
            _animator = GetComponent<Animator>();

            _npcs = new List<GameObject>(_NPCs);
        }

        // Update is called once per frame
        void Update()
        {
            if (_inDialog) return;
        
            HandleMovement();

            if (Input.GetKeyUp("e") && !_inDialog) Interact();
        }

        void HandleMovement()
        {
            _camYaw = playerCam.transform.rotation.eulerAngles.y;
            float camYawRad = _camYaw / 180 * Mathf.PI;
        
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
        
            Vector3 movementDirection = new Vector3(horizontalInput * Mathf.Cos(camYawRad) + verticalInput * Mathf.Sin(camYawRad),
                0, verticalInput * Mathf.Cos(camYawRad) - horizontalInput * Mathf.Sin(camYawRad));
            movementDirection.Normalize();

            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        
            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
            }
        
            // ground checked jump
            float jumpInput = Input.GetAxis("Jump");
            bool onGround = Physics.Raycast(transform.position, Vector3.down, 0.5f);
            if (jumpInput != 0 && onGround)
            {
                _rgbd.AddForce(
                    new Vector3(0, jumpInput * jmpSpd,
                        0), ForceMode.Impulse);
            }
        
            if (horizontalInput != 0 || verticalInput != 0)
            {
                _animator.Play("Player-Run");
            }
            else
            {
                _animator.Play("Player-Idle");
            }
        }

        public void OnDialogEnd()
        {
            _inDialog = false;
        }
    
        /// <summary>
        /// Interact with NPC for dialogue
        /// </summary>
        void Interact()
        {
            // or-equal so that stays to true once condition met
            foreach (var npc in _npcs)
            {
                _inDialog |= Vector3.Distance(transform.position, npc.transform.position) < dialogDist;
            }
            if (_inDialog) dialogEvent.Raise();
        }
    }
}
