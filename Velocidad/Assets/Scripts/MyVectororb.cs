using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct MyVectororb
{
    public float magnitude => Mathf.Sqrt(x * x + y * y);
    public float x;
    public float y;

    public MyVectororb normalized
    {
        get
        {
            float distance = magnitude;
            if (distance < 0.0001f)
            {
                return new MyVectororb(0, 0);
            }
            return new MyVectororb(x / distance, y / distance);
        }
    }
    public MyVectororb(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return $"[{x},{y}]";
    }
    public static implicit operator Vector3(MyVectororb a)
    {
        return new Vector3(a.x, a.y, 0);
    }
    public MyVectororb Lerp(MyVectororb myVector, float t)
    {
        return this + (myVector - this) * t;
    }
    public void Draw(Color color)
    {
        Debug.DrawLine(new Vector3(0, 0, 0), this, color, 0);

    }
    public void Draw2(MyVectororb origin, Color color)
    {
        Debug.DrawLine(origin, this + origin, color, 0);

    }
    public void Normalize()
    {
        float magnitudeCache = magnitude;
        if (magnitudeCache < 0.001)
        {
            x = 0;
            y = 0;
        }
        else
        {
            x = x / magnitudeCache;
            y = y / magnitudeCache;
        }
    }
    public static MyVectororb operator +(MyVectororb a, MyVectororb b)
    {
        return new MyVectororb(a.x + b.x, a.y + b.y);

    }
    public static MyVectororb operator -(MyVectororb a, MyVectororb b)
    {
        return new MyVectororb(a.x - b.x, a.y - b.y);

    }
    public static MyVectororb operator *(MyVectororb a, float n)
    {
        return new MyVectororb(a.x * n, a.y * n);

    }
    public static implicit operator MyVectororb(Vector3 a)
    {
        return new MyVectororb(a.x, a.y);
    }
}