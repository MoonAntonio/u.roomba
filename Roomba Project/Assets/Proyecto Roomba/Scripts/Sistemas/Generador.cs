//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Generador.cs (20/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Generador de obstaculos/Objetos								\\
// Fecha Mod:		29/03/2017													\\
// Ultima Mod:		Agregada funcionalidad										\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
#endregion

namespace MoonAntonio.Roomba
{
	/// <summary>
	/// <para>Generador de obstaculos/Objetos</para>
	/// </summary>
	public class Generador : MonoBehaviour 
	{
		#region Variables Publicas
		public float tiempoSpawn = 0f;
		public int maxSpawn = 0;
		public List<GameObject> objetos = new List<GameObject>();
		#endregion

		#region Variables Privadas
		private Grid grid;

		private List<GameObject> objetosPool = new List<GameObject>();

		private float tiempoActual = 0f;
		#endregion

		#region Init
		private void Start()
		{
			// Asignamos los ajustes
			grid = this.gameObject.GetComponentInChildren(typeof(Grid)) as Grid;

			objetosPool.Add(Resources.Load("Objeto01") as GameObject);
			objetosPool.Add(Resources.Load("Objeto02") as GameObject);
			objetosPool.Add(Resources.Load("Objeto03") as GameObject);
		}
		#endregion

		#region Actualizador
		private void Update()
		{
			if (objetos.Count >= maxSpawn || grid.isCompletado == false) return;

			Contador();
		}
		#endregion

		#region Metodos
		private void Contador()
		{
			tiempoActual = tiempoActual + 1 * Time.deltaTime;

			if (tiempoActual >= tiempoSpawn)
			{
				Generar(Random.Range(0,2));
				tiempoActual = 0f;
			}
		}

		private void Generar(int n)
		{
			switch (n)
			{
				case 0:
					GameObject go1 = Instantiate(objetosPool[0], grid.GetPosicionAleatoria(), Quaternion.identity);
					objetos.Add(go1);
					break;

				case 1:
					GameObject go2 = Instantiate(objetosPool[1], grid.GetPosicionAleatoria(), Quaternion.identity);
					objetos.Add(go2);
					break;

				case 2:
					GameObject go3 = Instantiate(objetosPool[2], grid.GetPosicionAleatoria(), Quaternion.identity);
					objetos.Add(go3);
					break;

				default:
					GameObject go4 = Instantiate(objetosPool[0], grid.GetPosicionAleatoria(), Quaternion.identity);
					objetos.Add(go4);
					break;
			}
		}
		#endregion
	}
}
