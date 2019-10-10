using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace LogServer
{
    public class Main : BaseScript
    {
        public Main()
        {
            EventHandlers.Add("playerConnecting", new Action<Player, string, CallbackDelegate>(OnPlayerConnecting));
        }

        private void OnPlayerConnecting([FromSource] Player player, string playerName, CallbackDelegate kickCallback)
        {
            Debug.WriteLine($"^2{player.Name} sta entrando in sessione...");

            string percorso = "LogServer.txt";

            if (!File.Exists(percorso))
            {
                string creazione = $"{player.Name} sta entrando in sessione con il seguente IP = {player.EndPoint.ToString()}, steam:{player.Identifiers["steam"]}, licenza:{player.Identifiers["license"]}, discord:{player.Identifiers["discord"]}, il {DateTime.Now}" + Environment.NewLine;
                File.WriteAllText(percorso, creazione);
            }

            string aggiunta = $"{player.Name} sta entrando in sessione con il seguente IP = {player.EndPoint.ToString()}, steam:{player.Identifiers["steam"]}, licenza:{player.Identifiers["license"]}, discord:{player.Identifiers["discord"]}, il {DateTime.Now}" + Environment.NewLine;
            File.AppendAllText(percorso, aggiunta);
        }
    }
}
