using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    [SerializeField] private Vector2 _speed = new Vector2(0.1f, 1f);
    [SerializeField] private Vector2 _direction = new Vector2(-1, 0);
    [SerializeField] private bool _isLinkedToCamera = false;
    [SerializeField] private bool _isLooping = false;

    private List<SpriteRenderer> backgroundPart;

    private float _time;

    void Start()
    {
        if (_isLooping)
        {
            backgroundPart = new List<SpriteRenderer>();

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                SpriteRenderer r = child.GetComponent<SpriteRenderer>();

                if (r != null)
                {
                    backgroundPart.Add(r);
                }
            }

            backgroundPart = backgroundPart.OrderBy(
              t => t.transform.position.x
            ).ToList();
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(
          _speed.x * _direction.x,
          _speed.y * _direction.y,
          0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        if (_isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        if (_isLooping)
        {
            SpriteRenderer firstChild = backgroundPart.FirstOrDefault();

            if (firstChild != null)
            {
                if (firstChild.transform.position.x < Camera.main.transform.position.x)
                {
                    if (firstChild.IsVisibleFrom(Camera.main) == false)
                    {
                        SpriteRenderer lastChild = backgroundPart.LastOrDefault();

                        Vector3 lastPosition = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);

                        firstChild.transform.position = new Vector3(lastPosition.x + lastSize.x, firstChild.transform.position.y, firstChild.transform.position.z);

                        backgroundPart.Remove(firstChild);
                        backgroundPart.Add(firstChild);
                    }
                }
            }
        }
    }
}

