

using System;
using System.ComponentModel;
using Game;

namespace OriForestArchipelago.Events
{
    public delegate void GameStateChangeEventData(GameStateMachine.State state);
    
    public class GameStateChangeEventClass
    {
        public event GameStateChangeEventData GameStateChangeEvent; 
        private BackgroundWorker _worker;
        
        public GameStateChangeEventClass()
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
            GameStateMachine.State state = GameStateMachine.State.StartScreen;

            while (!bw.CancellationPending)
            {
                try
                {
                    if (GameStateMachine.Instance != null && GameStateMachine.Instance.enabled && GameStateMachine.Instance.CurrentState != state)
                    {
                        state = GameStateMachine.Instance.CurrentState;
                        GameStateChangeEvent.Invoke(state);
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