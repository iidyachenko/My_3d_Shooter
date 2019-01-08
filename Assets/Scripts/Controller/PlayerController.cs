
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class PlayerController : BaseController
    {

        [SerializeField]
        private float distance;
        private Ray ray;
        public RaycastHit hit;
        private Transform objectHit;


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);

            if (Physics.Raycast(ray, out hit, distance))
            {
                objectHit = hit.transform;
                if (objectHit.tag == "Box")
                {
                    //Debug.Log(objectHit.tag);
                }
            }
        }

        public void Get_Object(RaycastHit hit)
        {
            if (hit.transform.parent == null)
                hit.transform.parent = gameObject.transform;
            else hit.transform.parent = null;

        }
            
    }
}
