using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Riptide
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            FieldGenerate(YourFleet);
            FieldGenerate(EnemyFleet);
            EnemyFleet.Enabled = false;
            ShipBox.SelectedIndex = 0;
        }

        private Point shipStart;
        private Point shipEnd = new Point(-1, -1);
        private bool[,] shipPosition = new bool[10, 10];
        private bool[,] shipMap = new bool[10, 10];
        private bool[,] shots = new bool[10, 10];
        private int boatNum = 4;
        private int corvetteNum = 3;
        private int frigateNum = 2;
        private int cruiserNum = 1;
        //private int tcpPort = 757;
        //private int udpPort = 755;
        //private int packetNum = 5;
        private bool connected = false;
        private bool enemyConnected = true;
        private bool broadcastFlag = true;
        private bool exitCheck = true;
        //private IPAddress yourIPV4Addr;
        //private TcpClient yourTcpClient;
        //private NetworkStream yourStream;
        //private IPAddress enemyIPV4Addr;
        //private TcpClient enemyTcpClient;
       // private NetworkStream enemyStream;
        private int deckNum = 20;
        private const byte C_USER_CONNECTED = 1;
        private const byte C_USER_DISCONNECTED = 2;
        private const byte C_MESSAGE = 3;
        private const byte C_HIT = 4;
        private const byte C_MISS = 5;
        private const byte C_DEFEATED = 6;

        static string userName;
        private const string host = "127.0.0.1";
        private const int port = 8888;
        static TcpClient client;
        static NetworkStream stream;

        private void FieldGenerate(PictureBox field)
        {
            var bitmap = new Bitmap(field.Width, field.Height);
            field.Image = (Image)bitmap.Clone();
            var graphics = Graphics.FromImage(bitmap);
            graphics.DrawRectangle(new Pen(Color.Black, 4), 0, 0, field.Width, field.Height);
            for (int i = 0; i < 10; i++)
            {
                graphics.DrawLine(new Pen(Color.Black, 4), 0, i * 37, field.Height, i * 37);
            }
            for (int i = 0; i < 10; i++)
            {
                graphics.DrawLine(new Pen(Color.Black, 4), i * 37, 0, i * 37, field.Width);
            }
            graphics.Dispose();
            field.Image.Dispose();
            field.Image = (Image)bitmap.Clone();
            bitmap.Dispose();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                byte[] message = new byte[1];
                message[0] = C_USER_DISCONNECTED;
                stream.Write(message, 0, 1);
                exitCheck = false;
                connected = false;
            }
            SyncInForm MF = this.Owner as SyncInForm;
            MF.Close();
            this.Close();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connected)
            {
                if (exitCheck == true)
                {
                    byte[] message = new byte[1];
                    message[0] = C_USER_DISCONNECTED;
                    stream.Write(message, 0, 1);
                }
                connected = false;
                SyncInForm MF = this.Owner as SyncInForm;
                MF.Close();
            }
        }

        private void YourFleet_MouseClick(object sender, MouseEventArgs e)
        {
            shipStart = shipEnd;
            shipEnd = new Point(e.X, e.Y);
            int i = shipEnd.X / 37;
            int j = shipEnd.Y / 37;
            int xCoord = 37 * i + 2;
            int yCoord = 37 * j + 2;
            shipEnd = new Point(xCoord, yCoord);
        }

        private void EnemyFleet_MouseClick(object sender, MouseEventArgs e)
        {
            Point target = new Point(e.X, e.Y);
            int i = target.X / 37;
            int j = target.Y / 37;
            if (EnemyFleet.Enabled == true)
            {
                var sendMessage = new byte[3];
                sendMessage[0] = C_MESSAGE;
                sendMessage[1] = BitConverter.GetBytes(i)[0];
                sendMessage[2] = BitConverter.GetBytes(j)[0];
                stream.Write(sendMessage, 0, 3);
            }
        }

        private void YourFleet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int shipType = ShipBox.SelectedIndex;
            if (shipType != 0)
            {
                Point temp = shipStart;
                if (shipEnd.X < shipStart.X)
                {
                    shipStart.X = shipEnd.X;
                    shipEnd.X = temp.X;
                }
                else if (shipEnd.Y < shipStart.Y)
                {
                    shipStart.Y = shipEnd.Y;
                    shipEnd.Y = temp.Y;
                }
            }
            switch (shipType)
            {
                case 0:
                    if (boatNum != 0)
                    {
                        int i = (shipEnd.X - 2) / 37;
                        int j = (shipEnd.Y - 2) / 37;
                        if (shipPosition[i, j] == false)
                        {
                            Bitmap bmp = new Bitmap(YourFleet.Image, YourFleet.Width, YourFleet.Height);
                            var graphics = Graphics.FromImage(bmp);
                            graphics.FillRectangle(new SolidBrush(Color.DarkGray), shipEnd.X, shipEnd.Y, 33,

                            33);
                            graphics.Dispose();
                            YourFleet.Image.Dispose();
                            YourFleet.Image = (Image)bmp.Clone();
                            bmp.Dispose();
                            boatNum--;
                            if (j > 0)
                            {
                                AreaFillX(i, j - 1, shipPosition);
                            }
                            AreaFillX(i, j, shipPosition);
                            if (j < 9)
                            {
                                AreaFillX(i, j + 1, shipPosition);
                            }
                            shipMap[i, j] = true;
                        }
                        shipEnd = new Point(-1, -1);
                    }
                    break;
                case 1:
                    if (corvetteNum != 0)
                    {
                        if (((shipEnd.X - shipStart.X) == 37) || ((shipEnd.Y - shipStart.Y) == 37))
                        {
                            corvetteNum = ShipLocate(YourFleet, corvetteNum, 2, shipStart, shipEnd, shipPosition);
                        }
                        shipEnd = new Point(-1, -1);
                    }
                    break;
                case 2:
                    if (frigateNum != 0)
                    {
                        if (((shipEnd.X - shipStart.X) == 37 * 2) || ((shipEnd.Y - shipStart.Y) == 37 * 2))
                        {
                            frigateNum = ShipLocate(YourFleet, frigateNum, 3, shipStart, shipEnd, shipPosition);
                        }
                        shipEnd = new Point(-1, -1);
                    }
                    break;
                case 3:
                    if (cruiserNum != 0)
                    {
                        if (((shipEnd.X - shipStart.X) == 37 * 3) || ((shipEnd.Y - shipStart.Y) == 37 * 3))
                        {
                            cruiserNum = ShipLocate(YourFleet, cruiserNum, 4, shipStart, shipEnd, shipPosition);
                        }
                        shipEnd = new Point(-1, -1);
                    }
                    break;
            }
        }
        private void AreaFillX(int i, int j, bool[,] area)
        {
            if (i > 0)
            {
                area[i - 1, j] = true;
            }
            area[i, j] = true;
            if (i < 9)
            {
                area[i + 1, j] = true;
            }
        }
        private void AreaFillY(int i, int j, bool[,] area)
        {
            if (j > 0)
            {
                area[i, j - 1] = true;
            }
            area[i, j] = true;
            if (j < 9)
            {
                area[i, j + 1] = true;
            }
        }
        private int ShipLocate(PictureBox field, int shipNum, int deckNum, Point start, Point end, bool[,] area)
        {
            int iEnd = (end.X - 2) / 37;
            int jEnd = (end.Y - 2) / 37;
            int iStart = (start.X - 2) / 37;
            int jStart = (start.Y - 2) / 37;
            if (end.X == start.X)
            {
                bool checker = false;
                for (int k = jStart; k <= jEnd; k++)
                {
                    if (area[iStart, k] == true)
                    {
                        checker = true;
                    }
                }
                if (checker == false)
                {
                    int t = jStart;
                    Bitmap bmp = new Bitmap(field.Image, field.Width, field.Height);
                    var graphics = Graphics.FromImage(bmp);
                    if (t > 0)
                    {
                        AreaFillX(iStart, t - 1, area);
                    }
                    for (int k = 0; k < deckNum; k++)
                    {
                        int YCoord = start.Y + k * 37;
                        graphics.FillRectangle(new SolidBrush(Color.DarkGray), end.X, YCoord, 33, 33);
                        if (iStart > 0)
                        {
                            area[iStart - 1, t] = true;
                        }
                        area[iStart, t] = true;
                        shipMap[iStart, t] = true;
                        if (iStart < 9)
                        {
                            area[iStart + 1, t] = true;
                        }
                        t++;
                    }
                    graphics.Dispose();
                    field.Image.Dispose();
                    field.Image = (Image)bmp.Clone();
                    bmp.Dispose();
                    shipNum--;
                    if (t < 10)
                    {
                        AreaFillX(iStart, t, area);
                    }
                }
            }
            else if (end.Y == start.Y)
            {
                bool checker = false;
                for (int k = iStart; k <= iEnd; k++)
                {
                    if (area[k, jStart] == true)
                    {
                        checker = true;
                    }
                }
                if (checker == false)
                {
                    int t = iStart;
                    Bitmap bmp = new Bitmap(field.Image, field.Width, field.Height);
                    var graphics = Graphics.FromImage(bmp);
                    if (t > 0)
                    {
                        AreaFillY(t - 1, jStart, area);
                    }
                    for (int k = 0; k < deckNum; k++)
                    {
                        int XCoord = start.X + k * 37;
                        graphics.FillRectangle(new SolidBrush(Color.DarkGray), XCoord, end.Y, 33, 33);
                        if (jStart > 0)
                        {
                            area[t, jStart - 1] = true;
                        }
                        area[t, jStart] = true;
                        shipMap[t, jStart] = true;
                        if (jStart < 9)
                        {
                            area[t, jStart + 1] = true;
                        }
                        t++;
                    }
                    graphics.Dispose();
                    field.Image.Dispose();
                    field.Image = (Image)bmp.Clone();
                    bmp.Dispose();
                    shipNum--;
                    if (t < 10)
                    {
                        AreaFillY(t, jStart, area);
                    }
                }
            }
            return shipNum;
        }
        private void ReadyBtn_Click(object sender, EventArgs e)
        {
            if ((boatNum == 0) && (corvetteNum == 0) && (frigateNum == 0) && (cruiserNum == 0))
            {
                YourFleet.Enabled = false;
                //ReadyBtn.Enabled = false;
                ExitBtn.Enabled = false;
                ShipBox.Enabled = false;
                TurnIdent.Text = "Waiting for connections";
                /*
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress tempIp in host.AddressList)
                {
                    if (tempIp.AddressFamily == AddressFamily.InterNetwork)
                    {
                        yourIPV4Addr = tempIp;
                    }
                }
                Task.Factory.StartNew(ListenerUDP);
                connected = true;
                UdpClient udpClient =

                new UdpClient("255.255.255.255", udpPort);
                byte[] messageIP = Encoding.Unicode.GetBytes(yourIPV4Addr.ToString());
                udpClient.EnableBroadcast = true;
                Task.Factory.StartNew(ConnectionCatcher);
                for (int i = 0; i < packetNum; i++)
                {
                    udpClient.Send(messageIP, yourIPV4Addr.ToString().Length);
                }
                udpClient.Dispose();
                */

                userName = textBox1.Text;
                client = new TcpClient();
                try
                {
                    client.Connect(host, port);
                    connected = true;
                    stream = client.GetStream();

                    string message = userName;
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    var ConnectMessage = new byte[1];
                    ConnectMessage[0] = C_USER_CONNECTED;
                    stream.Write(ConnectMessage, 0, ConnectMessage.Length);

                    Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                    receiveThread.Start();

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("You have to place all your ships on the battlefield.");
            }
        }

        /* private void ListenerUDP()
         {
             var udpCatcher = new UdpClient(udpPort);
             udpCatcher.EnableBroadcast = true;
             while (broadcastFlag)
             {
                 IPEndPoint hostremote = null;
                 var data = udpCatcher.Receive(ref hostremote);
                 if (connected)
                 {
                     enemyIPV4Addr = hostremote.Address;
                     if (!hostremote.Address.Equals(yourIPV4Addr))
                     {
                         yourTcpClient = new TcpClient();
                         yourTcpClient.Connect(new IPEndPoint(enemyIPV4Addr, tcpPort));
                         yourStream = yourTcpClient.GetStream();
                         enemyStream = yourTcpClient.GetStream();
                         var ConnectMessage = new byte[1];
                         ConnectMessage[0] = C_USER_CONNECTED;
                         yourStream.Write(ConnectMessage, 0, ConnectMessage.Length);
                         enemyTcpClient = yourTcpClient;
                         this.Invoke(new MethodInvoker(() =>
                         {
                             TurnIdent.Text = "Your turn";
                             EnemyFleet.Enabled = true;
                             ExitBtn.Enabled = true;
                         }));
                         broadcastFlag = false;
                         Task.Factory.StartNew(ListenerTCP);
                     }
                 }
             }
         }

         private void ConnectionCatcher()
         {
             TcpListener tcpListener = new TcpListener(yourIPV4Addr, tcpPort);
             tcpListener.Start();
             while (connected)
             {
                 if (tcpListener.Pending())
                 {
                     enemyTcpClient = tcpListener.AcceptTcpClient();
                     enemyIPV4Addr = ((IPEndPoint)enemyTcpClient.Client.RemoteEndPoint).Address;
                     enemyStream = enemyTcpClient.GetStream();
                     byte[] data = new byte[1];
                     enemyStream.Read(data, 0, 1);
                     if (data[0] == C_USER_CONNECTED)
                     {
                         this.Invoke(new MethodInvoker(() =>
                         {
                             TurnIdent.Text = "Enemy's turn";
                             ExitBtn.Enabled = true;
                         }));
                         broadcastFlag = false;
                         Task.Factory.StartNew(ListenerTCP);
                     }
                 }
             }
             tcpListener.Stop();
         }
        */
         private void Interaction()
         {
             while (enemyConnected)
             {
                 if (stream.DataAvailable)
                 {
                     byte[] data = new byte[1];
                     stream.Read(data, 0, 1);
                     byte Type = data[0];
                     switch (Type)
                     {
                         case C_MESSAGE:
                             byte[] msg = new byte[2];
                             stream.Read(msg, 0, 1);
                             stream.Read(msg, 1, 1);
                             int msgx = msg[0];
                             int msgy = msg[1];
                             byte[] response = new byte[3];
                             this.Invoke(new MethodInvoker(() =>
                             {
                                 Bitmap bmp = new Bitmap(YourFleet.Image, YourFleet.Width, YourFleet.Height);
                                 var graphics = Graphics.FromImage(bmp);
                                 if ((shipMap[msgx, msgy] == true) && (shots[msgx, msgy] == false))
                                 {
                                     shots[msgx, msgy] = true;
                                     response[0] = C_HIT;
                                     response[1] = msg[0];
                                     response[2] = msg[1];
                                     stream.Write(response, 0, 3);
                                     graphics.FillRectangle(new SolidBrush(Color.Red), msgx * 37 + 2, msgy * 37 + 2, 33, 33);
                                 }
                                 else if (shots[msgx, msgy] == false)
                                 {
                                     shots[msgx, msgy] = true;
                                     response[0] = C_MISS;
                                     response[1] = msg[0];
                                     response[2] = msg[1];
                                     stream.Write(response, 0, 3);
                                     graphics.FillRectangle(new SolidBrush(Color.Black), msgx * 37 + 2, msgy * 37 + 2, 33, 33);
                                     TurnIdent.Text = "Your turn";
                                     EnemyFleet.Enabled = true;
                                 }
                                 graphics.Dispose();
                                 YourFleet.Image.Dispose();
                                 YourFleet.Image = (Image)bmp.Clone();
                                 bmp.Dispose();
                             }));
                             break;
                         case C_MISS:
                             byte[] missCoords = new byte[2];
                             stream.Read(missCoords, 0, 1);
                             stream.Read(missCoords, 1, 1);
                             int missCoordsX = missCoords[0];
                             int missCoordsY = missCoords[1];
                             this.Invoke(new MethodInvoker(() =>
                             {
                                 Bitmap bmp = new Bitmap(EnemyFleet.Image, EnemyFleet.Width, EnemyFleet.Height);
                                 var graphics = Graphics.FromImage(bmp);
                                 graphics.FillRectangle(new SolidBrush(Color.Black), missCoordsX * 37 + 2, missCoordsY * 37 + 2, 33, 33);
                                 graphics.Dispose();
                                 EnemyFleet.Image.Dispose();
                                 EnemyFleet.Image = (Image)bmp.Clone();
                                 bmp.Dispose();
                                 TurnIdent.Text = "Enemy's turn";
                                 EnemyFleet.Enabled = false;
                             }));
                             break;
                         case C_HIT:
                             byte[] hitCoords = new byte[2];
                             stream.Read(hitCoords, 0, 1);
                             stream.Read(hitCoords, 1, 1);
                             int hitCoordsX = hitCoords[0];
                             int hitCoordsY = hitCoords[1];
                             this.Invoke(new MethodInvoker(() =>
                             {
                                 Bitmap bmp = new Bitmap(EnemyFleet.Image, EnemyFleet.Width, EnemyFleet.Height);
                                 var graphics = Graphics.FromImage(bmp);
                                 graphics.FillRectangle(new SolidBrush(Color.Red), hitCoordsX * 37 + 2, hitCoordsY * 37 + 2, 33, 33);
                                 graphics.Dispose();
                                 EnemyFleet.Image.Dispose();
                                 EnemyFleet.Image = (Image)bmp.Clone();
                                 bmp.Dispose();
                                 deckNum--;
                                 if (deckNum == 0)
                                 {
                                     byte[] victoryMsg = new byte[1];
                                     victoryMsg[0] = C_DEFEATED;
                                     stream.Write(victoryMsg, 0, 1);
                                     MessageBox.Show("You have defeated your enemy");
                                     enemyConnected = false;
                                     connected = false;
                                     exitCheck = false;
                                     SyncInForm MForm = this.Owner as SyncInForm;
                                     MForm.Close();
                                     this.Close();
                                 }
                             }));
                             break;
                         case C_DEFEATED:
                             enemyConnected = false;
                             connected = false;
                             this.Invoke(new MethodInvoker(() =>
                             {
                                 MessageBox.Show("You have been defeated");
                                 exitCheck = false;
                                 SyncInForm MainF = this.Owner as SyncInForm;
                                 MainF.Close();
                                 this.Close();
                             }));
                             break;
                         case C_USER_DISCONNECTED:
                             enemyConnected = false;
                             connected = false;
                             this.Invoke(new MethodInvoker(() =>
                             {
                                 MessageBox.Show("Enemy disconnected");
                                 exitCheck = false;
                                 SyncInForm MainF = this.Owner as SyncInForm;
                                 MainF.Close();
                                 this.Close();
                             }));
                             break;
                     }
                 }
             }
         }
        
        private void ReceiveMessage()
        {
            while (true)
            {
                byte[] data = new byte[1];
                do
                {
                    stream.Read(data, 0, data.Length);
                }
                while (stream.DataAvailable);
                if (data[0] == C_USER_CONNECTED)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        TurnIdent.Text = "Your turn";
                        EnemyFleet.Enabled = true;
                        ExitBtn.Enabled = true;
                    }));
                    Thread interThread = new Thread(new ThreadStart(Interaction));
                    interThread.Start();
                    break;

                }
                else
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        TurnIdent.Text = "Enemy's turn";
                        ExitBtn.Enabled = true;
                    }));
                    Thread interThread = new Thread(new ThreadStart(Interaction));
                    interThread.Start();
                    break;
                }


            }
            

        }
    }
}

