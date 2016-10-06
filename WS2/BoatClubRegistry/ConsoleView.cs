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
            showVerboseList(_model.getMembers());
            getKeyInput();
        }

        private void getKeyInput()
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
                    Console.WriteLine("\nType name of new member:");
                    string  name = Console.ReadLine();
                    Console.WriteLine("\nType person id number of new member:");
                    string pid = Console.ReadLine();
                    Console.WriteLine(name + pid);
                    break;
                case ConsoleKey.M:
                    Console.WriteLine("\nType member id to view:");
                    string id = Console.ReadLine();
                    showMember((int)id);
                    break;
                case ConsoleKey.S:
                    break;
            }
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