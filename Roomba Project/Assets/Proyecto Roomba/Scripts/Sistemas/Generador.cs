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
		/// <summary>
		/// <para>Tiempo entre cada spawn</para>
		/// </summary>
		public float tiempoSpawn = 0f;										// Tiempo entre cada spawn
		/// <summary>
		/// <para>Maximo de objetos</para>
		/// </summary>
		public int maxSpawn = 0;											// Maximo de objetos
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Grid del manager</para>
		/// </summary>
		private Grid grid;													// Grid del manager
		/// <summary>
		/// <para>Piscina de objetos que se pueden instanciar</para>
		/// </summary>
		private List<GameObject> objetosPool = new List<GameObject>();		// Piscina de objetos que se pueden instanciar
		/// <summary>
		/// <para>Tiempo de spawn actual</para>
		/// </summary>
		private float tiempoActual = 0f;									// Tiempo de spawn actual
		#endregion

		#region Init
		/// <summary>
		/// <para>Init de Generador</para>
		/// </summary>
		private void Start()// Init de Generador
		{
			// Asignamos los ajustes
			grid = this.gameObject.GetComponentInChildren(typeof(Grid)) as Grid;

			objetosPool.Add(Resources.Load("Objeto01") as GameObject);
			objetosPool.Add(Resources.Load("Objeto02") as GameObject);
			objetosPool.Add(Resources.Load("Objeto03") as GameObject);
		}
		#endregion

		#region Actualizador
		/// <summary>
		/// <para>Actualizador de Generador</para>
		/// </summary>
		private void Update()// Actualizador de Generador
		{
			// Comprobamos si emos excedido el max de objetos o si el grid esta cargando
			if (grid.isCompletado == false) return;

			// Aumentamos el contador
			Contador();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Actualiza el tiempo.Contador que ejecuta <see cref="Generar(int)"/> al cabo de un tiempo en <see cref="tiempoSpawn"/>.</para>
		/// </summary>
		private void Contador()// Actualiza el tiempo.Contador que ejecuta <see cref="Generar(int)"/> al cabo de un tiempo en <see cref="tiempoSpawn"/>
		{
			// Contador
			tiempoActual = tiempoActual + 1 * Time.deltaTime;

			// Reseteo y generacion de objeto
			if (tiempoActual >= tiempoSpawn)
			{
				Generar(Random.Range(0,2));
				tiempoActual = 0f;
			}
		}

		/// <summary>
		/// <para>Genera un Objeto en la zona mediante una posicion dada en <see cref="Grid.GetPosicionAleatoria"/>.</para>
		/// </summary>
		/// <param name="n">Tipo de Objeto que instanciar de <see cref="objetosPool"/>.</param>
		private void Generar(int n)// Genera un Objeto en la zona mediante una posicion dada en <see cref="Grid.GetPosicionAleatoria"/>
		{
			switch (n)
			{
				case 0:
					GameObject go1 = Instantiate(objetosPool[0], grid.GetPosicionAleatoria(), Quaternion.identity);
					break;

				case 1:
					GameObject go2 = Instantiate(objetosPool[1], grid.GetPosicionAleatoria(), Quaternion.identity);
					break;

				case 2:
					GameObject go3 = Instantiate(objetosPool[2], grid.GetPosicionAleatoria(), Quaternion.identity);
					break;

				default:
					GameObject go4 = Instantiate(objetosPool[0], grid.GetPosicionAleatoria(), Quaternion.identity);
					break;
			}
		}
		#endregion
	}
}
