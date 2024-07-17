using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactPointsController : MonoBehaviour
{
    public ArtifactPoints artifactPoints;
    void Start()
    {
        artifactPoints = new ArtifactPoints();
        artifactPoints.SetPoints(0);
    }

    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
