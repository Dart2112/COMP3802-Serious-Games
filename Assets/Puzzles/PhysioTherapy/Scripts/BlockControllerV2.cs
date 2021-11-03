using UnityEngine;

namespace Puzzles.PhysioTherapy.Scripts
{
    public class BlockControllerV2 : MonoBehaviour
    {
        private bool _playerControl;
        //private float moveInput = 0;
    
        // private float direction = -1;
        private Rigidbody2D _rb;
        private GameObject _uiBehaviour; // Object Containing the UIBehaviour Script
        private UIBehaviour _ui; // UIBehaviour script


        // Start is called before the first frame update
        void Start()
        {

            _uiBehaviour = GameObject.Find("UIBehaviour");
            _ui = _uiBehaviour.GetComponent<UIBehaviour>();
            _rb = gameObject.GetComponent<Rigidbody2D>();

            _ui.SetCurrentObjectName(gameObject);
            //ui.AdjustItemPositions();
            Debug.Log("CurrentObjectName " + this.name);
        }

        // Update is called once per frame
        void Update()
        {
            if (!_playerControl) {
                if (Input.GetKeyDown("space"))
                {
                    //Debug.Log("Space was pressed");
                    _playerControl = true;
                    _ui.SetDirection(0);
                    this._rb.gravityScale = 0.5f;
                    // Create new object of 3 based on prefab
                }
            }
        }
    }
}
