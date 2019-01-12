using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class TeammateView : BaseSceneObject
    {
        private TeammateModel model;

        protected override void Awake()
        {
            base.Awake();
            model = GetComponentInParent<TeammateModel>();
            TeammatesController.TeammateSelected += onTeammateSelected;
            IsVisible = false;
        }

        private void onTeammateSelected(TeammateModel teammate)
        {
            IsVisible = model == teammate;
        }

        private void OnDestroy()
        {
            TeammatesController.TeammateSelected -= onTeammateSelected;
        }
    }
}
