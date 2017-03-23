//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Spawnmer.cs (20/03/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Manager que spawmea objetos.								\\
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
	/// <para>Manager que spawmea objetos</para>
	/// </summary>
	public class Spawnmer : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Lista de los diferentes spawn que hay en la escena.</para>
		/// </summary>
		public List<GameObject> spawn = new List<GameObject>();						// Lista de los diferentes spawn que hay en la escena
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Obtiene la posicion de un spawm.</para>
		/// </summary>
		/// <returns>Posicion del spawn.</returns>
		public Vector3 GetPosicion(string nombSpawn)// Obtiene la posicion de un spawm
		{
			for (int n = 0; n < spawn.Count; n++)
			{
				if (spawn[n].gameObject.name == nombSpawn) return spawn[n].gameObject.transform.position;
			}

			return Vector3.zero;
		}
		#endregion
	}
}
