using System.Collections.Generic;
using System.Threading.Tasks;
using ZenGym.Domain.Entities;

namespace ZenGym.Application.Members
{
    public interface IMemberService 
    {
        Task<Member> AddNewMember(Member member);
        Task<Member> UpdateMemberDetails(int id, Member member);
    }
}