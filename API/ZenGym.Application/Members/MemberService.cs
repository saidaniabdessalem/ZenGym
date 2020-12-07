using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZenGym.Domain.Entities;
using ZenGym.Domain.Services;

namespace ZenGym.Application.Members
{
    public class MemberService : IMemberService
    {
        private readonly IMemberDataService _memberService;

        public MemberService(IMemberDataService memberService)
        {
            _memberService = memberService;
        }

        public async Task<Member> AddNewMember(Member member)
        {
            if (ValidateMemberDetails(member))
                return await _memberService.CreateAsync(member);
            throw new Exception("Invamid member details");
            
        }

        public async Task<Member> UpdateMemberDetails(int id, Member member)
        {
            if (ValidateMemberDetails(member))
                return await _memberService.UpdateAsync(id, member);
            throw new Exception("Invamid member details");
        }

        private bool ValidateMemberDetails(Member member)
        {
            //validation
            return true;
        }
    }
}
