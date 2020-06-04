using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavssStudent.Models;
using TavssStudent.Services;

namespace TavssStudent.Pages
{
    public class CommunityDetailsBase:ComponentBase
    {
        [Inject]
        public ICommunityService CommunityService{ get; set; }
        [Inject]
        public ICourseService CourseService{ get; set; }

        [Parameter]
        public string CommunityId { get; set; }

        public CommunitiesDto Community { get; set; }

        public IEnumerable<MinCourseViewModel> Courses{ get; set; }

        protected override async Task OnInitializedAsync()
        {
            Community = await CommunityService.GetCommunity(CommunityId);
            Courses = await CourseService.GetCourses();

        }
    }
}
