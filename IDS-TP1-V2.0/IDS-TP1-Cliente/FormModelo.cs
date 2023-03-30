
using IDS_TP1_Cliente.WebService;
using System;
using System.Windows.Forms;

namespace IDS_TP1_Cliente {
	public partial class FormModelo : Form {

		private Modelo modificando;

		public FormModelo() {
			modificando = null;
			InitializeComponent();
		}

		public void Cargar(Modelo modelo) {
			numSKU.Value = modelo.SKU;
			txtDenominacion.Text = modelo.Denominacion;
			numLIO.Value = modelo.LimiteInferiorObservado;
			numLIR.Value = modelo.LimiteInferiorReproceso;
			numLSO.Value = modelo.LimiteSuperiorObservado;
			numLSR.Value = modelo.LimiteSuperiorReproceso;
			modificando = modelo;
			numSKU.Enabled = false;
		}

		private void BtnAceptar_Click(object sender, EventArgs e) {
			RespuestaABM respuesta;
			using (var service = new WebService.DSServiceSoapClient()) {
				if (modificando != null) {
					modificando.Denominacion = txtDenominacion.Text;
					modificando.LimiteInferiorObservado = (int)numLIO.Value;
					modificando.LimiteInferiorReproceso = (int)numLIR.Value;
					modificando.LimiteSuperiorObservado = (int)numLSO.Value;
					modificando.LimiteSuperiorReproceso = (int)numLSR.Value;
					respuesta = service.ModificarModelo(modificando);
				} else {
					respuesta = service.AñadirModelo(
						(long)numSKU.Value,
						txtDenominacion.Text,
						(int)numLIR.Value,
						(int)numLIO.Value,
						(int)numLSR.Value,
						(int)numLSO.Value
					);
				}
			}
			switch (respuesta) {
				case RespuestaABM.Exito:
					if (modificando!=null)
						Mensajes.MostrarMensaje("Modelo modificado");
					else
						Mensajes.MostrarMensaje("Modelo añadido");
					modificando = null;
					Close();
					break;
				case RespuestaABM.Error_Existente:
					Mensajes.MostrarError("Ya existe un modelo con el SKU ingresado");
					break;
				case RespuestaABM.Error_DatosInvalidos:
					Mensajes.MostrarError("Los datos no son validos");
					break;
				case RespuestaABM.Error_DatosFaltantes:
					Mensajes.MostrarError("Hay datos faltantes");
					break;
			}
		}

		private void BtnCancelar_Click(object sender, EventArgs e) {
			modificando = null;
			Close();
		}
	}
}
