using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    int bodyCount;
    float deltaTime;
    List<List<Vector3>> positionFrames;

    float startTime;
    List<GameObject> bodies;

    void Start()
    {
        ReadFile((Debug.isDebugBuild ? "Build/" : "") + "simulation.txt");
        Debug.Log($"Body count: {bodyCount}, delta time: {deltaTime}, frame count: {positionFrames.Count}");

        GenerateBodies();
        startTime = Time.time;
    }

    void ReadFile(string filename)
    {
        var streamReader = new StreamReader(filename);

        // Read body count and delta time
        var line1 = streamReader.ReadLine().Split();
        bodyCount = int.Parse(line1[0]);
        deltaTime = float.Parse(line1[1]);

        // Read empty line
        streamReader.ReadLine();

        // Read position frames
        positionFrames = new List<List<Vector3>>();
        while (!streamReader.EndOfStream)
        {
            // Read positions for each body
            var positionFrame = new List<Vector3>();
            for (int i = 0; i < bodyCount; i++)
            {
                var pos = streamReader.ReadLine().Split();
                positionFrame.Add(new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2])));
            }
            positionFrames.Add(positionFrame);

            // Read empty line
            streamReader.ReadLine();
        }
    }

    void GenerateBodies()
    {
        bodies = new();
        for (int i = 0; i < bodyCount; i++)
        {
            // Create a sphere with random color for each body
            var body = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            body.GetComponent<SphereCollider>().enabled = false;
            body.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
            bodies.Add(body);
        }
    }

    void Update()
    {
        UpdatePositions();
    }

    void UpdatePositions()
    {
        int frameInd = (int)((Time.time - startTime) / deltaTime);
        frameInd = Math.Clamp(frameInd, 0, positionFrames.Count - 1);
        var positions = positionFrames[frameInd];

        for (int i = 0; i < bodyCount; i++)
        {
            bodies[i].transform.position = positions[i];
        }

        Debug.Log($"Frame: {frameInd + 1}/{positionFrames.Count}");
    }
}
