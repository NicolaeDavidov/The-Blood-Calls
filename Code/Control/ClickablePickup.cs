using UnityEngine;
using GameDevTV.Inventories;
using RPG.Movement;

namespace RPG.Control
{
    [RequireComponent(typeof(Pickup))]
    public class ClickablePickup : MonoBehaviour, IRaycastable
    {
        [SerializeField] Pickup pickup;
        [SerializeField] PlayerController playerController;


        private void Awake()
        {
            pickup = GetComponent<Pickup>();
            
        }

        private void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
        //private void ontriggerenter(collider other)
        //{
        //    if (other.gameobject.tag == "player")
        //    {
        //        pickup.pickupitem();
        //    }
        //}

        public CursorType GetCursorType()
        {
            if (pickup.CanBePickedUp())
            {
                return CursorType.Pickup;
            }
            else
            {
                return CursorType.None;
            }
        }

        public bool HandleRaycast(PlayerController callingController)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerController.GetComponent<Mover>().StartMoveAction(transform.position, 1f);
                float distance = Vector3.Distance(playerController.GetComponent<Mover>().transform.position, pickup.transform.position);
                if (distance <= 1.5f)
                {
                    pickup.PickupItem();
                }

                // if player <= 1m of object
                // do pickup.PickupItem();
            }
            return true;
        }
    }
}