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
            ActionType actionToPerform = ActionType.ViewCompactList;
            
            do
            {
                switch (actionToPerform)
                {
                    case ActionType.SaveToFile:
                        _memberRegistry.saveToFile(_consoleView.getPathToFile());
                        nullifyFocusedMember();
                        actionToPerform = _consoleView.getNextActionFromListView();
                        break;
                    case ActionType.LoadFromFile:
                        _memberRegistry.loadFromFile(_consoleView.getPathToFile());
                        _consoleView.showCompactList(_memberRegistry.getMembers());
                        nullifyFocusedMember();
                        actionToPerform = _consoleView.getNextActionFromListView();
                        break;
                    case ActionType.ViewCompactList:
                        _consoleView.showCompactList(_memberRegistry.getMembers());
                        nullifyFocusedMember();
                        actionToPerform = _consoleView.getNextActionFromListView();
                        break;
                    case ActionType.ViewVerboseList:
                        _consoleView.showVerboseList(_memberRegistry.getMembers());
                        actionToPerform = _consoleView.getNextActionFromListView();
                        break;
                    case ActionType.ViewMember:
                        int id = _consoleView.getIndexOfMember();
                        _memberInFocus = _memberRegistry.getMember(id);
                        _consoleView.showMember(_memberInFocus, id);
                        actionToPerform = _consoleView.getNextActionFromMemberView();
                        break;
                    case ActionType.AddMember:
                        string name = _consoleView.getName();
                        string pid = _consoleView.getPersonIdNumber();
                        Member newMember = _memberRegistry.addMember(name, pid);
                        _memberInFocus = newMember;
                        _consoleView.showMember(newMember, _memberRegistry.getMembers().Count - 1);
                        actionToPerform = _consoleView.getNextActionFromMemberView();
                        break;
                    case ActionType.EditMember:
                        setFocusedMember();

                        _memberInFocus.Name = _consoleView.getName();
                        _memberInFocus.PersonIdNumber = _consoleView.getPersonIdNumber();

                        _consoleView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
                        actionToPerform = _consoleView.getNextActionFromMemberView();
                        break;
                    case ActionType.RemoveMember:
                        setFocusedMember();

                        _memberRegistry.removeMember(_memberInFocus);
                        nullifyFocusedMember();
                        actionToPerform = ActionType.ViewCompactList;
                        break;
                    case ActionType.AddBoat:
                        setFocusedMember();

                        _memberInFocus.addBoat(_consoleView.getBoatType(), _consoleView.getBoatLength());

                        _consoleView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
                        actionToPerform = _consoleView.getNextActionFromMemberView();
                        break;
                    case ActionType.EditBoat:
                        setFocusedMember();

                        _memberInFocus.editBoat(_consoleView.getBoatId(), _consoleView.getBoatType(), _consoleView.getBoatLength());

                        _consoleView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
                        actionToPerform = _consoleView.getNextActionFromMemberView();
                        break;
                    case ActionType.RemoveBoat:
                        setFocusedMember();

                        _memberInFocus.removeBoat(_consoleView.getBoatId());
                        break;
                }
            } while (actionToPerform != ActionType.Quit);
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