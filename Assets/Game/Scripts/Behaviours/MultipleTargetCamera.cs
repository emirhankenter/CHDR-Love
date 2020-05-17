using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    [RequireComponent(typeof(Camera))]
    public class MultipleTargetCamera : MonoBehaviour
    {
        [SerializeField] List<Transform> _targets;

        [SerializeField] private Vector3 offSet;
        [SerializeField] private float _smoothTime = .5f;

        [SerializeField] private float _minZoom = 40f;
        [SerializeField] private float _maxZoom = 10f;
        [SerializeField] private float _zoomLimiter = 50f;

        private Camera cam;

        private Vector3 velocity;

        private void Start()
        {
            cam = GetComponent<Camera>();
        }
        private void LateUpdate()
        {
            if (_targets.Count == 0)
            {
                return;
            }
            Move();
            Zoom();
        }

        private void Move()
        {
            Vector3 centerPoint = GetCenterPoint();

            Vector3 newPosition = centerPoint + offSet;

            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, _smoothTime);
        }

        private void Zoom()
        {
            float newZoom = Mathf.Lerp(_maxZoom, _minZoom, GetGreathestDistance() / _zoomLimiter);

            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
        }

        private Vector3 GetCenterPoint()
        {
            if (_targets.Count == 1)
            {
                return _targets[0].position;
            }

            var bounds = new Bounds(_targets[0].position, Vector3.zero);
            for (int i = 0; i < _targets.Count; i++)
            {
                bounds.Encapsulate(_targets[i].position);
            }
            return bounds.center;
        }

        private float GetGreathestDistance()
        {
            var bounds = new Bounds(_targets[0].position, Vector3.zero);

            for (int i = 0; i < _targets.Count; i++)
            {
                bounds.Encapsulate(_targets[i].position);
            }

            return bounds.size.x;
        }
    }
}