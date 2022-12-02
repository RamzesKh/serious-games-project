using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private InputService inputService;
    private Rigidbody2D character;

    void Start()
    {
        character = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        character.MoveRotation(character.rotation - inputService.turnDirection * Time.fixedDeltaTime * 200);
        character.AddRelativeForce(Vector2.up * Time.fixedDeltaTime * movementSpeed);
    }
}
