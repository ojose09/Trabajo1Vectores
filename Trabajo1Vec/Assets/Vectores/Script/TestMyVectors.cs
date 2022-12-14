using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyVectors : MonoBehaviour
{
    [SerializeField] MyVector MyFirstVector = new MyVector(2, 3);
    [SerializeField] MyVector MySecondVector = new MyVector(3, 4);
    [Range(0, 1)] [SerializeField] float scalar = 0;

    void Start()
    {
        Vector2 au = new Vector2(2, 3);
        Vector2 bu = new Vector2(4, 5);
    }

    // Update is called once per frame
    void Update()
    {
        MyFirstVector.Draw(Color.red);
        MySecondVector.Draw(Color.green);

        //Multiplicación
        MyVector multi = (MySecondVector - MyFirstVector) * scalar;
        //multi.Draw(Color.yellow);
        multi.Draw(MyFirstVector, Color.yellow);

        //Vector Final
        MyVector final = multi + MyFirstVector;
        final.Draw(Color.blue);
      
    }
}