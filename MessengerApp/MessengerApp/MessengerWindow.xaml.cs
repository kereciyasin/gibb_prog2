using System;
using System.Windows;

namespace MessengerApp
{
    public class MessageEventArgs : EventArgs
    {
        public string Sender { get; }
        public string Message { get; }
        public MessageEventArgs(string sender, string message)
        {
            Sender = sender;
            Message = message;
        }
    }

    public partial class MessengerWindow : Window
    {
        public event EventHandler<MessageEventArgs> MessageSent;
        private readonly string _fensterId;

        public MessengerWindow(string fensterId)
        {
            InitializeComponent();
            _fensterId = fensterId;
            LblTitle.Text = $"Fenster {_fensterId}";
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string msg = MsgInput.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("Nachricht darf nicht leer sein.");
                return;
            }
            AddMessageToChat($"Ich: {msg}");
            MessageSent?.Invoke(this, new MessageEventArgs(_fensterId, msg));
            MsgInput.Clear();
        }

        public void OnOtherWindowMessageReceived(object sender, MessageEventArgs e)
        {
            AddMessageToChat($"{e.Sender}: {e.Message}");
        }

        private void AddMessageToChat(string msg)
        {
            ChatList.Items.Add(msg);
        }
    }
}