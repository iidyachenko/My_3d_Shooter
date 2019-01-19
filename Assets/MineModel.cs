using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS
{
    public class MineModel : MonoBehaviour
    {

        [SerializeField]
        private Boom boom;

        private void OnTriggerEnter(Collider other)
        {
            ExplosionDamage(gameObject.transform.position, 10);
            Destroy(gameObject);
            Instantiate(boom, transform.position, Quaternion.identity);

        }

        private void ExplosionDamage(Vector3 center, float radius)
        {
            Collider[] hitColliders = Physics.OverlapSphere(center, radius);
            int i = 0;
            while (i < hitColliders.Length)
            {
                Debug.Log(hitColliders[i].name);
                if (hitColliders[i].GetComponent<Rigidbody>() != null)
                {
                    hitColliders[i].GetComponent<Rigidbody>().AddExplosionForce(10000, gameObject.transform.position, 10);
                }
                i++;
            }
        }
    }
}
