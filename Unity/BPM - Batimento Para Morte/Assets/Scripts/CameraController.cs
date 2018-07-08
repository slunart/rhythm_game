using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

    public GameObject player;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
	
	void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}
