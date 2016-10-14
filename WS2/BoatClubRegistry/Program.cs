using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClubRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            MemberRegistry model = new MemberRegistry();
            ConsoleView view = new ConsoleView();
            Controller c = new Controller(model, view);
            c.start();
        }
    }
}
