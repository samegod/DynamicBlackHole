using Items.Pool;
using ItemsTarget;
using Pool;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Items.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Item : MonoBehaviourPoolObject, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private float lowestAppearMass;
        [SerializeField] private float highestAppearMass;
        [SerializeField] private float mass;
        [SerializeField] private ItemTypeId type;
        [SerializeField] private float speed;
        [SerializeField] private float pushStrength;
        
        private Rigidbody2D _rigidbody;
        private Target _target;
        private bool _moveToTarget;

        private float _maxSpeed = 2;

        public ItemTypeId TypeId => type;
        public float Mass => mass;
        public float LowestAppearMass => lowestAppearMass;
        public float HighestAppearMass => highestAppearMass;

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

                _rigidbody.velocity += (Vector2)(direction * Time.deltaTime);
            }
        }

        public void MoveToTarget()
        {
            _moveToTarget = true;
        }

        public void MoveToTarget(Target target)
        {
            _target = target;
            _moveToTarget = true;
        }

        public void StopMovingToTarget()
        {
            _moveToTarget = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            
        }

        public override void Push()
        {
            ItemsPool.Instance.Push(this);
        }
    }
}