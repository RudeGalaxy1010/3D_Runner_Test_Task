using UnityEngine.EventSystems;
using UnityEngine;

// Register user input (for smartphone - swipes | for PC - 'A' and 'D' keys)
public class SwipeRegistrar : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    [Header("Swipes")]
    public float MinDeltaToRegister = 0.2f;

    [Header("PlayerMove component")]
    [SerializeField] private PlayerMove _player;

#if UNITY_STANDALONE
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _player.MovePlayerInXDirection(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _player.MovePlayerInXDirection(1);
        }
    }
#endif

    public void OnBeginDrag(PointerEventData eventData)
    {
        var xDelta = eventData.delta.x;
        if (Mathf.Abs(xDelta) > MinDeltaToRegister)
        {
            if (xDelta < 0)
            {
                _player.MovePlayerInXDirection(-1);
            }
            else if (xDelta > 0)
            {
                _player.MovePlayerInXDirection(1);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // This method is necessary to be here
        // !Swipes won't work without this!
    }
}
