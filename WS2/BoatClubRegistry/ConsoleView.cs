using System;
using System.Linq;
using System.Text;

namespace BoatClubRegistry
{
    public class ConsoleView
    {
        private MemberRegistry _model;
        public ConsoleView(MemberRegistry mr)
        {
            _model = mr;
        }

        public void start()
        {
            Console.WriteLine("Welcome to your boat club registry");
            showCompactList();
            getInput();
        }

        private void getInput()
        {
            Console.ReadKey();
        }

        private void showCompactList()
        {
            Console.Write("Welcome to your boat club registry");
        }

        private void showVerboseList()
        {
            throw new System.NotImplementedException();
        }

        private void showMember()
        {
            throw new System.NotImplementedException();
        }
    }
}