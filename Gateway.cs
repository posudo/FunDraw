using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketIOClient;

namespace FunDraw
{
    public sealed class Gateway
    {
        private static readonly Lazy<Gateway> _instance = new(() => new Gateway());
        private SocketIOClient.SocketIO _socket;
        public static bool socketState { get; set; } = false; 

        public static Gateway Instance => _instance.Value;

        private Gateway()
        {
            _socket = new SocketIOClient.SocketIO("ws://localhost:3000/game", new SocketIOOptions
            {
                Query = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("token", Session.accessToken),
                }
            });

            _socket.OnConnected += (sender, e) =>
            {
                Debug.WriteLine("Connected to WebSocket.");
                socketState = true;
            };
            _socket.OnDisconnected += (sender, reason) =>
            {
                Debug.WriteLine($"Disconnected: {reason}");
                socketState = false;
            };
        }

        public async void Connect()
        {
            try
            {
                await _socket.ConnectAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"WebSocket connection error: {ex.Message}");
            }
        }

        public async void Disconnect()
        {
            try
            {
                await _socket.DisconnectAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"WebSocket disconnection error: {ex.Message}");
            }
        }

        public void On(string eventName, Action<SocketIOResponse> callback)
        {
            _socket.On(eventName, callback);
        }

        public async void Emit(string eventName, params object[] data)
        {
            if (!socketState)
            {
                Debug.WriteLine("Socket is not connected.");
                return;
            }
            try
            {
                await _socket.EmitAsync(eventName, data);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Emit error: {ex.Message}");
            }
        }
    }
}
