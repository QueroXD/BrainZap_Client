using System;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BrainZap_Client.CLASSES
{
    public class ClSocketClient
    {
        const String CERTIFICAT = @"C:\Users\Usuario\Documents\Educem\DAM\M9\elMeuCertificat.pfx";
        const String psw = "Educem00.";
        private TcpListener servidorLocal;
        private TcpClient cliente;
        private SslStream stream;
        private Thread threadEscucha;
        private bool conectado = false;
        private string ip;
        private int puerto;

        X509Certificate2 elMeuCertificat = new X509Certificate2(CERTIFICAT, psw);

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
            this.ip = ip;
            this.puerto = puerto;
            try
            {
                cliente = new TcpClient();
                cliente.Connect(ip, puerto);
                stream = new SslStream(cliente.GetStream(), false, validarCertificat);

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
                        SslStream sslStream = new SslStream(clienteLocal.GetStream(), false);

                        recibirMensaje(sslStream, buffer);
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
                if (cliente == null)
                {
                    cliente = new TcpClient();
                    cliente.Connect(ip, puerto);
                }

                byte[] datos = Encoding.UTF8.GetBytes(mensaje + "\n");
                stream = new SslStream(cliente.GetStream(), false, validarCertificat);

                stream.AuthenticateAsClient(ip);
                if (stream.CanWrite)
                {
                    stream.Write(System.Text.Encoding.Default.GetBytes(mensaje), 0, mensaje.Length);

                }
            }
            catch (Exception ex)
            {
                gestionarMensaje("ERROR|" + ex.Message);
            }
        }

        public void recibirMensaje(SslStream stream, byte[] buffer)
        {
            try
            {
                stream.AuthenticateAsServer(elMeuCertificat);

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
                MessageBox.Show($"Error al recibir mensaje: {ex.Message}");
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

        private bool validarCertificat(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
