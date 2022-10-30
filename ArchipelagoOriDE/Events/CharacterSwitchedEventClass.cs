using System;
using System.ComponentModel;
using Game;

namespace OriForestArchipelago.Events
{
    public delegate void CharacterSwitchedEventHandler(bool ingame, string character);
    
    public class CharacterSwitchedEventClass
    {
        public event CharacterSwitchedEventHandler CharacterSwitchedEvent; 
        private BackgroundWorker _worker;

        public CharacterSwitchedEventClass()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += new DoWorkEventHandler(CheckUpdate);
            _worker.RunWorkerAsync();
        }
        
        public void CancelEvent()
        {
            this._worker.CancelAsync();
        }

        private void CheckUpdate(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            bool _ingame = false;
            string _name = "";

            while (!bw.CancellationPending)
            {
                try
                {
                    if (Characters.Current != null && !_ingame)
                    {
                        _ingame = true;
                        Main.Logger.Log("The player entered a character: " + Characters.Current.GetType());
                    }
                    else if (Characters.Current == null && _ingame)
                    {
                        _ingame = false;
                        Main.Logger.Log("The player left a character.");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }
    }
}