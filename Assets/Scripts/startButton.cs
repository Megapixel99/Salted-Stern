using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
	public void ChangeScene(string main)
	{
		SceneManager.LoadScene(main);
	}
}