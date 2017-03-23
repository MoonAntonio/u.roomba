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
	[Serializable]
	public class Roomba : MonoBehaviour 
	{
		#region Variables Publicas
		public Estados estado = Estados.Esperando;
		public Estadisticas stats;
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
					// TODO El Roomba esperara un tiempo mientras decide lo que hacer
					// Buscar si tiene bateria suficiente -> Buscando()
					// Cargarse si tiene poca bateria -> Cargando()
					break;

				case Estados.Buscando:
					// TODO En caso de que este buscando basura, tendra que elegir un objetivo -> Accion()
					// Calcular el camino
					break;

				case Estados.Accion:
					// TODO Con el objetivo seleccionado, ir a por el
					break;

				case Estados.Cargando:
					// TODO Si esta con poca bateria o si tiene poco espacio, ir a vaciar y cargar
					break;

				default:
					// Si no es ningun estado predefinido, volver a reiniciar el ciclo
					estado = Estados.Esperando;
					break;
			}
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
