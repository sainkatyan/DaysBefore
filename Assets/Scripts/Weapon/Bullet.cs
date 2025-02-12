﻿using UnityEngine;

namespace Weapon
{
    public class Bullet : MonoBehaviour
    {
        private float speed = 0.2f;
        private Vector3 startPos;
        private Vector3 endPos;
        private float lifeTime;

        public void Init(Vector3 startPos, Vector3 endPos, float bulletSpeed)
        {
            speed = bulletSpeed;
            
            this.startPos = startPos;
            this.endPos = endPos;
            lifeTime = 0f;
        }

        private void Update()
        {
            lifeTime += Time.deltaTime / speed;
            transform.position = Vector3.Lerp(startPos, endPos, lifeTime);
            if (Camera.main != null)
            {
                transform.LookAt(Camera.main.transform.position, Vector3.up);
            }
            if (lifeTime > 1f)
            {
                DestroyBullet();
            }
        }

        private void DestroyBullet()
        {
            //play destroy particle
            Destroy(gameObject);
        }
    }
}