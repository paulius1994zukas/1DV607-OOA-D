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
            getInput();
        }

        private void getInput()
        {
            Console.ReadKey();
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