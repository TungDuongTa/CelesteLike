using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour
{
    public Transform target;
    public bool mainHairPart = false;

    public float lerpSpeed = 5f;
    public float maxDistance = .5f;
    public float gravity = -.1f;

    private PlayerMovement2D movement;
    private bool _ready = false;

    private void OnDestroy()
    {
        movement.hairGravity -= SetGravity;
    }
    public void InitHair(PlayerMovement2D movement, Transform hairAnchor)
    {
        this.movement = movement;

        if (mainHairPart)
        {
            target = hairAnchor;
        }

        movement.hairGravity += SetGravity;
        _ready = true;
    }

    private void OnDisable()
    {
        movement.hairGravity -= SetGravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_ready) return;

        transform.position = new Vector3(transform.position.x, transform.position.y + gravity, transform.position.z); //Apply gravity

        Vector2 difference = transform.position - target.position;
        Vector2 direction = difference.normalized;
        float dist = Mathf.Min(maxDistance, difference.magnitude); //Returns the distance to multiply the vector by

        Vector2 finalPos = (Vector2)target.position + direction * dist; //Final pos of the clamped vector

        Vector2 newPositionLerped = Vector2.Lerp(finalPos, target.position, Time.deltaTime * lerpSpeed); //Lerp from current to new pos

        transform.position = newPositionLerped;
    }

    private void SetGravity(float newGravity)
    {
        gravity = newGravity;
    }
}