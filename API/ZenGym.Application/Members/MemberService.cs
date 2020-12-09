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
        private readonly IMemberDataService _memberDataService;

        public MemberService(IMemberDataService memberService)
        {
            _memberDataService = memberService;
        }

        public async Task<Member> AddNewMember(Member member)
        {
            if (ValidateMemberDetails(member))
                return await _memberDataService.CreateAsync(member);
            throw new Exception("Invalid member details");
            
        }

        public async Task<Member> UpdateMemberDetails(int id, Member member)
        {
            if (ValidateMemberDetails(member))
                return await _memberDataService.UpdateAsync(id, member);
            throw new Exception("Invamid member details");
        }

        private bool ValidateMemberDetails(Member member)
        {
            //validation
            return true;
        }
    }
}
