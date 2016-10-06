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
            Member mem1 = model.addMember("Test", "8604020712");
            mem1.addBoat(BoatType.Sailboat, 10);
            mem1.addBoat(BoatType.Motorsailer, 5);
            mem1.addBoat(BoatType.Canoe, 1000);
            model.addMember("Test1", "8604020712");
            model.addMember("Test2", "8604020712");
            model.addMember("Test3", "8604020712");
            model.addMember("Test4", "8604020712");
            ConsoleView view = new ConsoleView();
            Controller c = new Controller(model, view);
            c.start();
        }
    }
}
