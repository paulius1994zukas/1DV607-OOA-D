using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        public Member getMember(int i)
        {
            return _members[i];
        }

        public void removeMember(Member m)
        {
            _members.Remove(m);
        }

        public int getIndexOfMember(Member m)
        {
            return _members.IndexOf(m);
        }

        public void saveToFile(string path)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, _members);
            }
        }

        public void loadFromFile(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                _members = JsonConvert.DeserializeObject<List<Member>>(json);
            }

            _lastMemberId = _members[_members.Count - 1].MemberId;
        }
    }
}