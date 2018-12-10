using System;
using System.Numerics;

namespace RTIOWCS
{
    internal class Camera : ICamera
    {
        private float _aperture = 2.0f;
        private float _aspect;
        private float _focusDistance;
        private Vector3 _horizontal;
        private float _lensRadius;
        private Vector3 _lookAt = new Vector3(0, 0, -1);
        private Vector3 _lookFrom = new Vector3(0f, 5f, 3f);
        private Vector3 _lowerLeftCorner;
        private Vector3 _origin;
        private float _resX;
        private float _resY;
        private Vector3 _u;
        private Vector3 _v;
        private Vector3 _vertical;
        private float _verticalFieldOfView = 20;
        private Vector3 _vUp = new Vector3(0, 1, 0);
        private Vector3 _w;

        public Vector3 VUp
        {
            get => _vUp;
            set
            {
                _vUp = value;
                Update();
            }
        }

        public Vector3 LookFrom
        {
            get => _lookFrom;
            set
            {
                _lookFrom = value;
                Update();
            }
        }

        public Vector3 LookAt
        {
            get => _lookAt;
            set
            {
                _lookAt = value;
                Update();
            }
        }

        public float VerticalFieldOfView
        {
            get => _verticalFieldOfView;
            set
            {
                _verticalFieldOfView = value;
                Update();
            }
        }

        public float Aperture
        {
            get => _aperture;
            set
            {
                _aperture = value;
                Update();
            }
        }

        public float FocusDistance
        {
            get => _focusDistance;
            set
            {
                _focusDistance = value;
                Update();
            }
        }

        public float ResX
        {
            get => _resX;
            set
            {
                _resX = value;
                _aspect = _resX / _resY;
                Update();
            }
        }

        public float ResY
        {
            get => _resY;
            set
            {
                _resY = value;
                _aspect = _resX / _resY;
                Update();
            }
        }

        public Ray GetRay(float s, float t)
        {
            var rd = _lensRadius * Utils.GetRandomInDisk();
            var offset = _u * rd.X + _v * rd.Y;
            return new Ray(_origin + offset, _lowerLeftCorner + s * _horizontal + t * _vertical - _origin);
        }

        private void Update()
        {
            _lensRadius = Aperture / 2;
            var theta = VerticalFieldOfView * (float) Math.PI / 180.0f;
            var halfHeight = (float) Math.Tan(theta / 2);
            var halfWidth = _aspect * halfHeight;
            _origin = LookFrom;
            _w = Vector3.Normalize(LookFrom - LookAt);
            _u = Vector3.Normalize(Vector3.Cross(VUp, _w));
            _v = Vector3.Cross(_w, _u);
            _lowerLeftCorner = _origin - halfWidth * _u * FocusDistance - halfHeight * _v * FocusDistance -
                               _w * FocusDistance;
            _horizontal = 2 * halfWidth * _u;
            _vertical = 2 * halfHeight * _v;
        }
    }
}