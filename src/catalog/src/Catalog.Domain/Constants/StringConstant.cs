using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Constants
{
    public static class ScheduleStatus
    {
        public static string NOT_STARTED => "not_started";
        public static string IN_PROGRESS => "in_progress";
        public static string COMPLETED => "completed";
    }

    public static class FixedExam
    {
        public const string A1Id = "f46d018a-63c3-4e83-a7e9-b381dcae9cd1";
        public const string A2Id = "86f6bf50-a466-4ae8-a1f4-7bfbaf8b0e96";
        public const string A3Id = "ec00060f-ef87-47d8-8ddc-873d2aa81add";
        public const string A4Id = "5bf3cd2b-40f2-41f0-804f-1febe6d25863";
        public const string B1Id = "2bacd63b-a302-42e9-acf8-8eb165a5e135";
        public const string B2Id = "46a4af13-d57a-4dab-9cfa-2247be54be4a";
        public const string CId = "4311838a-c6b2-467c-836d-0237bb196cbe";
        public const string DId = "3a6e1576-43af-4dde-b894-27f28d460084";
        public const string EId = "45959950-fcab-4793-b1ce-422d102aa50b";
        public const string FId = "3cc9c957-c7a1-455e-ad88-43e8f6157695";
    }

    public static class QuestionTag
    {
        public static string Tag1Id => "d1879bda-01dd-43dd-afdd-3e01578e7864";
        public static string Tag2Id => "77f517bd-1855-4e0a-ac49-6893a707520c";
        public static string Tag3Id => "7c99c1ee-a1c8-4e1b-a9a4-a174760e6dc2";
        public static string Tag4Id => "056d3522-078a-4d46-9262-d56ea7e557ea";
        public static string Tag5Id => "f2919aa8-c48b-4311-870f-2ae3c80ac7fe";
        public static string Tag6Id => "b97ae130-8c1c-42b6-a47c-4e5e1fc056b6";
        public static string Tag7Id => "b523c423-79c9-4d29-82ee-aec0ee4db213";
        public static string Tag8Id => "80f521b3-c1d8-42ad-8c04-8e3d93e56fbe";
        public static string Tag9Id => "64f5b16d-5656-4418-8b40-7cb4c972bdd4";
        public static string Tag10Id => "244b45f1-fca2-4c6b-9a1f-71d7e44919c5";
        public static string Tag11Id => "bedbcaa0-fa15-4ee2-89a2-cbab79dd66ca";
    }

    public static class ExamGetValue
    {
        public static int GetPercent(string examId)
        {
            return examId switch
            {
                FixedExam.A1Id => (int)((21.0 / 25.0) * 100),
                FixedExam.A2Id => (int)((23.0 / 25.0) * 100),
                FixedExam.A3Id => (int)((23.0 / 25.0) * 100),
                FixedExam.A4Id => (int)((23.0 / 25.0) * 100),
                FixedExam.B1Id => (int)((27.0 / 30.0) * 100),
                FixedExam.B2Id => (int)((32.0 / 35.0) * 100),
                FixedExam.CId => (int)((36.0 / 40.0) * 100),
                FixedExam.DId => (int)((41.0 / 45.0) * 100),
                FixedExam.EId => (int)((41.0 / 45.0) * 100),
                FixedExam.FId => (int)((41.0 / 45.0) * 100),
                _ => 0
            };
        }
    }
}
