using UnityEngine;

namespace ItemsTarget
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private float gravityFallof;

        public float GravityFallof => gravityFallof;
    }
}