using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kitchen.Infrastructure.Preparation;
using Kitchen.Models;
using Kitchen.Server;
using Microsoft.Extensions.Hosting;

namespace Kitchen
{
    public class Kitchen : BackgroundService
    {
        public KitchenServer server;
        public List<Food> menu = new List<Food>();
        public List<Order> orders = new List<Order>();
        public List<CookingApparatus> apparatuses = new List<CookingApparatus>();
        public List<Cook> cooks = new List<Cook>();


        public Kitchen(KitchenServer server)
        {
            this.server = server;
            this.server.StartAsync(this);
            Preparation.PrepareMenu(menu);
        }

        public void InitCookingApparatus()
        {
            Preparation.PrepareCookingApparatus(apparatuses);
        }

        public void InitCooks()
        {
            Preparation.PrepareCooks(cooks);

            foreach(var cook in cooks)
                cook.StartWork(this);
        }

        public void AddOrder(Order order)
        {
            order.Items.ForEach(foodId => order.RealItems.Add(new KitchenFood(menu.First(f => f.Id == foodId))));
            orders.Add(order);
            orders.Sort((o1, o2) => o1.Priority - o2.Priority);
            orders.Sort((o1, o2) => (int)(o1.ReceivedAt.Ticks - o2.ReceivedAt.Ticks));
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            InitCookingApparatus();
            InitCooks();
            return Task.CompletedTask;
        }
    }
}