using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShapeGenerator
{

    ShapeSettings Settings;

    public static Vector2 PointToCoordinate(Vector3 pointOnUnitSphere)
    {
        float latitude = (float)Math.Asin(pointOnUnitSphere.y);
        float longitude = (float)Math.Atan2(pointOnUnitSphere.x, -pointOnUnitSphere.z);
        return new Vector2(latitude, longitude);
    }

    public static Vector3 CoordinateToPoint(Vector2 coordinate)
    {
        float y = (float)Math.Sin(coordinate.x);
        float r = (float)Math.Cos(coordinate.x);
        float x = (float)Math.Sin(coordinate.y) * r;
        float z = -(float)Math.Cos(coordinate.y) * r;
        return new Vector3(x, y, z);
    }

    // public static float CoordinateToHeight(Vector3 pointOnUnitSphere)
    // {
    //     Vector2 BitmapCoordinates = PointToCoordinate(pointOnUnitSphere);
    //     return heightmap;
    // }

    public ShapeGenerator(ShapeSettings settings)
    {
        this.Settings = settings;
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        return pointOnUnitSphere * Settings.planetRadius * Settings.planetHeight;
    }
}
