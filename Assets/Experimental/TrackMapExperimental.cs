﻿using Perrinn424.TrackMapSystem;
using Perrinn424.Utilities;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics;

public class TrackMapExperimental : MonoBehaviour
{
    public Image image;
    public VPReplayAsset replay;

    private CircularIterator<Vector3> iterator;

    public Vector3 s;
    public Vector3 p;
    public Vector3 r;
    public Quaternion quaternion;
    public Rect rect;

    public Vector3[] positions;
    public TrackPosition[] trackPositions;

    public TrackMapData trackMapData;

    public struct TrackPosition
    {
        public Vector3 position;
        public Image image;
    }

    //[Range(0.04f, 0.05f)]
    public float scale;
    public float rotation;
    public float position;

    public TrackMap trackMap;

    private void Awake()
    {
        replay.GetPositions(1.0f, out var positions, out _);
        iterator = new CircularIterator<Vector3>(positions);


        trackPositions = new TrackPosition[positions.Length];

        for (int i = 0; i < positions.Length; i++)
        {
            trackPositions[i] = new TrackPosition() { position = positions[i], image = GameObject.Instantiate(image, image.transform.parent) };
        }

        image.color = Color.red;
        image.transform.SetSiblingIndex(image.transform.childCount);

        StartCoroutine(NextPosition());
    }

    private IEnumerator NextPosition()
    {
        var wait = new WaitForSeconds(0.05f);
        while (true)
        {
            iterator.MoveNext();
            yield return wait;
        }
    }

    public void Update()
    {
        Vector3 pos = iterator.Current;

        //Matrix4x4 transformationMatrix = Calculate();

        trackMapData.CalculateTRS((RectTransform)transform);

        Vector3 localPos = trackMapData.FromWorldPositionToLocalRectTransformPosition(pos);
        image.transform.localPosition = localPos;

        for (int i = 0; i < trackPositions.Length; i++)
        {
            localPos = trackMapData.FromWorldPositionToLocalRectTransformPosition(trackPositions[i].position);
            trackPositions[i].image.transform.localPosition = localPos;
        }
    }

    //public Matrix4x4 Calculate()
    //{
    //    RectTransform rectTransform = (RectTransform)transform;
    //    rect = rectTransform.rect;
    //    Vector2 pivot = rectTransform.pivot;



    //    //quaternion = Quaternion.Euler(r);
    //    quaternion = Quaternion.AngleAxis(rotation, Vector3.forward) * Quaternion.AngleAxis(-90f, Vector3.right);
        
        
    //    s = new Vector3(rect.width, 0, rect.height)*scale;

    //    p = new Vector3((position - pivot.x)*rect.width, (position - pivot.y)* rect.height);
    //    return Matrix4x4.TRS(p, quaternion, s);
    //}
}