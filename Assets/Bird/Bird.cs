using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    [SerializeField] private float _launchPower = 600;
    [SerializeField] private float _waitForReset = 1.5f;
    [SerializeField] private float _weight = 1f;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if (PositionShouldBeReset())
        {
            ResetScene();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            ResetScene();
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = _weight;

        _birdWasLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        var newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
    
    private bool PositionShouldBeReset()
    {
        if (!_birdWasLaunched) return false;

        if (_timeSittingAround >= _waitForReset) return true;

        foreach (var bodies in GetComponents<Rigidbody2D>())
        {
            if (bodies.velocity.magnitude > 0.1)
            {
                return false;
            }
        }

        _timeSittingAround += Time.deltaTime;

        if (transform.position.x < -50 || transform.position.x > 50 || transform.position.y < -15 || transform.position.y > 50) return true;

        return false;
    }

    private void ResetScene()
    {
        var currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        LevelController.ResetScore();
    }
}
