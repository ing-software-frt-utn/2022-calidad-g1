using IDS_TP1_Cliente.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormEmpleado : Form {
		private Empleado modificando;

		public FormEmpleado() {
			InitializeComponent();
			modificando = null;
		}

		public void Cargar(Empleado empleado) {
			modificando = empleado;
			txtNombre.Text = empleado.Nombre;
			txtApellido.Text = empleado.Apellido;
			txtContraseña.Text = empleado.Contraseña;
			txtContraseña2.Text = empleado.Contraseña;
			txtCorreo.Text = empleado.Correo;
			txtUsuario.Text = empleado.Usuario;
			numDNI.Value = empleado.DNI;
			numLegajo.Value = empleado.Legajo;
			dtFecha.Value = empleado.FechaNac;
			cmbRol.SelectedIndex = (int)empleado.Rol - 1;
		}

		private void BtnAceptar_Click(object sender, EventArgs e) {
			RespuestaABM respuesta;
			if (txtContraseña.Text != txtContraseña2.Text) {
				Mensajes.MostrarError("Las contraseñas no coinciden");
				return;
			}
			using (var service = new WebService.DSServiceSoapClient()) {
				if (modificando != null) {
					modificando.Nombre = txtNombre.Text;
					modificando.Apellido = txtApellido.Text;
					modificando.Contraseña = txtContraseña.Text;
					modificando.Correo = txtCorreo.Text;
					modificando.Usuario = txtUsuario.Text;
					modificando.DNI = (int)numDNI.Value;
					modificando.Legajo = (int)numLegajo.Value;
					modificando.FechaNac = dtFecha.Value;
					modificando.Rol = (RolEmpleado)(cmbRol.SelectedIndex + 1);
					respuesta = service.ModificarEmpleado(modificando);
				} else {
					respuesta = service.AñadirEmpleado(
						(int)numLegajo.Value,
						(int)numDNI.Value,
						txtNombre.Text,
						txtApellido.Text,
						(RolEmpleado)(cmbRol.SelectedIndex + 1),
						txtCorreo.Text,
						txtUsuario.Text,
						txtContraseña.Text,
						dtFecha.Value
					);
				}
			}
			switch (respuesta) {
				case RespuestaABM.Exito:
					if (modificando != null)
						Mensajes.MostrarMensaje("Empleado modificado");
					else
						Mensajes.MostrarMensaje("Empleado añadido");
					modificando = null;
					Close();
					break;
				case RespuestaABM.Error_Existente:
					Mensajes.MostrarError("Ya existe un empleado con el DNI o legajo ingresado");
					break;
				case RespuestaABM.Error_DatosInvalidos:
					Mensajes.MostrarError("Los datos no son válidos");
					break;
				case RespuestaABM.Error_DatosFaltantes:
					Mensajes.MostrarError("Hay datos faltantes");
					break;
			}
		}

		private void BtnCancelar_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
