using UnityEngine;

namespace Puzzles.PhysioTherapy.Scripts
{
    public class CollisionBehaviour : MonoBehaviour
    {
        private GameObject _myPrefab;
        private Transform _startPos; // Block starting position

        private bool _collided; // Has this block collided with another block
        private bool _fail; // Missed Block

        private GameObject _uiBehaviour; // Global UI behaviour Script gameobject
        private UIBehaviour _ui; // UI behaviour Script

        void Start()
        {
            _uiBehaviour = GameObject.Find("UIBehaviour");
            _ui = _uiBehaviour.GetComponent<UIBehaviour>();
            _startPos = GameObject.Find("StartPos").transform;
        }


        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name == "Check") // If colliding with another check collider do nothing
            {
                return;
            }

            if (collision.name == "LeftBoxCollider")
            {
                _ui.SetDirection(1); // Making the block go right
            }
            else if (collision.name == "RightBoxCollider")
            {
                _ui.SetDirection(-1); // Making the block go left
            }
            else if (collision.name != "Floor" && !_collided)
            {
                _collided = true;
                // Determining the next block shape
                SelectNewPrefab();

                // Generating new block
                Instantiate(_myPrefab, _startPos.position, _startPos.rotation);
                _ui.UpdateBlockNo();

                // Destroying this script
                Destroy(this.transform.parent.gameObject.GetComponent<BlockControllerV2>());
            }
            else if (collision.name == "Floor" && _collided && !_fail)
            { // If colliding with the floor after colliding with another object and havent failed yet.
                _fail = true;

                // Determining the next block shape
                SelectNewPrefab();
                _ui.UpdateFail();

                // Destroying the object this script is attached to
                Destroy(this.transform.parent.gameObject);
            }
            else if (collision.name == "Floor" && !_fail)
            { // If colliding with floor and have not failed in the last few seconds
                _fail = true;

                // Determining next block shape
                SelectNewPrefab();
                _ui.UpdateFail();
                Instantiate(_myPrefab, _startPos.position, _startPos.rotation);

                Destroy(this.transform.parent.gameObject);
            }

        }

        // Psuedo-Randomly selects the next block
        private void SelectNewPrefab()
        {
            // Gets a random number between 1 and 3 (inclusive)
            int objNumber = Random.Range(1, 4);
            Debug.Log("Obhject number " + objNumber);

            if (objNumber == 1)
            {
                // Can access gameassets because its in the 'Resources' folder
                _myPrefab = GameAssets.i.block;
            }
            else if (objNumber == 2)
            {
                _myPrefab = GameAssets.i.block2;
            }
            else
            {
                _myPrefab = GameAssets.i.block3;
            }
        }
    }
}
