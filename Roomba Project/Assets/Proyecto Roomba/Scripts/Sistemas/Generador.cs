//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Generador.cs (20/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Generador de obstaculos										\\
// Fecha Mod:		20/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
#endregion

namespace MoonAntonio.Roomba
{
	/// <summary>
	/// <para>Generador de obstaculos</para>
	/// </summary>
	public class Generador : MonoBehaviour 
	{

		public Transform[] perimetro;
			

		private List<GameObject> objetosSpawn = new List<GameObject>();



		private void Start()
		{
			objetosSpawn.Add((Resources.Load("Objeto01")) as GameObject);
			objetosSpawn.Add((Resources.Load("Objeto02")) as GameObject);
			objetosSpawn.Add((Resources.Load("Objeto03")) as GameObject);
		}

		private void Update()
		{
			Ray();
		}

		private void Ray()
		{
			// Linea #1
			Debug.DrawLine(perimetro[0].position, perimetro[1].position, Color.red);
			Debug.DrawLine(perimetro[1].position, perimetro[2].position, Color.red);
			Debug.DrawLine(perimetro[2].position, perimetro[3].position, Color.red);
			Debug.DrawLine(perimetro[3].position, perimetro[0].position, Color.red);

			// Linea #2
			Debug.DrawLine(perimetro[0].position, perimetro[0].up * 10, Color.red);
			Debug.DrawLine(perimetro[1].position, perimetro[1].up * 10, Color.red);
			Debug.DrawLine(perimetro[2].position, perimetro[2].up * 10, Color.red);
			Debug.DrawLine(perimetro[3].position, perimetro[3].up * 10, Color.red);

			// Linea #3
			Debug.DrawLine(perimetro[0].position + new Vector3(0, 1, 0), perimetro[1].position, Color.magenta);
			Debug.DrawLine(perimetro[1].position + new Vector3(0, 1, 0), perimetro[2].position, Color.magenta);
			Debug.DrawLine(perimetro[2].position + new Vector3(0, 1, 0), perimetro[3].position, Color.magenta);
			Debug.DrawLine(perimetro[3].position + new Vector3(0, 1, 0), perimetro[0].position, Color.magenta);

			// Linea #4
			Debug.DrawLine(perimetro[0].position, perimetro[1].position + new Vector3(0, 1, 0), Color.magenta);
			Debug.DrawLine(perimetro[1].position, perimetro[2].position + new Vector3(0, 1, 0), Color.magenta);
			Debug.DrawLine(perimetro[2].position, perimetro[3].position + new Vector3(0, 1, 0), Color.magenta);
			Debug.DrawLine(perimetro[3].position, perimetro[0].position + new Vector3(0, 1, 0), Color.magenta);

			// Linea #5
			Debug.DrawLine(perimetro[0].position + new Vector3(0, 1, 0), perimetro[1].position + new Vector3(0, 1, 0), Color.red);
			Debug.DrawLine(perimetro[1].position + new Vector3(0, 1, 0), perimetro[2].position + new Vector3(0, 1, 0), Color.red);
			Debug.DrawLine(perimetro[2].position + new Vector3(0, 1, 0), perimetro[3].position + new Vector3(0, 1, 0), Color.red);
			Debug.DrawLine(perimetro[3].position + new Vector3(0, 1, 0), perimetro[0].position + new Vector3(0, 1, 0), Color.red);
		}
	}
}
