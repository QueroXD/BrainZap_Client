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

                enviarMensaje($"NICK|{nickname}");

                threadEscucha = new Thread(escuchar);
                threadEscucha.IsBackground = true;
                threadEscucha.Start();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private void escuchar()
        {
            try
            {
                byte[] buffer = new byte[1024];

                while (conectado)
                {
                    int bytesLeidos = stream.Read(buffer, 0, buffer.Length);

                    if (bytesLeidos <= 0)
                    {
                        break;
                    }

                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);

                    foreach (string linea in mensaje.Split('\n'))
                    {
                        if (!string.IsNullOrWhiteSpace(linea))
                            mensajeRecibido?.Invoke(linea.Trim());
                    }
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
                byte[] datos = Encoding.UTF8.GetBytes(mensaje + "\n");
                stream.Write(datos, 0, datos.Length);
            }
            catch (Exception ex)
            {
                desconectar();
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
