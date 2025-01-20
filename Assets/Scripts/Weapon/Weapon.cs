﻿using Assets.Scripts.Core;
using Assets.Scripts.Data;
using Assets.Scripts.Units.Player;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class Weapon : BaseWeapon
    {
        private float distanceOfDamage = 40f;
        public Transform firePivot;

        public LayerMask ignoreLayer;
        private int currentBulletsInMagazine;

        private void Start()
        {
            SetSettings(GameManager.Instance.weaponData);
        }

        protected override void SetSettings(WeaponData weaponSettings)
        {
            base.SetSettings(weaponSettings);
        }

        private void OnGUI()
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(10, 10, 1000, 20), "currentCountOfShoot: " + currentBulletsInMagazine);
        }

        private void Update()
        {
            if (_isShooting == false) return;
            Shoot();
        }

        public void Shoot()
        {
            Ray ray = new Ray(firePivot.position, firePivot.forward);
            Shoot(ray);
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
            bullet.Init(firePivot.position, bulletEndPos);
        }

        private void CheckIUnit(RaycastHit tempHit)
        {
            ITakeDamage damageable = tempHit.transform.GetComponent<ITakeDamage>();
            if (damageable == null) return;

            damageable.TakeDamage(damage);
        }

        public override void StartShoot()
        {
            _isShooting = true;
        }

        public override void StopShoot()
        {
            _isShooting = false;
        }
    }
}