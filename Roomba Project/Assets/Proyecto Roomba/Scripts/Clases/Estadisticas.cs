//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Estadisticas.cs (20/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Clase de las estadisticas del roomba						\\
// Fecha Mod:		20/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Roomba.Clases
{
	/// <summary>
	/// <para>Clase de las estadisticas del roomba</para>
	/// </summary>
	public class Estadisticas
	{
		public float velocidad = 0.0f;
		public float bateria = 0.0f;
		public float bateriaMax = 0.0f;
		public int deposito = 0;
		public int depositoMax = 0;
	}
}
