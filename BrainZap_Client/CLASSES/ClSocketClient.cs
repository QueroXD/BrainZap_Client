using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace BrainZap_Client.CLASSES
{
    public class ClSocketClient
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public bool conectado { get; private set; } = false;

        public bool conectar(string ip, int port, string nickname)
        {
            try
            {
                client = new TcpClient();
                client.Connect(ip, port);
                stream = client.GetStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                writer.WriteLine(nickname);
                string respuesta = reader.ReadLine();

                if (respuesta == "OK")
                {
                    conectado = true;
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: " + respuesta);
                    client.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error de conexión: " + e.Message);
                return false;
            }
        }

        public void enviar(string mensaje)
        {
            if (conectado) { writer.WriteLine(mensaje); }
        }

        public string recibir()
        {
            if (conectado)
                return reader.ReadLine();
            return null;
        }

        public void cerrar()
        {
            writer?.Close();
            reader?.Close();
            stream?.Close();
            client?.Close();
            conectado = false;
        }
    }
}
