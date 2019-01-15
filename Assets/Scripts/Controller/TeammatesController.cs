using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class TeammatesController : MonoBehaviour
    {
        public static event Action<TeammateModel> TeammateSelected;

        private TeammateModel currentTeammate;

        public void MoveCommand()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var teammate = hit.collider.GetComponent<TeammateModel>();
                if (teammate) SelectTeammate(teammate);
                else if (currentTeammate) currentTeammate.AddDestination(hit.point);
            }
        }

        public void SelectTeammate(TeammateModel teammate)
        {
            currentTeammate = teammate;
            TeammateSelected.Invoke(currentTeammate);
        }
    }
}
