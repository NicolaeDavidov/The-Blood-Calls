using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;
using RPG.Attributes;
using RPG.Stats;
using GameDevTV.Saving;
using GameDevTV.Inventories;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction, ISaveable
    { 
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] Transform rightHandTransform = null;
        [SerializeField] Transform leftHandTransform = null;
        [SerializeField] WeaponConfig defaultWeapon = null;
        double attackSpeed = 0f;

        Health target;
        Equipment equipment;
        float timeSinceLastAttack = Mathf.Infinity;
        WeaponConfig currentWeaponConfig = null;
        Weapon currentWeapon;

        private void Awake()
        {
            currentWeaponConfig = defaultWeapon;
            currentWeapon = SetupDefaultWeapon();
            equipment = GetComponent<Equipment>();
            if (equipment)
            {
                equipment.equipmentUpdated += UpdateWeapon;
            }
        }

        private Weapon SetupDefaultWeapon()
        {
            return AttachWeapon(defaultWeapon);
        }

        private void Start()
        {
            AttachWeapon(currentWeaponConfig);
        }

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null)
            {
                return;
            }
            if (target.IsDead())
            {
                //Delete this to fix the attack animation
                //StopAttack();
                return;
            }

            if (!GetInRange(target.transform))
            {
                //if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("the name of your animation clip you want to freeze upon"))
                //{
                //    return;
                //}
                GetComponent<Mover>().MoveTo(target.transform.position, 1f);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
                
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                attackSpeed += .5;
                GetComponent<Animator>().SetFloat("attackSpeedBuff", (float)attackSpeed);
            }
            
        }

        public void EquipWeapon(WeaponConfig weapon)
        {
            currentWeaponConfig = weapon;
            currentWeapon = AttachWeapon(weapon);

        }

        private void UpdateWeapon()
        {
            var weapon = equipment.GetItemInSlot(EquipLocation.Weapon) as WeaponConfig;
            if (weapon == null)
            {
                EquipWeapon(defaultWeapon);
            }
            else
            {
                EquipWeapon(weapon);
            }
        }

        private Weapon AttachWeapon(WeaponConfig weapon)
        {
            Animator animator = GetComponent<Animator>();
            return weapon.Spawn(rightHandTransform, leftHandTransform, animator);
        }

        public Health GetTarget()
        {
            return target;
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                //This will trigget the Hit() event
                TriggeAttack();
                timeSinceLastAttack = 0;

            }
        }



        private void TriggeAttack()
        {
            int randomNumber = Random.Range(1, 4);
            print("num" + randomNumber);
            GetComponent<Animator>().SetTrigger("attack" + randomNumber);
        }

        //Animation event

        void Hit()
        {
            if (target == null)
            {
                return;
            }
            float damage = GetComponent<BaseStats>().GetStat(Stat.BaseDamage);

            currentWeapon.OnHit();
            
            if (currentWeaponConfig.HasProjectile())
            {
                currentWeaponConfig.LaunchProjectile(rightHandTransform, leftHandTransform, target, gameObject, damage);
            }
            else
            {
                
                target.TakeDamage(gameObject, damage);
                if(transform.tag =="Player") print("damage done");
            }
        }

        private bool GetInRange(Transform targetTransform)
        {
            return Vector3.Distance(transform.position, targetTransform.transform.position) < currentWeaponConfig.GetRange();
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null)
            {
                return false;
            }

            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            StopAttack();
            target = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack1");
            GetComponent<Animator>().ResetTrigger("attack2");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }
        
        public object CaptureState()
        {
            return currentWeaponConfig.name;
        }

        public void RestoreState(object state)
        {
            string weaponName = (string)state;
            WeaponConfig weapon = UnityEngine.Resources.Load<WeaponConfig>(weaponName);
            EquipWeapon(weapon);
        }
        

    }
}
