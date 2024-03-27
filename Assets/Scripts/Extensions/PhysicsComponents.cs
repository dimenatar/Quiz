using UnityEngine;

namespace Extensions
{
    [System.Serializable]
    public struct PhysicsComponents
    {
        [SerializeField] public Rigidbody rigidbody;
        [SerializeField] public Collider collider;

        public PhysicsComponents(Rigidbody rigidbody, Collider collider)
        {
            this.rigidbody = rigidbody;
            this.collider = collider;
        }

        public void DisablePhysics()
        {
            rigidbody.isKinematic = true;
            collider.enabled = false;
        }

        public void EnablePhysics()
        {
            rigidbody.isKinematic = false;
            collider.enabled = true;
        }
    }
}