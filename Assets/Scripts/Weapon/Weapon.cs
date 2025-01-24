using Core;
using Data;
using Units.Player;
using UnityEngine;

namespace Weapon
{
    public class Weapon : BaseWeapon
    {
        private readonly float distanceOfDamage = 100f;
        public Transform firePivot;

        public LayerMask ignoreLayer;
        private float fireTimer;

        private void Start()
        {
            SetSettings(GameManager.Instance.weaponData);
        }

        protected override void SetSettings(WeaponData weaponSettings)
        {
            base.SetSettings(weaponSettings);
            fireTimer = TimeFireRate;
        }

        private void Update()
        {
            if (isShooting == false) return;
            
            fireTimer -= Time.deltaTime;
            
            if (fireTimer <= 0f)
            {
                Shot();
            }
        }

        private void Shot()
        {
            Ray ray = new Ray(firePivot.position, firePivot.forward);
            Shoot(ray);
            fireTimer = TimeFireRate;
        }

        private void Shoot(Ray ray)
        {
            RaycastHit hit;
            var hitchek = Physics.Raycast(ray, out hit, distanceOfDamage, ~ignoreLayer, QueryTriggerInteraction.Ignore);
            if (hitchek)
            {
                CreateVisualBullet(hit.point);
                CheckIUnit(hit);
            }
            else
            {
                var targetBulletPos = firePivot.position + ray.direction * distanceOfDamage;
                CreateVisualBullet(targetBulletPos);
            }
        }

        private void CreateVisualBullet(Vector3 bulletEndPos)
        {
            Bullet bullet = Instantiate(GameManager.Instance.bulletPrefub, firePivot.position, Quaternion.identity);
            bullet.Init(firePivot.position, bulletEndPos, BulletSpeed);
        }

        private void CheckIUnit(RaycastHit tempHit)
        {
            ITakeDamage damageable = tempHit.transform.GetComponent<ITakeDamage>();
            if (damageable == null) return;

            damageable.TakeDamage(Damage);
        }

        public override void StartShoot()
        {
            isShooting = true;
        }

        public override void StopShoot()
        {
            isShooting = false;
        }
    }
}