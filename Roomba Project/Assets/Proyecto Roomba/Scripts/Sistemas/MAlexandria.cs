//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MAlexandria.cs (20/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Manager del sistema											\\
// Fecha Mod:		20/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Roomba
{
	/// <summary>
	/// <para>Manager del sistema</para>
	/// </summary>
	public class MAlexandria : MonoBehaviour 
	{
		#region Variables Estaticas
		/// <summary>
		/// <para>Instancia del manager.</para>
		/// </summary>
		public static MAlexandria instance = null;                                  // Instancia del manager
		#endregion

		#region Iniciadores
		/// <summary>
		/// <para>Carga de MAlexandria.</para>
		/// </summary>
		private void Awake()// Carga de MAlexandria
		{
			// Singleton
			if (instance == null)
			{
				instance = this;
			}
			else if (instance != this)
			{
				Destroy(this.gameObject);
			}

			DontDestroyOnLoad(this.gameObject);
		}

		/// <summary>
		/// <para>Init de MAlexandria.</para>
		/// </summary>
		private void Start()// Init de MAlexandria
		{
			// Comprueba si existen errores antes de empezar
			CompruebaErrores();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Comprueba si hay errores iniciales.</para>
		/// </summary>
		private void CompruebaErrores()// Comprueba si hay errores iniciales
		{
			// Si el roomba no esta, instanciarlo
			if (Existe("Roomba") == false)
			{
				GameObject go = Instantiate(Resources.Load("Roomba")) as GameObject;
				go.transform.position = GameObject.Find("Manager").GetComponent<Spawnmer>().GetPosicion("SpawnJug");
			}
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Comprueba si el objeto existe.</para>
		/// </summary>
		private bool Existe(string nomObj)// Comprueba si el objeto existe
		{
			if (GameObject.Find(nomObj) != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
}
