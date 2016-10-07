using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoatClubRegistry
{
    public class Controller
    {
        MemberRegistry _memberRegistry;
        ConsoleView _consoleView;
        Member _memberInFocus = null;
        int? _indexOfFocusedMember = null;

        public Controller(MemberRegistry memberRegistry, ConsoleView consoleView)
        {
            _memberRegistry = memberRegistry;
            _consoleView = consoleView;
        }

        public void start()
        {
            _consoleView.welcomeMessage();
            ConsoleAction actionToPerform = ConsoleAction.ViewCompactList;
            
            do
            {
                switch (actionToPerform)
                {
                    case ConsoleAction.SaveToFile:
                        _memberRegistry.saveToFile(_consoleView.getPathToFile());
                        nullifyFocusedMember();
                        actionToPerform = _consoleView.getNextActionFromListView();
                        break;
                    case ConsoleAction.LoadFromFile:
                        _memberRegistry.loadFromFile(_consoleView.getPathToFile());
                        _consoleView.showCompactList(_memberRegistry.getMembers());
                        nullifyFocusedMember();
                        actionToPerform = _consoleView.getNextActionFromListView();
                        break;
                    case ConsoleAction.ViewCompactList:
                        _consoleView.showCompactList(_memberRegistry.getMembers());
                        nullifyFocusedMember();
                        actionToPerform = _consoleView.getNextActionFromListView();
                        break;
                    case ConsoleAction.ViewVerboseList:
                        _consoleView.showVerboseList(_memberRegistry.getMembers());
                        actionToPerform = _consoleView.getNextActionFromListView();
                        break;
                    case ConsoleAction.ViewMember:
                        int id = _consoleView.getIndexOfMember();
                        _memberInFocus = _memberRegistry.getMember(id);
                        _consoleView.showMember(_memberInFocus, id);
                        actionToPerform = _consoleView.getNextActionFromMemberView();
                        break;
                    case ConsoleAction.AddMember:
                        string name = _consoleView.getName();
                        string pid = _consoleView.getPersonIdNumber();
                        Member newMember = _memberRegistry.addMember(name, pid);
                        _memberInFocus = newMember;
                        _consoleView.showMember(newMember, _memberRegistry.getMembers().Count - 1);
                        actionToPerform = _consoleView.getNextActionFromMemberView();
                        break;
                    case ConsoleAction.EditMember:
                        setFocusedMember();

                        _memberInFocus.Name = _consoleView.getName();
                        _memberInFocus.PersonIdNumber = _consoleView.getPersonIdNumber();

                        _consoleView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
                        actionToPerform = _consoleView.getNextActionFromMemberView();
                        break;
                    case ConsoleAction.RemoveMember:
                        setFocusedMember();

                        _memberRegistry.removeMember(_memberInFocus);
                        nullifyFocusedMember();
                        actionToPerform = ConsoleAction.ViewCompactList;
                        break;
                    case ConsoleAction.AddBoat:
                        setFocusedMember();

                        _memberInFocus.addBoat(_consoleView.getBoatType(), _consoleView.getBoatLength());

                        _consoleView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
                        actionToPerform = _consoleView.getNextActionFromMemberView();
                        break;
                    case ConsoleAction.EditBoat:
                        setFocusedMember();

                        _memberInFocus.editBoat(_consoleView.getBoatId(), _consoleView.getBoatType(), _consoleView.getBoatLength());

                        _consoleView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
                        actionToPerform = _consoleView.getNextActionFromMemberView();
                        break;
                    case ConsoleAction.RemoveBoat:
                        setFocusedMember();

                        _memberInFocus.removeBoat(_consoleView.getBoatId());
                        break;
                }
            } while (actionToPerform != ConsoleAction.Quit);
        }
        private void setFocusedMember()
        {
            if (_memberInFocus == null)
            {
                _indexOfFocusedMember = _consoleView.getIndexOfMember();
                _memberInFocus = _memberRegistry.getMember((int)_indexOfFocusedMember);
            }
            else
            {
                _indexOfFocusedMember = _memberRegistry.getIndexOfMember(_memberInFocus);
            }
        }

        private void nullifyFocusedMember()
        {
            _indexOfFocusedMember = null;
            _memberInFocus = null;
        }
    }
}