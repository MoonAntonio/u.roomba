//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Roomba.cs (20/03/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Controlador del roomba										\\
// Fecha Mod:		20/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System.Collections.Generic;
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
		public Estadisticas stats;                                                  // Stats del roomba
		/// <summary>
		/// <para>Limite de la bateria</para>
		/// </summary>
		public float limiteBateria = 0f;											// Limite de la bateria
		/// <summary>
		/// <para>Limite del deposito</para>
		/// </summary>
		public float limiteDeposito = 0f;                                           // Limite del deposito
		/// <summary>
		/// <para>Lista de objetos en escena.</para>
		/// </summary>
		public SortedList<float, GameObject> listaObjetos;                          // Lista de objetos en escena
		/// <summary>
		/// <para>Ruta que se genera.</para>
		/// </summary>
		public bool isRutaTest = false;												// Ruta que se genera
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Objetivo</para>
		/// </summary>
		public List<GameObject> objetivos = new List<GameObject>();				// Objetivos
		/// <summary>
		/// <para>Esta cargando el roomba</para>
		/// </summary>
		public bool isCargando = false;											// Esta cargando el roomba
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
					// Buscar un objetivo
					Buscar();
					break;

				case Estados.Accion:
					// Con el objetivo seleccionado, ir a por el
					MoverAlObjetivo();
					break;

				case Estados.Cargando:
					// Si esta con poca bateria o si tiene poco espacio, ir a vaciar y cargar
					Cargar();
					break;

				default:
					// Si no es ningun estado predefinido, volver a reiniciar el ciclo
					estado = Estados.Esperando;
					break;
			}

			if (isCargando != true) stats.Bateria = stats.Bateria - 1 * Time.deltaTime;
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Decide si ir a <see cref="Buscar"/> o ir a <see cref="Cargar"/>.</para>
		/// </summary>
		/// <returns>La decision tomada.True si ira a buscar, false si ira a cargar</returns>
		private bool Decidir()// Decide si ir a <see cref="Buscar"/> o ir a <see cref="Cargar"/>
		{
			// Si la bateria es superior al estipulado
			if (stats.GetBateriaActual() >= limiteBateria)
			{
				// Si el deposito es inferior al estipulado
				if (stats.GetDepositoActual() <= limiteDeposito)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// <para>Busca un objetivo</para>
		/// </summary>
		private void Buscar()// Busca un objetivo
		{
			GameObject[] go = GameObject.FindGameObjectsWithTag("Objeto");
			listaObjetos = new SortedList<float, GameObject>();

			// Recorremos la lista
			foreach (GameObject objeto in go)
			{
				listaObjetos.Add(Vector3.Distance(transform.position, objeto.transform.position), objeto);
			}

			objetivos = new List<GameObject>(listaObjetos.Values);

			if (listaObjetos.Count != 0 && isRutaTest == true)
			{
				Debug.DrawLine(this.transform.position, objetivos[0].transform.position, Color.blue, 100f);
				if(objetivos[0].gameObject.tag == "Objeto") estado = Estados.Accion;
			} 
		}

		/// <summary>
		/// <para>Mueve al Roomba al objetivo</para>
		/// </summary>
		private void MoverAlObjetivo()// Mueve al Roomba al objetivo
		{
			if (objetivos == null)
			{
				estado = Estados.Esperando;
			}

			// Movimiento y rotacion
			transform.Translate(Vector3.forward * stats.Velocidad * Time.deltaTime);
			transform.LookAt(objetivos[0].transform);

			// Debug ray
			Debug.DrawLine(this.transform.position, objetivos[0].transform.position,Color.red);

			if (Vector3.Distance(transform.position, objetivos[0].transform.position) < 1f) RecogerObjeto(objetivos[0]);
		}

		/// <summary>
		/// <para>Recoge el objeto</para>
		/// </summary>
		/// <param name="go">Prefab del objeto</param>
		private void RecogerObjeto(GameObject go)// Recoge el objeto
		{
			stats.AddDeposito(1);
			DestroyImmediate(go);
			objetivos.Clear();
			estado = Estados.Esperando;
		}

		/// <summary>
		/// <para>Carga el roomba</para>
		/// </summary>
		private void Cargar()
		{
			// TODO Implementar
			estado = Estados.Esperando;
		}

		/// <summary>
		/// <para>Cuando algo entra en el trigger</para>
		/// </summary>
		/// <param name="other">Otro collider</param>
		public void OnTriggerEnter(Collider other)// Cuando algo entra en el trigger
		{
			if (other.tag == "Objeto")
			{
				Debug.Log("Exit");
				RecogerObjeto(other.gameObject);
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
