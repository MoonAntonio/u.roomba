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
		public List<GameObject> objetosSpawn = new List<GameObject>();

		private void Start()
		{
			objetosSpawn.Add((Resources.Load("Objeto01")) as GameObject);
			objetosSpawn.Add((Resources.Load("Objeto02")) as GameObject);
			objetosSpawn.Add((Resources.Load("Objeto03")) as GameObject);
		}
	}
}
