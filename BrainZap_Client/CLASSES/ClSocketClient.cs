using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BrainZap_Client.CLASSES
{
    public class ClSocketClient
    {
        private TcpListener servidorLocal;
        private TcpClient cliente;
        private NetworkStream stream;
        private Thread threadEscucha;
        private bool conectado = false;

        public event Action<string> PreguntaRecibida;
        public event Action<string> ResultadoRecibido;
        public event Action<string> FinPartidaRecibido;

        public bool Conectado => conectado;

        public void iniciarEscucha()
        {
            try
            {
                servidorLocal = new TcpListener(IPAddress.Any, 5555);
                servidorLocal.Start();

                threadEscucha = new Thread(escuchar);
                threadEscucha.IsBackground = true;
                threadEscucha.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al iniciar escucha: {ex.Message}");
            }
        }

        public bool conectar(string nickname, string ip, int puerto)
        {
            try
            {
                cliente = new TcpClient();
                cliente.Connect(ip, puerto);
                stream = cliente.GetStream();

                conectado = true;

                enviarMensaje($"NICK|{nickname}|{obtenerIPLocal()}|5555");

                return true;
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        private string obtenerIPLocal()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }

        private void escuchar()
        {
            try
            {
                byte[] buffer = new byte[1024];

                while (true)
                {
                    if (servidorLocal.Pending())
                    {
                        TcpClient clienteLocal = servidorLocal.AcceptTcpClient();  // Aceptamos la conexión
                        NetworkStream streamLocal = clienteLocal.GetStream();  // Obtenemos el stream

                        recibirMensaje(streamLocal, buffer);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escuchar: {ex.Message}");
            }
        }

        public void enviarMensaje(string mensaje)
        {
            try
            {
                byte[] datos = Encoding.UTF8.GetBytes(mensaje + "\n");
                stream.Write(datos, 0, datos.Length);
                
            } catch (Exception ex) {
                gestionarMensaje("ERROR|" + ex.Message);
            }
        }

        public void recibirMensaje(NetworkStream stream, byte[] buffer)
        {
            try
            {
                int bytesLeidos = stream.Read(buffer, 0, buffer.Length);

                if (bytesLeidos > 0)
                {
                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
                    foreach (string linea in mensaje.Split('\n'))
                    {
                        if (!string.IsNullOrWhiteSpace(linea))
                        {
                            gestionarMensaje(linea.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al recibir mensaje: {ex.Message}");
            }
        }

        private void gestionarMensaje(string mensaje)
        {
            // MENSAJE RECIBIDO: "NICK|nick|OK o NICK|nick|ERROR"

            if (mensaje.StartsWith("NICK|"))
            {
                string[] partes = mensaje.Split('|');
                if (partes.Length == 3)
                {
                    if (partes[2] == "OK")
                    {
                        MessageBox.Show("Nickname aceptado.");
                    }
                    else
                    {
                        MessageBox.Show("El nickname ya está en uso. Intenta con otro.");
                    }
                }
            }

            // Segundo MENSAJE RECIBIDO: "PREGUNTA|pregunta|opcion1|opcion2|opcion3|opcion4"
            // Ahora mandamos la respuesta al servidor: "RESPUESTA|nick|pregunta|respuesta"

            else if (mensaje.StartsWith("PREGUNTA|"))
            {
                PreguntaRecibida?.Invoke(mensaje);
            }


            // Tercer MENSAJE RECIBIDO: "RESULTADO|nick|respuesta|puntos|nick1:puntos1,nick2:puntos2,nick3:puntos3"

            else if (mensaje.StartsWith("RESULTADO|"))
            {
                ResultadoRecibido?.Invoke(mensaje);
            }

            // Cuarto MENSAJE RECIBIDO: "FINPARTIDA|nick1:puntos1,nick2:puntos2,nick3:puntos3"

            else if (mensaje.StartsWith("FINPARTIDA|"))
            {
                FinPartidaRecibido?.Invoke(mensaje);
            }
            else if (mensaje.StartsWith("ERROR|"))
            {
                MessageBox.Show("Error: " + mensaje);
            }
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
