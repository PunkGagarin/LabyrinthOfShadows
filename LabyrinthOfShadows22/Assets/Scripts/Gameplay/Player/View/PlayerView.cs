using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerView : MonoBehaviour
{

    [field: SerializeField]
    public Rigidbody2D Rigidbody2D { get; private set; }

    [field: SerializeField]
    public Light2D ConusLight { get; private set; }

}
