using System;
using Items.Core;
using UnityEngine;

namespace ItemsInput
{
    public class ItemsInputSystem : MonoBehaviour
    {
        [SerializeField, Range(0f, 100f)] private float damping = 1f;
        [SerializeField, Range(0f, 100f)] private float frequency = 5f;

        private TargetJoint2D _targetJoint;
        private Item _currentDraggedItem;
        private Vector2 _currentDragPosition;
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                if (hit.collider != null)
                {
                    // Проверяем, есть ли компонент Item на объекте, по которому кликнули
                    Item item = hit.collider.GetComponent<Item>();
                    if (item != null)
                    {
                        ItemMouseDown(item);
                    }
                }
            }

            if (Input.GetMouseButton(0))
            {
                DragItem();
            }

            if (Input.GetMouseButtonUp(0))
            {
                ReleaseItem();    
            }
        }

        private void ItemMouseDown(Item item)
        {
            _currentDraggedItem = item;

            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            _targetJoint = item.gameObject.AddComponent<TargetJoint2D>();
            _targetJoint.dampingRatio = damping;
            _targetJoint.frequency = frequency;
            _targetJoint.anchor = _targetJoint.transform.InverseTransformPoint(mousePosition);
            
            _currentDraggedItem.StopMovingToTarget();
        }

        private void DragItem()
        {
            if (!_currentDraggedItem || !_targetJoint)
                return;
            
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _targetJoint.target = mousePosition;
        }

        private void ReleaseItem()
        {
            if (!_currentDraggedItem || !_targetJoint)
            {
                Debug.Log("No dragged item");
                return;
            }
            
            Destroy(_targetJoint);
            _currentDraggedItem.MoveToTarget();
            _currentDraggedItem = null;
        }

        private Vector3 GetMouseWorldPoint()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            return Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}