//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Roomba.cs (20/03/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Controlador del roomba										\\
// Fecha Mod:		20/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System;
using UnityEngine;
using MoonAntonio.Roomba.Clases;
#endregion

namespace MoonAntonio.Roomba
{
	/// <summary>
	/// <para>Controlador del roomba</para>
	/// </summary>
	public class Roomba : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Estado del roomba.</para>
		/// </summary>
		public Estados estado = Estados.Esperando;									// Estado del roomba
		/// <summary>
		/// <para>Stats del roomba.</para>
		/// </summary>
		public Estadisticas stats;													// Stats del roomba
		#endregion

		#region Actualizador
		/// <summary>
		/// <para>Actualizador de Roomba.</para>
		/// </summary>
		private void Update()// Actualizador de Roomba
		{
			switch (estado)
			{
				case Estados.Esperando:
					// Buscar si tiene bateria suficiente -> Buscando()
					// Cargarse si tiene poca bateria -> Cargando()
					if (Decidir() == true)
					{
						estado = Estados.Buscando;
					}
					else
					{
						estado = Estados.Cargando;
					}
					break;

				case Estados.Buscando:
					Buscar();
					// TODO En caso de que este buscando basura, tendra que elegir un objetivo -> Accion()
					// Calcular el camino
					break;

				case Estados.Accion:
					// TODO Con el objetivo seleccionado, ir a por el
					break;

				case Estados.Cargando:
					Cargar();
					// TODO Si esta con poca bateria o si tiene poco espacio, ir a vaciar y cargar
					break;

				default:
					// Si no es ningun estado predefinido, volver a reiniciar el ciclo
					estado = Estados.Esperando;
					break;
			}
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Decide si ir a <see cref="Buscar"/> o ir a <see cref="Cargar"/>.</para>
		/// </summary>
		/// <returns>La decision tomada.</returns>
		private bool Decidir()// Decide si ir a <see cref="Buscar"/> o ir a <see cref="Cargar"/>
		{
			if (stats.GetBateriaActual() <= 20f)
			{
				
			}

			return false;
		}

		private void Buscar()
		{

		}

		private void Cargar()
		{

		}
		#endregion
	}

	/// <summary>
	/// <para>Estados del Roomba.</para>
	/// </summary>
	public enum Estados
	{
		Esperando,
		Buscando,
		Accion,
		Cargando
	}
}
