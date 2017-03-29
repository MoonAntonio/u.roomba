//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Gid.cs (29/03/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Grid de la zona												\\
// Fecha Mod:		29/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
#endregion

namespace MoonAntonio.Roomba
{
	/// <summary>
	/// <para>Grid de la zona</para>
	/// </summary>
	public class Grid : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Largo del grid</para>
		/// </summary>
		public int xGrid;										// Largo del grid
		/// <summary>
		/// <para>Ancho del grid</para>
		/// </summary>
		public int zGrid;										// Ancho del grid
		/// <summary>
		/// <para>Tiempo hasta el nuevo spawn</para>
		/// </summary>
		public float tiempoSpawn = 0.0f;						// Tiempo hasta el nuevo spawn
		/// <summary>
		/// <para>Todos los vertices del grid</para>
		/// </summary>
		public Vector3[] vertices;                              // Todos los vertices del grid
		/// <summary>
		/// <para>Si esta completada la generacion</para>
		/// </summary>
		public bool isCompletado = false;						// Si esta completada la generacion
		#endregion

		#region Init
		/// <summary>
		/// <para>Init Grid</para>
		/// </summary>
		private void Awake()// Init Grid
		{
			StartCoroutine(Generar());
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Generamos el grid.</para>
		/// </summary>
		/// <returns></returns>
		private IEnumerator Generar()// Generamos el grid
		{
			// Esperamos hasta que termine el tiempo de spawn
			WaitForSeconds wait = new WaitForSeconds(tiempoSpawn);
			vertices = new Vector3[(xGrid + 1) * (zGrid + 1)];

			// Generamos el array (Area)
			for (int n = 0, z = 0; z <= zGrid; z++)
			{
				for (int x = 0; x <= xGrid; x++, n++)
				{
					vertices[n] = new Vector3(x, 0.5f, z);
					yield return wait;
				}
			}

			// Generacion completada
			isCompletado = true;
		}

		/// <summary>
		/// <para>Cuando renderiza</para>
		/// </summary>
		private void OnDrawGizmos()// Cuando renderiza
		{
			// Si no hay vertices return
			if (vertices == null) return;

			Gizmos.color = Color.black;

			// Renderizamos los vertices
			for (int n = 0; n < vertices.Length; n++)
			{
				Gizmos.DrawSphere(vertices[n], 0.1f);
			}
		}
		#endregion
	}
}
