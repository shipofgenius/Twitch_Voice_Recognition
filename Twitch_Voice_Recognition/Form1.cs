using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using KittenzTwitchLib;

namespace Twitch_Voice_Recognition
{
    public partial class frmVoiceRec : Form
    {
        //private server = 
        SpeechRecognitionEngine vrEngine = new SpeechRecognitionEngine();
        TwitchClient objClient = new TwitchClient("irc.chat.twitch.tv", 6667, "#trugamer_maniac", oauth, "trugamer_maniac");
       
        
        public frmVoiceRec()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            vrEngine.RecognizeAsync();
            objClient.OnTwitchConnected += connection_onTwitchConnect;
            vrEngine.SpeechRecognized += vrEngine_SpeechRecognized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "chia seed", "cheese", "sugar", "hello" });
            GrammarBuilder grammarBuild = new GrammarBuilder();
            grammarBuild.Append(commands);
            Grammar grammar = new Grammar(grammarBuild);
            vrEngine.LoadGrammarAsync(grammar);
            // SET AUDIO TO STREAM LATER 
            vrEngine.SetInputToDefaultAudioDevice();
            vrEngine.SetInputToAudioStream();
           


        }

        void vrEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "hello":
                    txtLog.Text += "\n Hello has been heard";
                    break;
                case "cheese":
                    txtLog.Text += "\n cheese has been heard";
                    break;
                case "chia seed":
                    txtLog.Text += "\n chia has been heard";
                    break;
                case "sugar":
                    txtLog.Text += "\n sugar has been heard";
                    break;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            vrEngine.RecognizeAsyncStop();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            objClient.Connect();
        }
           
      void connection_onTwitchConnect(object sender)
        {
            MessageBox.Show("Connected!");
            onTwitchLog(this, "log is working");
        }

        void connection_onTwitchLog(object sender, EventArgs e)
        {
            onTwitchLog(this, "log is working");
        }


    }
}
