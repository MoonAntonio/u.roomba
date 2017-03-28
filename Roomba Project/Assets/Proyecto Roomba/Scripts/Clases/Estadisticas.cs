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
using System;
#endregion

namespace MoonAntonio.Roomba.Clases
{
	/// <summary>
	/// <para>Clase de las estadisticas del roomba</para>
	/// </summary>
	[Serializable]
	public class Estadisticas
	{
		#region Variables Privadas
		private float vel;
		private float velMax;
		private float bateria;
		private float bateriaMax;
		private int deposito;
		private int depositoMax;
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Velocidad del roomba.</para>
		/// </summary>
		public float Velocidad
		{
			get { return vel; }
			set { vel = value; }
		}
		/// <summary>
		/// <para>Velocidad maxima del roomba.</para>
		/// </summary>
		public float VelocidadMax
		{
			get { return velMax; }
			set { velMax = value; }
		}
		/// <summary>
		/// <para>Bateria actual del roomba.</para>
		/// </summary>
		public float Bateria
		{
			get { return bateria; }
			set { bateria = value; }
		}
		/// <summary>
		/// <para>Bateria maxima del roomba.</para>
		/// </summary>
		public float BateriaMax
		{
			get { return bateriaMax; }
			set { bateriaMax = value; }
		}
		/// <summary>
		/// <para>Deposito actual del roomba.</para>
		/// </summary>
		public int Deposito
		{
			get { return deposito; }
			set { deposito = value; }
		}
		/// <summary>
		/// <para>Deposito maximo del roomba.</para>
		/// </summary>
		public int DepositoMax
		{
			get { return depositoMax; }
			set { depositoMax = value; }
		}
		#endregion
	}
}
