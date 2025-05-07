using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BrainZap_Client.CLASSES
{
    public class ClSocketClient
    {
        private TcpClient cliente;
        private NetworkStream stream;
        private Thread threadEscucha;
        private bool conectado = false;

        // Evento para notificar llegada de mensajes
        public event Action<string> mensajeRecibido;

        public bool Conectado => conectado;

        public bool conectar(string ip, int puerto, string nickname)
        {
            try
            {
                cliente = new TcpClient();
                cliente.Connect(ip, puerto);
                stream = cliente.GetStream();
                conectado = true;

                // Enviar el nickname justo después de conectar
                enviarMensaje($"NICK|{nickname}");

                threadEscucha = new Thread(escuchar);
                threadEscucha.IsBackground = true;
                threadEscucha.Start();

                return true;
            }
            catch (Exception ex)
            {
                // Puedes loguearlo o notificar si quieres
                return false;
            }
        }


        private void escuchar()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesLeidos;

                while (conectado && (bytesLeidos = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
                    mensajeRecibido?.Invoke(mensaje);
                }
            }
            catch (Exception ex)
            {
                mensajeRecibido?.Invoke("ERROR|" + ex.Message);
            }
            finally
            {
                desconectar();
            }
        }

        public void enviarMensaje(string mensaje)
        {
            if (!conectado) return;

            try
            {
                byte[] datos = Encoding.UTF8.GetBytes(mensaje);
                stream.Write(datos, 0, datos.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al enviar mensaje: " + ex.Message);
            }
        }

        public void solicitarPregunta()
        {
            enviarMensaje("SOLICITAR_PREGUNTA");
        }

        public void desconectar()
        {
            conectado = false;

            try
            {
                stream?.Close();
                cliente?.Close();
            }
            catch { }
        }
    }
}
