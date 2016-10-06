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

        public Controller(MemberRegistry mRegistry, ConsoleView cView)
        {
            _mRegistry = mRegistry;
            _cView = cView;
        }

        public void start()
        {
            _cView.welcomeMessage();
            ConsoleAction actionToPerform = ConsoleAction.ViewCompactList;
            Member memberViewed;
            do
            {
                switch (actionToPerform)
                {
                    case ConsoleAction.SaveToFile:
                        _mRegistry.saveToFile(_cView.getStringInput("Type path to file"));
                        actionToPerform = _cView.listMenu();
                        break;
                    case ConsoleAction.LoadFromFile:
                        _mRegistry.loadFromFile(_cView.getStringInput("Type path to file"));
                        actionToPerform = _cView.listMenu();
                        break;
                    case ConsoleAction.ViewCompactList:
                        _cView.showCompactList(_mRegistry.getMembers());
                        //memberViewed = null;
                        actionToPerform = _cView.listMenu();
                        break;
                    case ConsoleAction.ViewVerboseList:
                        _cView.showVerboseList(_mRegistry.getMembers());
                        //memberViewed = null;
                        actionToPerform = _cView.listMenu();
                        break;
                    case ConsoleAction.ViewMember:
                        int id = _cView.getNumberInput("Type member id of the member to view");
                        memberViewed = _mRegistry.getMember(id);
                        _cView.showMember(memberViewed, id);
                        actionToPerform = _cView.memberMenu();
                        break;
                    case ConsoleAction.AddMember:
                        string name = _cView.getStringInput("Type name of new member");
                        string pid = _cView.getStringInput("Type person id number of new member, 10 digits");
                        Member newMember = _mRegistry.addMember(name, pid);
                        memberViewed = newMember;
                        _cView.showMember(newMember, _mRegistry.getMembers().Count - 1);
                        actionToPerform = _cView.memberMenu();
                        break;
                    case ConsoleAction.EditMember:
                        int editId = _cView.getNumberInput("Type id (#) of the member to edit");
                        Member memberToEdit = _mRegistry.getMember(editId);
                        memberToEdit.Name = _cView.getStringInput("Type new name of member");
                        memberToEdit.PersonIdNumber = _cView.getStringInput("Type new person id number of member, 10 digits");
                        _cView.showMember(memberToEdit, editId);
                        actionToPerform = _cView.memberMenu();
                        break;
                    case ConsoleAction.RemoveMember:
                        int removeId = _cView.getNumberInput("Type id (#) of the member remove");
                        Member memberToRemove = _mRegistry.getMember(removeId);
                        _mRegistry.removeMember(memberToRemove);
                        actionToPerform = ConsoleAction.ViewCompactList;
                        break;
                }
            } while (actionToPerform != ConsoleAction.Quit);
        }
    }
}