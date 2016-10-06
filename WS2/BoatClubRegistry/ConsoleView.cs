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
            ConsoleAction actionToPerform = ConsoleAction.ViewCompactList;
            Member memberViewed = new Member("Default", "1234567890", Int32.MaxValue);
            do
            {
                switch (actionToPerform)
                {
                    case ConsoleAction.SaveToFile:
                        _model.saveToFile(getStringInput("Type path to file"));
                        actionToPerform = listMenu();
                        break;
                    case ConsoleAction.LoadFromFile:
                        _model.loadFromFile(getStringInput("Type path to file"));
                        actionToPerform = listMenu();
                        break;
                    case ConsoleAction.ViewCompactList:
                        showCompactList(_model.getMembers());
                        memberViewed = null;
                        actionToPerform = listMenu();
                        break;
                    case ConsoleAction.ViewVerboseList:
                        showVerboseList(_model.getMembers());
                        memberViewed = null;
                        actionToPerform = listMenu();
                        break;
                    case ConsoleAction.ViewMember:
                        int id = getNumberInput("Type member id of whom to view");
                        memberViewed = _model.getMember(id);
                        showMember(memberViewed);
                        actionToPerform = memberMenu();
                        break;
                    case ConsoleAction.AddMember:
                        string name = getStringInput("Type name of new member");
                        string pid = getStringInput("Type person id number of new member, 10 digits");
                        Member newMember = _model.addMember(name, pid);
                        memberViewed = newMember;
                        showMember(newMember);
                        actionToPerform = memberMenu();
                        break;
                    case ConsoleAction.EditMember:
                        int editId = getNumberInput("Type member id of whom to remove");
                        Member memberToEdit = _model.getMember(editId);
                        memberToEdit.Name = getStringInput("Type new name of member");
                        memberToEdit.PersonIdNumber = getStringInput("Type new person id number of member, 10 digits");
                        showMember(memberToEdit);
                        actionToPerform = memberMenu();
                        break;
                    case ConsoleAction.RemoveMember:
                        int removeId = getNumberInput("Type member id of whom to remove");
                        Member memberToRemove =_model.getMember(removeId);
                        _model.removeMember(memberToRemove);
                        actionToPerform = ConsoleAction.ViewCompactList;
                        break;
                }
            } while (actionToPerform != ConsoleAction.Quit);
        }

        private ConsoleAction listMenu()
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

        private ConsoleAction memberMenu()
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
            } while (!Int32.TryParse(input.Trim(), out output));

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
                string output = $"Id: {member.MemberId, -10} Name: {member.Name, -20} #Boats: {member.Boats.Count}";
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
            Console.WriteLine($"Boats   : {member.Boats.Count}");

            foreach (Boat boat in member.Boats)
            {
                Console.WriteLine($"   Type: {boat.BoatType,-12} Length: {boat.Length}");
            }
        }
    }
}