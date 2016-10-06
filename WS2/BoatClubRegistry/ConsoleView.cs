using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoatClubRegistry
{
    public class ConsoleView
    {
        public void welcomeMessage()
        {
            Console.WriteLine("Welcome to your boat club registry");
        }

        public ConsoleAction listMenu()
        {
            Console.WriteLine("\nOptions: show [v]erbose list | show [c]ompact list | [a]dd member | view [m]ember | [s]ave | [l]oad | [q]uit");
            var input = Console.ReadKey();
            ConsoleAction actionToPerform;
            switch (input.Key)
            {
                case ConsoleKey.V:
                    actionToPerform = ConsoleAction.ViewVerboseList;
                    break;
                case ConsoleKey.C:
                    actionToPerform = ConsoleAction.ViewCompactList;
                    break;
                case ConsoleKey.A:
                    actionToPerform = ConsoleAction.AddMember;
                    break;
                case ConsoleKey.M:
                    actionToPerform = ConsoleAction.ViewMember;
                    break;
                case ConsoleKey.S:
                    actionToPerform = ConsoleAction.SaveToFile;
                    break;
                case ConsoleKey.L:
                    actionToPerform = ConsoleAction.LoadFromFile;
                    break;
                case ConsoleKey.Q:
                    actionToPerform = ConsoleAction.Quit;
                    break;
                default:
                    Console.WriteLine("Not a valid action. Type the characater in the bracket corresponding to the action.");
                    actionToPerform = listMenu();
                    break;

            }
            return actionToPerform;
        }

        public ConsoleAction memberMenu()
        {
            Console.WriteLine("\nOptions: show [v]erbose list | show [c]ompact list | [r]emove member | [e]dit member | [s]ave to file | [q]uit");
            Console.WriteLine("[a]dd boat | edit [b]oat | [r]emove boat");
            var input = Console.ReadKey();
            ConsoleAction actionToPerform;
            switch (input.Key)
            {
                case ConsoleKey.V:
                    actionToPerform = ConsoleAction.ViewVerboseList;
                    break;
                case ConsoleKey.C:
                    actionToPerform = ConsoleAction.ViewCompactList;
                    break;
                case ConsoleKey.R:
                    actionToPerform = ConsoleAction.RemoveMember;
                    break;
                case ConsoleKey.E:
                    actionToPerform = ConsoleAction.EditMember;
                    break;
                case ConsoleKey.S:
                    actionToPerform = ConsoleAction.SaveToFile;
                    break;
                case ConsoleKey.Q:
                    actionToPerform = ConsoleAction.Quit;
                    break;
                default:
                    Console.WriteLine("\nNot a valid action. Type the characater in the bracket corresponding to the action.");
                    actionToPerform = memberMenu();
                    break;

            }
            return actionToPerform;
        }

        public int getNumberInput(string inputHint)
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
            } while (!Int32.TryParse(input.Trim(), out output));

            return output;
        }

        public string getStringInput(string inputHint)
        {
            Console.WriteLine($"\n{inputHint}:");
            return Console.ReadLine();
        }

        public void showCompactList(IReadOnlyList<Member> memberList)
        {
            Console.WriteLine("\nCompact list:");
            for (int i = 0; i < memberList.Count; i++)
            {
                string output = $"#: {i, -10} Member Id: {memberList[i].MemberId,-10} Name: {memberList[i].Name,-20} #Boats: {memberList[i].Boats.Count}";
                Console.WriteLine(output);
            }
        }

        public void showVerboseList(IReadOnlyList<Member> memberList)
        {
            Console.WriteLine("\nVerbose list:");
            for (int i = 0; i < memberList.Count; i++)
            {
                Console.WriteLine();
                showMember(memberList[i], i);
            }
        }

        public void showMember(Member member, int id)
        {
            Console.WriteLine($"#        : {id, -10} Name    : {member.Name}");
            Console.WriteLine($"Member Id: {member.MemberId, -10} PersonId: {member.PersonIdNumber}");
            Console.WriteLine($"Boats    : {member.Boats.Count}");

            foreach (Boat boat in member.Boats)
            {
                Console.WriteLine($"   Type: {boat.BoatType,-12} Length: {boat.Length}");
            }
        }
    }
}