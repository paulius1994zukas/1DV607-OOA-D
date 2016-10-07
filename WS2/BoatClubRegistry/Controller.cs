using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoatClubRegistry
{
    public class Controller
    {
        MemberRegistry _mRegistry;
        ConsoleView _cView;
        Member _memberInFocus = null;
        int? _indexOfFocusedMember = null;

        public Controller(MemberRegistry mRegistry, ConsoleView cView)
        {
            _mRegistry = mRegistry;
            _cView = cView;
        }

        public void start()
        {
            _cView.welcomeMessage();
            ConsoleAction actionToPerform = ConsoleAction.ViewCompactList;
            
            do
            {
                switch (actionToPerform)
                {
                    case ConsoleAction.SaveToFile:
                        _mRegistry.saveToFile(_cView.getPathToFile());
                        nullifyFocusedMember();
                        actionToPerform = _cView.listMenu();
                        break;
                    case ConsoleAction.LoadFromFile:
                        _mRegistry.loadFromFile(_cView.getPathToFile());
                        _cView.showCompactList(_mRegistry.getMembers());
                        nullifyFocusedMember();
                        actionToPerform = _cView.listMenu();
                        break;
                    case ConsoleAction.ViewCompactList:
                        _cView.showCompactList(_mRegistry.getMembers());
                        nullifyFocusedMember();
                        actionToPerform = _cView.listMenu();
                        break;
                    case ConsoleAction.ViewVerboseList:
                        _cView.showVerboseList(_mRegistry.getMembers());
                        actionToPerform = _cView.listMenu();
                        break;
                    case ConsoleAction.ViewMember:
                        int id = _cView.getIdOfMember();
                        _memberInFocus = _mRegistry.getMember(id);
                        _cView.showMember(_memberInFocus, id);
                        actionToPerform = _cView.memberMenu();
                        break;
                    case ConsoleAction.AddMember:
                        string name = _cView.getName();
                        string pid = _cView.getPersonIdNumber();
                        Member newMember = _mRegistry.addMember(name, pid);
                        _memberInFocus = newMember;
                        _cView.showMember(newMember, _mRegistry.getMembers().Count - 1);
                        actionToPerform = _cView.memberMenu();
                        break;
                    case ConsoleAction.EditMember:
                        setFocusedMember();

                        _memberInFocus.Name = _cView.getName();
                        _memberInFocus.PersonIdNumber = _cView.getPersonIdNumber();

                        _cView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
                        actionToPerform = _cView.memberMenu();
                        break;
                    case ConsoleAction.RemoveMember:
                        setFocusedMember();

                        _mRegistry.removeMember(_memberInFocus);
                        nullifyFocusedMember();
                        actionToPerform = ConsoleAction.ViewCompactList;
                        break;
                    case ConsoleAction.AddBoat:
                        setFocusedMember();

                        _memberInFocus.addBoat(_cView.getBoatType(), _cView.getBoatLength());

                        _cView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
                        actionToPerform = _cView.memberMenu();
                        break;
                    case ConsoleAction.EditBoat:
                        setFocusedMember();

                        _memberInFocus.editBoat(_cView.getBoatId(), _cView.getBoatType(), _cView.getBoatLength());

                        _cView.showMember(_memberInFocus, (int)_indexOfFocusedMember);
                        actionToPerform = _cView.memberMenu();
                        break;
                    case ConsoleAction.RemoveBoat:
                        setFocusedMember();

                        _memberInFocus.removeBoat(_cView.getBoatId());
                        break;
                }
            } while (actionToPerform != ConsoleAction.Quit);
        }
        private void setFocusedMember()
        {
            if (_memberInFocus == null)
            {
                _indexOfFocusedMember = _cView.getIdOfMember();
                _memberInFocus = _mRegistry.getMember((int)_indexOfFocusedMember);
            }
            else
            {
                _indexOfFocusedMember = _mRegistry.getIndexOfMember(_memberInFocus);
            }
        }

        private void nullifyFocusedMember()
        {
            _indexOfFocusedMember = null;
            _memberInFocus = null;
        }
    }
}