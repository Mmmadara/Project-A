using System;
using Interfaces;
using UnityEngine;

namespace AbstractClasses
{
    public abstract class Enemy : MonoBehaviour, IMovable, IDamageable, IRotatable
    {
        public int health = 100;
        public int Speed { get; set; } = 3;
        private int _stopMoving = 0;
        private int _baseSpeed;

        private GameObject _player;
        public void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _baseSpeed = Speed;
        }

        public void Update()
        {
            Move();
            Flip();
            Death();
        }

        public void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, Speed * Time.deltaTime);
        }

        public void FixedMove()
        {
            throw new System.NotImplementedException();
        }

        public void ApplyDamage(int damageValue)
        {
            health -= damageValue;
        }

        public void Death()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void Flip()
        {
            if (_player.transform.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            
        }

        private void OnCollisionEnter(Collision collision)
        {   
            Speed = _stopMoving;
        }

        private void OnCollisionExit(Collision other)
        {
            Speed = _baseSpeed;
        }
    }
}