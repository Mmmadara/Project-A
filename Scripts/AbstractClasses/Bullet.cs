using System;
using UnityEngine;

namespace AbstractClasses
{
    public abstract class Bullet: MonoBehaviour
    {
        public float speed;
        public float lifetime = 5;
        public int damage = 20;
        public LayerMask whatIsSolid;
        public GameObject bulletEffect;

        private void Start()
        {
            Invoke(nameof(DestroyBullet), lifetime);
        }

        private void Update()
        {
            ;
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        private void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}