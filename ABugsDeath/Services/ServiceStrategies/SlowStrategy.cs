using ABugsDeath.Assets;
using ABugsDeath.Interfaces;
using ABugsDeath.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ABugsDeath.Services.ServiceStrategies
{
    public class SlowStrategy : IServiceStrategy
    {
        #region Private Attributes
        private ServiceBase Service;
        #endregion

        #region Constructor
        public SlowStrategy(ServiceBase Service)
        {
            this.Service = Service;
        }
        #endregion

        public void GoToPlace()
        {
            var TeamLeader = this.Service.Team as TeamLeader;
            List<WorkerBase> Workers = TeamLeader.Team;

            var Message = $"El equipo formado por {TeamLeader.Name}";

            var WorkersCount = Workers.Count;

            if (WorkersCount == 1)
            {
                Message += $" y su trabajador {Workers.First().Name}";
            }
            else if (WorkersCount == 2)
            {
                Message += $" y sus trabajadores {Workers[0].Name} y {Workers[1].Name}";
            }
            else if (WorkersCount == 3)
            {
                Message += $" y sus trabajadores {Workers[0].Name}, {Workers[1].Name} y {Workers[2].Name}";
            }

            Message += " van a atender una solicitud, pero con calma...";

            Console.WriteLine(Message);
        }

        public void Kill()
        {
            var Poison = this.Service.Poison;

            Console.WriteLine($"La plaga a erradicar es de {this.Service.Animal.Name}.");

            Console.WriteLine($"Tienen {Poison.Quantity} gramos de {Poison.Name} para exterminar la plaga.");

            Console.WriteLine("Exterminando...");
            Thread.Sleep(5000);

            Console.WriteLine("Parada para el bocata...");
            Thread.Sleep(3000);

            Console.WriteLine("Exterminando...");
            Thread.Sleep(1000);

            Console.WriteLine("Plaga erradicada!");
        }

        public void CleanPlace()
        {
            var bleach = this.Service.Assets.Where(x => x.GetNombreRecurso().Equals("Bleach"));

            if (bleach != null)
            {
                Console.WriteLine($"Tienen {bleach.Count()} mililitros de lejía para limpiar.");

                Console.WriteLine("Limpiando...");
                Thread.Sleep(5000);

                Console.WriteLine("Parada para el segundo bocata...");
                Thread.Sleep(3000);

                Console.WriteLine("Limpiando...");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("No han traído lejía, por lo que presuponen que no hay labores de limpieza que realizar.");
            }

            Console.WriteLine("Limpieza completada!");
        }

        public void GenerateInvoice()
        {
            throw new NotImplementedException();
        }
    }
}
