using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoatClubRegistry.Model;
using BoatClubRegistry.View;

namespace BoatClubRegistry.Controller
{
    public class ConsoleController
    {
        MemberRegistry _memberRegistry;
        ConsoleView _consoleView;
        Member _memberInFocus = null;
        int? _indexOfFocusedMember = null;

        public ConsoleController(MemberRegistry memberRegistry, ConsoleView consoleView)
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
                try
                {
                    switch (actionToPerform)
                    {
                        case ActionType.SaveToFile:
                            actionToPerform = saveToFile();
                            break;
                        case ActionType.LoadFromFile:
                            actionToPerform = loadFromFile();
                            break;
                        case ActionType.ViewCompactList:
                            actionToPerform = viewCompactList();
                            break;
                        case ActionType.ViewVerboseList:
                            actionToPerform = viewVerboseList();
                            break;
                        case ActionType.ViewMember:
                            actionToPerform = viewMember();
                            break;
                        case ActionType.AddMember:
                            actionToPerform = addMember();
                            break;
                        case ActionType.EditMember:
                            actionToPerform = editMember();
                            break;
                        case ActionType.RemoveMember:
                            actionToPerform = removeMember();
                            break;
                        case ActionType.AddBoat:
                            actionToPerform = addBoat();
                            break;
                        case ActionType.EditBoat:
                            actionToPerform = editBoat();
                            break;
                        case ActionType.RemoveBoat:
                            actionToPerform = removeBoat();
                            break;
                    }
                }
                catch (Exception e)
                {
                    _consoleView.showErrorMessage(e);
                }
            } while (actionToPerform != ActionType.Quit);
        }

        private ActionType saveToFile()
        {
            _memberRegistry.saveToFile(_consoleView.getPathToFile());
            nullifyFocusedMember();
            return _consoleView.getNextActionFromListView();
        }

        private ActionType loadFromFile()
        {
            _memberRegistry.loadFromFile(_consoleView.getPathToFile());
            _consoleView.showCompactList(_memberRegistry.getMembers());
            nullifyFocusedMember();
            return _consoleView.getNextActionFromListView();
        }

        private ActionType viewCompactList()
        {
            _consoleView.showCompactList(_memberRegistry.getMembers());
            nullifyFocusedMember();
            return _consoleView.getNextActionFromListView();
        }

        private ActionType viewVerboseList()
        {
            _consoleView.showVerboseList(_memberRegistry.getMembers());
            return _consoleView.getNextActionFromListView();
        }

        private ActionType viewMember()
        {
            int id = _consoleView.getIndexOfMember();
            _memberInFocus = _memberRegistry.getMember(id);
            _consoleView.showMember(_memberInFocus, id);
            return _consoleView.getNextActionFromMemberView();
        }

        private ActionType addMember()
        {
            string name = _consoleView.getName();
            string pid = _consoleView.getPersonIdNumber();
            Member newMember = _memberRegistry.addMember(name, pid);
            _memberInFocus = newMember;
            _consoleView.showMember(newMember, _memberRegistry.getMembers().Count - 1);
            return _consoleView.getNextActionFromMemberView();
        }

        private ActionType editMember()
        {
            setFocusedMember();

            _memberInFocus.Name = _consoleView.getName();
            _memberInFocus.PersonIdNumber = _consoleView.getPersonIdNumber();

            _consoleView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
            return _consoleView.getNextActionFromMemberView();
        }

        private ActionType removeMember()
        {
            setFocusedMember();

            _memberRegistry.removeMember(_memberInFocus);
            nullifyFocusedMember();
            return ActionType.ViewCompactList;
        }

        private ActionType addBoat()
        {
            setFocusedMember();

            _memberInFocus.addBoat(_consoleView.getBoatType(), _consoleView.getBoatLength());

            _consoleView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
            return _consoleView.getNextActionFromMemberView();
        }

        private ActionType editBoat()
        {
            setFocusedMember();

            _memberInFocus.editBoat(_consoleView.getBoatId(), _consoleView.getBoatType(), _consoleView.getBoatLength());

            _consoleView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
            return _consoleView.getNextActionFromMemberView();
        }

        private ActionType removeBoat()
        {
            setFocusedMember();

            _memberInFocus.removeBoat(_consoleView.getBoatId());
            _consoleView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
            return _consoleView.getNextActionFromMemberView();
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