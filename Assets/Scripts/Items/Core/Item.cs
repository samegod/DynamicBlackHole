using System;
using ItemsTarget;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Items.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Item : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private ItemTypeId type;
        [SerializeField] private float speed;

        private Rigidbody2D _rigidbody;
        private Target _target;
        private bool _moveToTarget;

        private float _maxSpeed = 2;

        public ItemTypeId TypeId => type;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_moveToTarget && _target != null)
            {
                Vector3 direction = _target.transform.position - transform.position;
                direction.Normalize();
                direction *= speed;

                _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity, direction, Time.deltaTime);
            }
        }

        public void MoveToTarget(Target target)
        {
            _target = target;
            _moveToTarget = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("wo");
            _rigidbody.AddForce(Vector2.left);
        }
    }
}