using System;
using System.Collections.Generic;
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
            showCompactList(_model.getMembers());
            listMenu();
        }

        private void listMenu()
        {
            Console.WriteLine("\nOptions: show [v]erbose list | show [c]ompact list | [a]dd member | view [m]ember | [s]ave to file ");
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.V:
                    showVerboseList(_model.getMembers());
                    break;
                case ConsoleKey.C:
                    showCompactList(_model.getMembers());
                    break;
                case ConsoleKey.A:
                    string name = getStringInput("Type name of new member");
                    string pid = getStringInput("Type person id number of new member");
                    Member newMember = _model.addMember(name, pid);
                    showMember(newMember);
                    break;
                case ConsoleKey.M:
                    int id = getNumberInput("Who do you want to view? Type member id.");
                    showMember(_model.getMember(id));
                    break;
                case ConsoleKey.S:
                    break;
            }
        }

        private int getNumberInput(string inputHint)
        {
            Console.WriteLine($"\n{inputHint}:");
            int output;
            string input;
            bool firstTry = true;

            do
            {
                if (!firstTry) Console.WriteLine("Not a number, please try again");
                firstTry = false;
                input = Console.ReadLine();
            } while (Int32.TryParse(input, out output));

            return output;
        }

        private string getStringInput(string inputHint)
        {
            Console.WriteLine($"\n{inputHint}:");
            return Console.ReadLine();
        }

        private void showCompactList(IReadOnlyList<Member> memberList)
        {
            Console.WriteLine("\nCompact list:");
            foreach (Member member in memberList)
            {
                string output = $"Id: {member.MemberId, -10} Name: {member.Name, -20} #Boats: {member.getNumberOfBoats()}";
                Console.WriteLine(output);
            }
        }

        private void showVerboseList(IReadOnlyList<Member> memberList)
        {
            Console.WriteLine("\nVerbose list:");
            foreach(Member member in memberList)
            {
                Console.WriteLine();
                showMember(member);
            }
        }

        private void showMember(Member member)
        {
            Console.WriteLine($"Id      : {member.MemberId}");
            Console.WriteLine($"Name    : {member.Name}");
            Console.WriteLine($"PersonId: {member.PersonIdNumber}");
            Console.WriteLine($"Boats   : {member.getNumberOfBoats()}");

            foreach (Boat boat in member.getBoats())
            {
                Console.WriteLine($"   Type: {boat.BoatType,-12} Length: {boat.Length}");
            }
        }
    }
}