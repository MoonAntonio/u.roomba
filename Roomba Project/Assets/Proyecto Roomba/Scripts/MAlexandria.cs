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

namespace MoonPincho
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
		public static MAlexandria instance = null;									// Instancia del manager
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
		#endregion
	}
}
