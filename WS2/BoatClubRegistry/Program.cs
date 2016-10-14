using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClubRegistry.Model;
using BoatClubRegistry.View;
using BoatClubRegistry.Controller;

namespace BoatClubRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberRegistry model = new MemberRegistry();
            ConsoleView view = new ConsoleView();
            ConsoleController c = new ConsoleController(model, view);
            c.start();
        }
    }
}
