using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

namespace Unity.MLAgents.Extensions.Utils
{
    public class AreaManager : MonoBehaviour
    {
        public GameObject baseArea;
        public int numAreas = 8;
        public float separation = 20.0f;

        public void Awake()
        {
            Academy.Instance.OnEnvironmentReset += AddEnvironments;
        }

        void AddEnvironments()
        {
            var envParameters = Academy.Instance.EnvironmentParameters;
            int numAreas = (int) envParameters.GetWithDefault("num_areas", this.numAreas);

            for (int i = 0; i < numAreas - 1; i++)
            {
                Instantiate(baseArea, new Vector3(0, 0, (i + 1) * separation), Quaternion.identity);
            }
        }
    }
}
