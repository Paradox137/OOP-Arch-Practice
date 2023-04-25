using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Asteroids.Framework.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids
{
	public class testa : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			StartCoroutine(Testing());
			
			UserInputActions s = new UserInputActions();
			s.Enable();
			s.Player.Rotate.started += Rotate;
			s.Player.Rotate.performed += Performe;
			s.Player.Rotate.canceled += Canceled;
		}

		private IEnumerator Testing()
		{
			CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
			TestAsync testAsync = new TestAsync(cancelTokenSource);
			testAsync.StartAsync(Time.deltaTime);

			yield return null;
			
			cancelTokenSource.Cancel();
		}
		void Canceled(InputAction.CallbackContext obj)
		{
			Debug.Log("Cancel " + obj.duration);
			Debug.Log(obj.action);
		}
		void Rotate(InputAction.CallbackContext obj)
		{
			Debug.Log("Rotate " + obj.ReadValue<Vector2>().x);
		}
		void Performe(InputAction.CallbackContext obj)
		{
			Debug.Log("Performed " + obj.duration);
		}
		// Update is called once per frame
		void Update()
		{
		}
	}

	public class TestAsync
	{
		CancellationTokenSource cancelTokenSource;

		public TestAsync(CancellationTokenSource __cancelTokenSource)
		{
			cancelTokenSource = __cancelTokenSource;
		}
		public async void StartAsync(float time)
		{
			Task newTask = new Task(() =>
			{
				while(!cancelTokenSource.IsCancellationRequested)
					Debug.Log(1);
			});
			newTask.Start();
			
			await Task.Yield();
		}
	}
}
