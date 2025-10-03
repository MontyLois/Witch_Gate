using DG.Tweening;
using UnityEngine;

namespace Scripts.Core
{
    public class Character_Target : MonoBehaviour
    {

        [SerializeField] private GameObject character;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            character = GameObject.FindWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            transform.DOMove(GetMovement(), 0);
        }
    
        private Vector3 GetMovement() => new Vector3()
        {
            x = character.transform.position.x,
            y = character.transform.position.y,
            z = this.transform.position.z,
        };
    }
}
