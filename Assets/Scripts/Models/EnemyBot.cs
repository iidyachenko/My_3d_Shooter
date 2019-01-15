using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPS
{
    public class EnemyBot : MonoBehaviour, IDamageable
    {
        public Transform EyesTransform;
        public float SearchDistance;
        public float AtackDistance;
        public float MeleAtackDistance;
        public float maxRandomRadius = 20f;
        private Waypoint[] waypoints;
        private int currentWP;
        private float currentWPTimeout;
        private bool useRandomWP;
        [SerializeField]
        private Transform TargetTransform;
        private NavMeshAgent agend;
        private bool seenTarget;
        private Vector3 RandomPos;
        private MeleWeapon meleWeapon;
        //[SerializeField]
        private BaseWeapon weapon;
        [SerializeField]
        private float Health = 50f;
        public float CurentHealth { get; set; }
        public bool isAlive { get { return CurentHealth > 0; } }

        public void Initialize(BotSpawner spawner)
        {
            agend = GetComponent<NavMeshAgent>();
            weapon = GetComponentInChildren<BaseWeapon>();
            meleWeapon = GetComponentInChildren<MeleWeapon>();
            CurentHealth = Health;
            waypoints = spawner.Waypoints;
            useRandomWP = waypoints == null || waypoints.Length < 2;

            Main.Instance.EnemyBotsController.AddBot(this);
        }

        private void Update()
        {
            seenTarget = false;
            if (TargetTransform)
            {
                var dist = Vector3.Distance(transform.position, TargetTransform.position);

                if (dist < MeleAtackDistance) //атакуем в ближнем бою
                {
                    seenTarget = IsTargetSeen();
                    if (seenTarget)
                    {
                        meleWeapon.Fire();
                        agend.SetDestination(TargetTransform.position);
                    }
                }
                else if (dist < AtackDistance) //атакуем дистанционно
                {
                    seenTarget = IsTargetSeen();
                    if (seenTarget)
                    {
                        weapon.Fire();
                        agend.SetDestination(TargetTransform.position);
                    }
                }
                else if (dist < SearchDistance) //сближаемся
                {
                    seenTarget = IsTargetSeen();
                    if (seenTarget)
                        agend.SetDestination(TargetTransform.position);
                }
            }

            if (seenTarget) return;

            if (useRandomWP)
            {
                agend.SetDestination(RandomPos);
                if (!agend.hasPath || agend.remainingDistance > maxRandomRadius * 2)
                    RandomPos = GenerateRandomPosition();
            }
            else
            {
                if (waypoints == null || waypoints.Length < 2)
                {
                    useRandomWP = true;
                }
                else
                {
                    agend.SetDestination(waypoints[currentWP].transform.position);
                    if (!agend.hasPath)
                    {
                        currentWPTimeout += Time.deltaTime;
                        if (currentWPTimeout > waypoints[currentWP].whaitTime)
                        {
                            currentWPTimeout = 0;
                            currentWP++;
                            if (currentWP >= waypoints.Length) currentWP = 0;
                        }
                    }
                }
            }
        }

        public void SetTarget(Transform Target)
        {
            TargetTransform = Target;
        }

        private Vector3 GenerateRandomPosition()
        {
            var result = maxRandomRadius * UnityEngine.Random.insideUnitSphere;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position + result, out hit, maxRandomRadius * 1.5f, NavMesh.AllAreas))
                return hit.position;
            else
                return transform.position;
        }

        private bool IsTargetSeen()
        {
            RaycastHit hit;
            if (Physics.Linecast(EyesTransform.position, TargetTransform.position, out hit) && hit.transform == TargetTransform)
            {
                Debug.DrawLine(EyesTransform.position, hit.point, Color.red);
                return true;
            }
            Debug.DrawLine(EyesTransform.position, hit.point, Color.green);
            return false;
        }

        public void ApplyDamage(float damage, Vector3 DamageDirection)
        {
            ApplyDamage(damage);
        }

        public void ApplyDamage(float damage)
        {
            if (!isAlive) return;
            CurentHealth -= damage;
            if (!isAlive) Death();
        }

        private void Death()
        {
            Main.Instance.EnemyBotsController.RemoveBot(this);
            foreach (var child in GetComponentsInChildren<Transform>())
            {
                child.SetParent(null);
                Destroy(child.gameObject, UnityEngine.Random.Range(2f, 4f));
                var col = child.GetComponent<Collider>();
                if (col) col.enabled = true;
                var rb = child.gameObject.AddComponent<Rigidbody>();
                rb.mass = 5;
                rb.AddForce(Vector3.up * UnityEngine.Random.Range(10f, 30f), ForceMode.Impulse);
            }
        }
    }
}