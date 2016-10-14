using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoatClubRegistry.Model;

namespace BoatClubRegistry.View
{
    public class ConsoleView
    {
        public void welcomeMessage()
        {
            Console.WriteLine("Welcome to your boat club registry");
        }

        public ActionType getNextActionFromListView()
        {
            Console.WriteLine("\nOptions: show [v]erbose list | show [c]ompact list | [a]dd member | view [m]ember | [s]ave | [l]oad | [q]uit");
            var input = Console.ReadKey();
            ActionType actionToPerform;
            switch (input.Key)
            {
                case ConsoleKey.V:
                    actionToPerform = ActionType.ViewVerboseList;
                    break;
                case ConsoleKey.C:
                    actionToPerform = ActionType.ViewCompactList;
                    break;
                case ConsoleKey.A:
                    actionToPerform = ActionType.AddMember;
                    break;
                case ConsoleKey.M:
                    actionToPerform = ActionType.ViewMember;
                    break;
                case ConsoleKey.S:
                    actionToPerform = ActionType.SaveToFile;
                    break;
                case ConsoleKey.L:
                    actionToPerform = ActionType.LoadFromFile;
                    break;
                case ConsoleKey.Q:
                    actionToPerform = ActionType.Quit;
                    break;
                default:
                    Console.WriteLine("Not a valid action. Type the characater in the bracket corresponding to the action.");
                    actionToPerform = getNextActionFromListView();
                    break;

            }
            return actionToPerform;
        }

        public ActionType getNextActionFromMemberView()
        {
            Console.WriteLine("\nOptions:\n show [v]erbose list | show [c]ompact list | [r]emove member | [e]dit member | [s]ave to file | [q]uit");
            Console.WriteLine("[a]dd boat | edit [b]oat | remove b[o]at");
            var input = Console.ReadKey();
            ActionType actionToPerform;
            switch (input.Key)
            {
                case ConsoleKey.V:
                    actionToPerform = ActionType.ViewVerboseList;
                    break;
                case ConsoleKey.C:
                    actionToPerform = ActionType.ViewCompactList;
                    break;
                case ConsoleKey.R:
                    actionToPerform = ActionType.RemoveMember;
                    break;
                case ConsoleKey.E:
                    actionToPerform = ActionType.EditMember;
                    break;
                case ConsoleKey.A:
                    actionToPerform = ActionType.AddBoat;
                    break;
                case ConsoleKey.B:
                    actionToPerform = ActionType.EditBoat;
                    break;
                case ConsoleKey.O:
                    actionToPerform = ActionType.RemoveBoat;
                    break;
                case ConsoleKey.S:
                    actionToPerform = ActionType.SaveToFile;
                    break;
                case ConsoleKey.Q:
                    actionToPerform = ActionType.Quit;
                    break;
                default:
                    Console.WriteLine("\nNot a valid action. Type the characater in the bracket corresponding to the action.");
                    actionToPerform = getNextActionFromMemberView();
                    break;

            }
            return actionToPerform;
        }

        public int getIndexOfMember()
        {
            return getNumberInput("Type id (#) of member");
        }

        public string getPathToFile()
        {
            return getStringInput("Type path to file");
        }

        public string getName()
        {
            return getStringInput("New name");
        }

        public string getPersonIdNumber()
        {
            return getStringInput("New person id number (10 digits)");
        }

        public BoatType getBoatType()
        {
            Console.WriteLine("\nChoose type of boat:");
            Console.WriteLine("[S]ailboat | [M]otorsailer | [C]anoe | [O]ther");
            var input = Console.ReadKey();
            BoatType type;
            switch (input.Key)
            {
                case ConsoleKey.S:
                    type = BoatType.Sailboat;
                    break;
                case ConsoleKey.M:
                    type = BoatType.Motorsailer;
                    break;
                case ConsoleKey.C:
                    type = BoatType.Canoe;
                    break;
                case ConsoleKey.O:
                    type = BoatType.Other;
                    break;
                default:
                    Console.WriteLine("\nNot a valid boat type. Type the characater in the bracket corresponding to the action.");
                    type = getBoatType();
                    break;

            }
            return type;
        }

        public int getBoatLength()
        {
            return getNumberInput("Type boat length");
        }

        public int getBoatId()
        {
            return getNumberInput("Type boat id (#)");
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

            List<Boat> boats = member.Boats;

            for (int i = 0; i < boats.Count; i++)
            {
                Console.WriteLine($"#: {i, -2}   Type: {boats[i].BoatType,-12} Length: {boats[i].Length}");
            }
        }

        public void showErrorMessage(Exception e)
        {
            Console.WriteLine("Message: {0}", e.Message);
        }
    }
}