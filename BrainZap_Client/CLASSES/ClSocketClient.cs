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
        private TcpClient cliente;
        private NetworkStream stream;
        private Thread threadEscucha;
        private bool conectado = false;

        public event Action<string> PreguntaRecibida;
        public event Action<string> ResultadoRecibido;
        public event Action<string> FinPartidaRecibido;

        public bool Conectado => conectado;

        public bool conectar(string nickname, string ip, int puerto)
        {
            try
            {
                cliente = new TcpClient();
                cliente.Connect(ip, puerto);
                stream = cliente.GetStream();
                conectado = true;

                enviarMensaje($"NICK|{nickname}|{obtenerIPLocal()}|5555");

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

                while (conectado)
                {    
                    recibirMensaje(buffer);
                }
            }
            catch (Exception ex)
            {
                gestionarMensaje("ERROR|" + ex.Message);
            }
        }

        public void enviarMensaje(string mensaje)
        {
            // utilizar el gestionarMensaje para saber que mensaje enviar al servidor
            try
            {
                byte[] datos = Encoding.UTF8.GetBytes(mensaje + "\n");
                stream.Write(datos, 0, datos.Length);
                
            } catch (Exception ex) {
                gestionarMensaje("ERROR|" + ex.Message);
            }
        }

        public void recibirMensaje(byte[] buffer)
        {
            // Utilizar el gestionarMensaje para procesar el mensaje recibido
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

        private void gestionarMensaje(string mensaje)
        {
            // MENSAJE RECIBIDO: "NICK|nick|OK o NICK|nick|ERROR"
            // si llega nick OK se espera que llegue la pregunta del servidor, si llega ERROR aparece un messageBox diciendo que el nick ya está en uso. Y se vuelve a pedir el nick.

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
            // si llega pregunta se muestra la pregunta y las opciones en el formulario de pregunta.
            // Ahora mandamos la respuesta al servidor: "RESPUESTA|nick|pregunta|respuesta"

            else if (mensaje.StartsWith("PREGUNTA|"))
            {
                PreguntaRecibida?.Invoke(mensaje);
            }


            // Tercer MENSAJE RECIBIDO: "RESULTADO|nick|respuesta|puntos|nick1:puntos1,nick2:puntos2,nick3:puntos3"
            // si llega resultado se muestra el resultado en el formulario de resultado.
            // si llega respuesta correcta el frmPregunta tiene que gestionar que el fondo sea verde y salga que has respondido bien, si llega respuesta incorrecta tiene que gestionar que el fondo sea rojo y que salga que has respondido mal.

            else if (mensaje.StartsWith("RESULTADO|"))
            {
                ResultadoRecibido?.Invoke(mensaje);
            }

            // Cuarto MENSAJE RECIBIDO: "FINPARTIDA|nick1:puntos1,nick2:puntos2,nick3:puntos3"
            // si llega fin de partida se muestra el formulario de fin de partida con los puntos finales de cada jugador.

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
