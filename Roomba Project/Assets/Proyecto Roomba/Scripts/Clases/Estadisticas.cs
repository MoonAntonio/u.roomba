﻿//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Estadisticas.cs (20/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Clase de las estadisticas del roomba						\\
// Fecha Mod:		29/03/2017													\\
// Ultima Mod:		Agregado API												\\
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
		[SerializeField]
		private float vel;
		[SerializeField]
		private float bateria;
		[SerializeField]
		private float bateriaMax;
		[SerializeField]
		private int deposito;
		[SerializeField]
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

		#region API
		/// <summary>
		/// <para>Obtiene la bateria actual en porcentaje.</para>
		/// </summary>
		/// <returns>Bateria en %</returns>
		public float GetBateriaActual()// Obtiene la bateria actual en porcentaje
		{
			float temp = 100 * Bateria / BateriaMax;

			return temp;
		}

		/// <summary>
		/// <para>Obtiene el deposito actual en %</para>
		/// </summary>
		/// <returns>Deposito en %</returns>
		public float GetDepositoActual()// Obtiene el deposito actual en %
		{
			float temp = 100 * Deposito / DepositoMax;

			return temp;
		}

		/// <summary>
		/// <para>Agrega i al deposito actual.</para>
		/// </summary>
		/// <param name="i">Cantidad a agregar al deposito.</param>
		public void AddDeposito(int i)// Agrega i al deposito actual
		{
			Deposito= i;
		}
		#endregion
	}
}
