using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoatClubRegistry
{
    public class MemberRegistry
    {
        private List<Member> _members;
        private int _lastMemberId;

        public MemberRegistry()
        {
            _members = new List<Member>();
            _lastMemberId = 0;
        }

        public Member addMember(string name, string personIdNumber)
        {
            _lastMemberId += 1;
            Member newMember = new Member(name, personIdNumber, _lastMemberId);
            _members.Add(newMember);
            return newMember;
        }

        public IReadOnlyList<Member> getMembers()
        {
            return _members.AsReadOnly();
        }

        public Member getMember(int index)
        {
            return _members[index];
        }

        public void removeMember(int index)
        {
            _members.RemoveAt(index);
        }

        public void editMember(int index, string newName, string newPersonIdNumber)
        {
            Member toEdit = _members[index];
            toEdit.Name = newName;
            toEdit.PersonIdNumber = newPersonIdNumber;
        }
    }
}