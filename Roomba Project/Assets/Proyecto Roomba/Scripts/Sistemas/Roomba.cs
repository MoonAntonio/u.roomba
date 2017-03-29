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
		public Estadisticas stats;                                                  // Stats del roomba
		/// <summary>
		/// <para>Limite de la bateria</para>
		/// </summary>
		public float limiteBateria = 0f;											// Limite de la bateria
		/// <summary>
		/// <para>Limite del deposito</para>
		/// </summary>
		public float limiteDeposito = 0f;                                           // Limite del deposito
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Objetivo</para>
		/// </summary>
		public GameObject objetivo;                                                // Objetivo
		/// <summary>
		/// <para>Esta cargando el roomba</para>
		/// </summary>
		private bool isCargando = false;											// Esta cargando el roomba
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

			// Recorremos la lista
			foreach (GameObject objeto in go)
			{
				// Si no hay objetivo, asignarle uno
				if (objetivo == null)
				{
					objetivo = objeto;
					estado = Estados.Accion;
					return;
				}
			}

			if(objetivo != null) Debug.DrawLine(this.transform.position, objetivo.transform.position, Color.blue,100f);
		}

		/// <summary>
		/// <para>Mueve al Roomba al objetivo</para>
		/// </summary>
		private void MoverAlObjetivo()// Mueve al Roomba al objetivo
		{
			if (objetivo == null)
			{
				estado = Estados.Esperando;
			}

			// Movimiento y rotacion
			transform.Translate(Vector3.forward * stats.Velocidad * Time.deltaTime);
			transform.LookAt(objetivo.transform);

			// Debug ray
			Debug.DrawLine(this.transform.position, objetivo.transform.position,Color.red);

			Ray ray = new Ray(this.transform.position, Vector3.forward);
			RaycastHit hit;

			if (Physics.Raycast(ray,out hit))
			{
				// Recoger el objeto
				RecogerObjeto(hit.transform.gameObject);
			}
		}

		/// <summary>
		/// <para>Recoge el objeto</para>
		/// </summary>
		/// <param name="go">Prefab del objeto</param>
		private void RecogerObjeto(GameObject go)// Recoge el objeto
		{
			Debug.Log("Recoger Objeto");
			stats.AddDeposito(1);
			DestroyImmediate(go);
			objetivo = null;
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
