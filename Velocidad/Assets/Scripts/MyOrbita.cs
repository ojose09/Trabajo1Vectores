using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]

public class MyOrbita : MonoBehaviour
{
    private MyVectororb position;
    private MyVectororb acceleration;
    [SerializeField] float mass = 1;
    [SerializeField] float targetmass = 1;
    [SerializeField] private MyVectororb velocity;
    [SerializeField] Transform Target;
    [SerializeField] [Range(0, 1)] float gravity = -9.8f;

    private void Start()
    {
        position = transform.position;
    }
    public void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        transform.position = position;

    }
    private void FixedUpdate()
    {
        MyVectororb r = Target.position - transform.position;
        float weightScalar = mass * gravity;
        MyVectororb weight = new MyVectororb(0, weightScalar);
        acceleration *= 0f;
        float Magnituder = r.magnitude;
        MyVectororb F = r.normalized * (1 / targetmass * mass / Magnituder * Magnituder);

        ApplyForce(F);
        Move();
        F.Draw2(position, Color.red);
    }
    private void Update()
    {
        velocity.Draw2(position, Color.green);
    }

    void ApplyForce(MyVectororb force)
    {
        acceleration += force * (1f / mass);
    }
}
