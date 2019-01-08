using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public abstract class BaseAmmo : BaseSceneObject
    {
        [SerializeField]
        protected float damage = 20f;

        protected override void Awake()
        {
            _gameobject = GetComponent<GameObject>();
            _rigidbody = GetComponent<Rigidbody>();
            Name = name;
            _layer = gameObject.layer;

            _renderer = GetComponent<Renderer>();
            if (_renderer)
                _material = _renderer.material;
        }

        public abstract void Initialize(float force);
    }

}
